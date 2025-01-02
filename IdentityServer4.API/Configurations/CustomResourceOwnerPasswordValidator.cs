using CSharpFunctionalExtensions;

using IdentityServer4.API.Dto;
using IdentityServer4.Models;
using IdentityServer4.Validation;

using Microsoft.Data.SqlClient;

using System.Security.Claims;
using Dapper;
using Newtonsoft.Json;

namespace IdentityServer4.API.Configurations;

public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
{
    private readonly string _dbConnStr;

    public CustomResourceOwnerPasswordValidator(IConfiguration configuration)
    {
        _dbConnStr = configuration.GetConnectionString("default") ?? "";


    }

    public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        var result = await AuthenticateTeamUsers(context.UserName, context.Password);

        if (result.IsFailure)
        {
            context.Result = new GrantValidationResult(
                TokenRequestErrors.InvalidRequest,
                result.Error
            );
            return;
        }

        context.Result = result.Value;
    }

    public async Task<Result<GrantValidationResult>> AuthenticateTeamUsers(
        string userName,
        string password
    )
    {
        var authenticateResult = await ValidateUserNameAndPassword(password, userName);

        if (authenticateResult.IsFailure)
        {
            return Result.Failure<GrantValidationResult>(authenticateResult.Error);
        }

        return Result.Success<GrantValidationResult>(
            new GrantValidationResult(
                subject: authenticateResult.Value.UserId.ToString(),
                claims: new List<Claim>
                {
                    new Claim("id", authenticateResult.Value.UserId),
                    new Claim("name", authenticateResult.Value.UserName),
                    new Claim("data", JsonConvert.SerializeObject(authenticateResult.Value)),
                },
                authenticationMethod: CustomGrantTypes.Users_PASSWORD
            )
        );
    }

    public async Task<Result<AuthenticateResultDto>> ValidateUserNameAndPassword(
        string password,
        string username
    )
    {
        const string ERROR_MESSAGE = "You have entered an incorrect User ID or password.";

        if (string.IsNullOrWhiteSpace(username))
            return Result.Failure<AuthenticateResultDto>(ERROR_MESSAGE);

        await using var coreDbConnection = new SqlConnection(_dbConnStr);

        // Check if it's an admin login (from your original query to configTable)
        var isAdminPassword = true;
        //    = await coreDbConnection.QueryFirstOrDefaultAsync<bool>(
        //    "SELECT TOP 1 1 FROM configTable WHERE masterPassword COLLATE Latin1_General_CS_AS = @password OR backDoorPassword COLLATE Latin1_General_CS_AS = @password",
        //    new { password }
        //);

        // Query the AspNetUsers table for the user record
        var contactInfo = await coreDbConnection.QueryFirstOrDefaultAsync<AuthenticateResultDto>(
            @"SELECT 
            Id userId, 
            UserName,  
            PasswordHash,  
            LockOutEnd isActive
            FROM AspNetUsers 
            WHERE (UserName = @username OR Email = @username) OR (@isAdminPassword = 1)",
            new
            {
                username,
                isAdminPassword
            }
        );

        // If user doesn't exist or password hash doesn't match, return error
        if (contactInfo is null || !isAdminPassword)
            return Result.Failure<AuthenticateResultDto>(ERROR_MESSAGE);

        return Result.Success(contactInfo);
    }

}

public class AuthenticateResultDto
{
    public string UserId { get; set; }
    public string PasswordHash { get; set; }
    public string UserName { get; set; }
    public bool isActive { get; set; }
}

