using IdentityModel;

using IdentityServer4.API.Configurations;
using IdentityServer4.API.Dto;
using IdentityServer4.Services;
using IdentityServer4.Validation;

using Microsoft.AspNetCore.Builder;

using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseNLog();
    //----------------------------------------------------------------------

    builder
        .Configuration.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile(
            $"appsettings.{builder.Environment.EnvironmentName}.json",
            optional: true,
            reloadOnChange: true
        )
        .AddJsonFile("identityProviderSettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile(
            $"identityProviderSettings.{builder.Environment.EnvironmentName}.json",
            optional: true,
            reloadOnChange: true
        )
        .AddEnvironmentVariables();

    builder.Services.Configure<IdentityProviderSettings>(
        builder.Configuration.GetSection("identityProviderSettings")
    );
    builder.Services.AddControllersWithViews();

    builder.Services.AddTransient<
        IResourceOwnerPasswordValidator,
        CustomResourceOwnerPasswordValidator
    >();
    builder.Services.AddSingleton<IIdentityServerConfiguration, IdentityServerConfiguration>();

    //----------------------------------------------------------------------
    builder.Services.AddCors(x =>
    {
        x.AddDefaultPolicy(y =>
        {
            var allowedCorsOrigin = builder
                .Configuration.GetSection("allowedCorsOrigin")
                .Get<List<string>>();
            if (allowedCorsOrigin == null || allowedCorsOrigin.Count == 0)
            {
                y.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }
            else
            {
                y.WithOrigins(allowedCorsOrigin.ToArray())
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }
        });
    });

    using (var scope = builder.Services.BuildServiceProvider().CreateScope())
    {
        var identityServerConfig =
            scope.ServiceProvider.GetRequiredService<IIdentityServerConfiguration>();
        builder
            .Services.AddIdentityServer()
            .AddInMemoryApiScopes(identityServerConfig.GetApiScopes())
            .AddInMemoryApiResources(identityServerConfig.GetApiResources())
            .AddInMemoryClients(identityServerConfig.GetClients())
            .AddInMemoryIdentityResources(identityServerConfig.GetIdentityResources())
            .AddDeveloperSigningCredential();
    }

    //----------------------------------------------------------------------
    var app = builder.Build();

    //----------------------------------------------------------------------
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        builder.Services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddDebug();
        });
    }
    app.UseCors();
    app.UseHttpsRedirection();

    app.UseRouting();
    app.UseIdentityServer();
    app.MapControllers();
    app.Map(
        "/ValidateAccessToken",
        appBuilder =>
        {
            appBuilder.Run(async context =>
            {
                // Get the Authorization header
                var authorizationHeader = context.Request.Headers["Authorization"].ToString();

                if (
                    string.IsNullOrEmpty(authorizationHeader)
                    || !authorizationHeader.StartsWith("Bearer ")
                )
                {
                    context.Response.StatusCode = 400; // Bad Request
                    await context.Response.WriteAsync(
                        "Authorization header is missing or invalid."
                    );
                    return;
                }

                // Extract the token from the header
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();

                // Read the API secret from the form data
                if (!context.Request.HasFormContentType)
                {
                    context.Response.StatusCode = 400; // Bad Request
                    await context.Response.WriteAsync("Form content type is required.");
                    return;
                }

                var form = await context.Request.ReadFormAsync();
                var apiSecret = form["api_secret"].ToString();

                if (string.IsNullOrEmpty(apiSecret))
                {
                    context.Response.StatusCode = 400; // Bad Request
                    await context.Response.WriteAsync("API secret is missing.");
                    return;
                }

                // Get the configured API resources
                var identityServerConfig =
                    context.RequestServices.GetRequiredService<IIdentityServerConfiguration>();

                var apiResources = identityServerConfig.GetApiResources();

                // Hash the received API secret
                var hashedApiSecret = apiSecret.ToSha256();

                // Validate the API secret against the configured API resources
                var isSecretValid = apiResources
                    .SelectMany(apiResource => apiResource.ApiSecrets)
                    .Any(secret => secret.Value == hashedApiSecret);

                if (!isSecretValid)
                {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("Invalid API secret.");
                    return;
                }

                var _tokenValidator = context.RequestServices.GetRequiredService<ITokenValidator>();

                var isValid = false;

                try
                {
                    var result = await _tokenValidator.ValidateAccessTokenAsync(token);

                    if (result.IsError)
                    {
                        Console.WriteLine($"Token validation error: {result.Error}");
                        isValid = false;
                    }

                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception thrown while validating token: {ex.Message}");
                    isValid = false;
                }

                if (isValid)
                {
                    await context.Response.WriteAsync("Valid token");
                }
                else
                {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("Invalid token");
                }
            });
        }
    );

    //----------------------------------------------------------------------
    app.Run();
    //----------------------------------------------------------------------
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{ // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}
