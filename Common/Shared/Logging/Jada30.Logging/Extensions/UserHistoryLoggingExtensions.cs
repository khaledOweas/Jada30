using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Jada30.Logging.Extensions
{
    //public class UserHistoryLoggingExtensions
    //{
    //    private readonly RequestDelegate _next;
    //    public UserHistoryLoggingExtensions(RequestDelegate next)
    //    {
    //        _next = next;
    //    }

    //    // Logs request(method, path, body), response(status code, body), elapsed time, timestamp, and correlationId
    //    // Add [DoLog] to an endpoint to enable logging
    //    public async Task Invoke(HttpContext context)
    //    {
    //        Endpoint? endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;

    //        if (endpoint != null)
    //        {
    //            var userId = "";
    //            if (context.Request.Headers.ContainsKey("Authorization"))
    //            {
    //                var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
    //                 userId = GetUserIdFromToken(token);

    //                if (!string.IsNullOrEmpty(userId))
    //                {
    //                    // Store the user ID in the HttpContext.Items collection
    //                    context.Items["UserId"] = userId;
    //                }
    //            }
    //            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
    //            var port = context.Connection.RemotePort;
    //            var browser = context.Request.Headers["User-Agent"].ToString();
    //          //  DoLogAttribute? doLog = endpoint.Metadata.GetMetadata<DoLogAttribute>();
    //            //if (doLog?.Enabled ?? false)
    //            //{
    //                Stopwatch stopwatch = new Stopwatch();
    //                stopwatch.Start();

    //                // Log the request body
    //                context.Request.EnableBuffering();
    //                string requestBody = "";
    //                requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
    //                context.Request.Body.Position = 0;

    //                // Log the response body
    //                Stream originalBodyStream = context.Response.Body;
    //                using (MemoryStream responseBody = new MemoryStream())
    //                {
    //                    context.Response.Body = responseBody;

    //                    await _next(context);

    //                    stopwatch.Stop();

    //                    context.Response.Body.Seek(0, SeekOrigin.Begin);
    //                    string responseBodyString = await new StreamReader(context.Response.Body).ReadToEndAsync();
    //                    context.Response.Body.Seek(0, SeekOrigin.Begin);

    //                Log.Information("Request: {Method} {Path} {Body}, Response: {Status} {ResponseBody}, Elapsed Time: {ElapsedMilliseconds}ms, IP: {IpAddress}:{Port}, Browser: {Browser}, UserId: {UserId}",
    //                    context.Request.Method,
    //                    context.Request.Path,
    //                    requestBody,
    //                    context.Response.StatusCode,
    //                    responseBodyString,
    //                    stopwatch.ElapsedMilliseconds,
    //                    ipAddress,
    //                    port,
    //                    browser,
    //                    userId);

    //                await responseBody.CopyToAsync(originalBodyStream);
    //            }
    //          //  }
    //            //else
    //            //{
    //            //    await _next(context);
    //            //}
    //        }
    //        else
    //        {
    //            await _next(context);
    //        }
    //    }
    //    private string GetUserIdFromToken(string token)
    //    {
    //        var handler = new JwtSecurityTokenHandler();
    //        var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

    //        if (jwtToken == null)
    //            return null;

    //        var userIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

    //        return userIdClaim?.Value;
    //    }
    //}
}
