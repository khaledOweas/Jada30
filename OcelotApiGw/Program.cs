using System.IO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;
using Newtonsoft.Json.Linq;
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

var key = Encoding.ASCII.GetBytes("SAmTEch@123@21212test123456788987654321");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "your-issuer",
            ValidAudience = "your-audience",
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

await app.UseOcelot();
app.Run();

