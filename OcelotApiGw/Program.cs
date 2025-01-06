
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Load and merge configuration files
var ocelotConfigPath = $"Identity.{builder.Environment.EnvironmentName}.json";
if (!File.Exists(ocelotConfigPath))
{
    throw new FileNotFoundException($"Configuration file not found: {ocelotConfigPath}");
}

var ocelotConfig1 = JObject.Parse(File.ReadAllText(ocelotConfigPath));

// Merge Routes
if (ocelotConfig1["Routes"] is JArray routes)
{
    ocelotConfig1["Routes"] = new JArray(routes /*.Concat(otherRoutes)*/);
}
else
{
    ocelotConfig1["Routes"] = new JArray(); // Ensure it's at least an empty array
}

// Merge SwaggerEndPoints
if (ocelotConfig1["SwaggerEndPoints"] is JArray swaggerEndpoints)
{
    ocelotConfig1["SwaggerEndPoints"] = new JArray(swaggerEndpoints /*.Concat(otherSwaggerEndpoints)*/);
}
else
{
    ocelotConfig1["SwaggerEndPoints"] = new JArray(); // Ensure it's at least an empty array
}

// Write the merged configuration to a temporary file
var tempConfigPath = "mergedOcelot.json";
File.WriteAllText(tempConfigPath, ocelotConfig1.ToString());

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
            options.DefaultChallengeScheme = "Bearer";
        })
        .AddJwtBearer(
            "Bearer",
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

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
}, option =>
{
    option.DocumentTitle = "Ocelot Gateway";
}).UseOcelot().Wait();

await app.UseOcelot();
app.Run();

