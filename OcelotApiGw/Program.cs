
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Define microservices
var microservices = new[] { "Identity", "Lookups" };
var environment = builder.Environment.EnvironmentName;
var tempConfigPath = "mergedOcelot.json";

// Initialize a JObject for merging
var mergedConfig = new JObject
{
    ["Routes"] = new JArray(),
    ["SwaggerEndPoints"] = new JArray()
};

// Iterate through each microservice to load and merge configurations
foreach (var service in microservices)
{
    var configPath = $"{service}.{environment}.json";

    if (!File.Exists(configPath))
    {
        throw new FileNotFoundException($"Configuration file not found: {configPath}");
    }

    var serviceConfig = JObject.Parse(File.ReadAllText(configPath));

    // Merge Routes
    if (serviceConfig["Routes"] is JArray serviceRoutes)
    {
        ((JArray)mergedConfig["Routes"]).Merge(serviceRoutes);
    }

    // Merge SwaggerEndPoints
    if (serviceConfig["SwaggerEndPoints"] is JArray serviceSwaggerEndpoints)
    {
        ((JArray)mergedConfig["SwaggerEndPoints"]).Merge(serviceSwaggerEndpoints);
    }
}

// Write the merged configuration to a temporary file
File.WriteAllText(tempConfigPath, mergedConfig.ToString());

// Add the merged configuration to the app builder
builder.Configuration.AddJsonFile(tempConfigPath, optional: false, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerForOcelot(builder.Configuration);


builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

builder.Services.AddAuthorization();
#region Authentication Region

ConfigureAuthentication(builder);
static void ConfigureAuthentication(WebApplicationBuilder builder)
{
    string idsUrl = builder.Configuration.GetValue<string>("IdentityProviderUrl") ?? "";
    string appName = builder.Configuration.GetValue<string>("IdentityAppName") ?? "";

    builder.Services
        .AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(
            JwtBearerDefaults.AuthenticationScheme,
            options =>
            {
                options.Authority = idsUrl; // IdentityServer4 URL
                options.Audience = appName; // API resource name (api_gateway)
                options.RequireHttpsMetadata = true; // Disable HTTPS requirement for development
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = appName,
                    ValidateIssuer = true,
                    ValidIssuer = idsUrl,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero // Optional: Reduce clock skew for stricter validation,

                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("Authentication failed: " + context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token validated: " + context.SecurityToken);
                        return Task.CompletedTask;
                    }
                };
            }
        );
}
#endregion

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    context.Request.Headers["X-Secure-Gateway-Value"] = "qlw34umoWMTYLOQI238FY45O1QTWEf2t412fmwsd1m234";
    await next.Invoke();
});

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
}, option =>
{
    option.DocumentTitle = "Ocelot Gateway";
}).UseOcelot().Wait();

//await app.UseOcelot();

app.Run();