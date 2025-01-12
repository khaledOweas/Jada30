using Identity.Framework.Cache;
using Identity.Infrastructure.Data;
using Identity.Infrastructure.Models;
using Identity.Infrastructure.Seeding;

using Jada30.Logging;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Redis;
using Serilog;
using StackExchange.Redis;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddSingleton<IConnectionMultiplexer>(x =>
    ConnectionMultiplexer.Connect(builder.Configuration.GetValue<string>("RedisConnection")));

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();


builder.Services.AddScoped<ICacheService, CacheService>();      
#region Logginig service
builder.Services.AddExceptionLogging();
LoggingConfigurationExtensions.ConfigureLogging();
builder.Host.UseSerilog();
#endregion 

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

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin", policy =>
//    {
//        policy.WithOrigins("*") // Ocelot Gateway URL
//              .AllowAnyMethod()
//              .AllowAnyHeader()
//              .AllowCredentials();
//    });
//});
var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<IdentityContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

        // Apply pending migrations (optional, ensures the database is up-to-date)
        context.Database.Migrate();

        // Seed the database
        await DataSeeder.SeedAsync(context, userManager, roleManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
///app.UseCors("AllowSpecificOrigin");

//app.Use(async (context, next) =>
//{
//    var forwardedFor = context.Request.Headers["X-Secure-Gateway-Value"].FirstOrDefault();
//    var allowedGatewayIp = "qlw34umoWMTYLOQI238FY45O1QTWEf2t412fmwsd1m234";
//    if (string.IsNullOrEmpty(forwardedFor) || !forwardedFor.Contains(allowedGatewayIp))
//    {
//        context.Response.StatusCode = StatusCodes.Status403Forbidden;
//        await context.Response.WriteAsync($"Access denied: Direct access is not allowed. {forwardedFor}");
//        return;
//    }
//    await next.Invoke();
//});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
