
using Jada30.Logging;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Lookups.Application;
using Infrastructure.Data;
using Lookups.Application.Seeding;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(Lookups.Application.Mappings.MappingProfile));


builder.Services.AddDbContext<Jada30Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddRepository(builder.Configuration);

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
                options.Authority = idsUrl;
                options.Audience = appName;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = appName,
                    ValidateIssuer = true,
                    ValidIssuer = idsUrl,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero

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

#endregion


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<Jada30Context>();

        context.Database.Migrate();
        await DataSeeder.SeedAsync(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    var forwardedFor = context.Request.Headers["X-Secure-Gateway-Value"].FirstOrDefault();
    var allowedGatewayIp = "qlw34umoWMTYLOQI238FY45O1QTWEf2t412fmwsd1m234";
    if (string.IsNullOrEmpty(forwardedFor) || !forwardedFor.Contains(allowedGatewayIp))
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        await context.Response.WriteAsync($"Access denied: Direct access is not allowed. {forwardedFor}");
        return;
    }
    await next();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
