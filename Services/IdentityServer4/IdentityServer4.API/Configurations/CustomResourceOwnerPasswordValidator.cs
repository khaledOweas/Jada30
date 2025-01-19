using CSharpFunctionalExtensions;

using IdentityServer4.API.Dto;
using IdentityServer4.Models;
using IdentityServer4.Validation;

using Microsoft.Data.SqlClient;

using System.Security.Claims;
using Dapper;
using Newtonsoft.Json;
using IdentityModel;
using Microsoft.AspNetCore.Identity;

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
        var userId = authenticateResult.Value.UserId;
        var userNameDb = authenticateResult.Value.UserName;

        var roles = await GetUserRolesAsync(userId);
        var permissions = await GetUserPermissionsAsync(roles);

        var claims = new List<Claim>
        {
            new Claim("id", authenticateResult.Value.UserId.ToString()),
            new Claim("name", authenticateResult.Value.UserName), 
            new Claim("data", JsonConvert.SerializeObject(authenticateResult.Value)),
        };
        foreach (var roleName in roles)
        {
            claims.Add(new Claim(JwtClaimTypes.Role, roleName));
        }
        foreach (var permissionName in permissions)
        {
            claims.Add(new Claim("permission", permissionName));
        }
        return Result.Success<GrantValidationResult>(
            new GrantValidationResult(
                subject: authenticateResult.Value.UserId.ToString(),
                claims: claims,
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
        var isAdminPassword = await coreDbConnection.QueryFirstOrDefaultAsync<bool>(
            "SELECT TOP 1 1 FROM sysConfigs WHERE [key] = 'Master-Password' and  Value = @password",
            new { password }
        );

        // Retrieve the record from the database (as you do in contactInfo)
        var contactInfo = await coreDbConnection.QueryFirstOrDefaultAsync<AuthenticateResultDto>(
            @"SELECT 
               Id userId, 
               UserName,        
               UserNameAr, 
               PasswordHash,  
               LockOutEnd isActive
               FROM AspNetUsers 
               WHERE (UserName = @username OR Email = @username) and (@isAdminPassword = 1)",
            new
            {
                username,
                isAdminPassword
            }
        );

        if (contactInfo == null)
        {
            // The user does not exist or there was another error
            return Result.Failure<AuthenticateResultDto>(ERROR_MESSAGE);
        }

        // If this is not the admin (master) password, we need to verify the user’s actual hashed password
        if (!isAdminPassword)
        {
            // 1) Prepare an object representing the user (of type IdentityUser or a similar class)
            //    You only need to fill the fields required by the VerifyHashedPassword method
            var identityUser = new IdentityUser
            {
                Id = contactInfo.UserId.ToString(),    // Note the type (string in IdentityUser)
                UserName = contactInfo.UserName
            };

            // 2) Use the PasswordHasher to compare the stored DB hash with the plain-text password provided
            var passwordHasher = new PasswordHasher<IdentityUser>();
            var verifyResult = passwordHasher.VerifyHashedPassword(
                identityUser,
                contactInfo.PasswordHash,   // The hashed password from the database
                password                    // The user-entered plain-text password
            );

            if (verifyResult != PasswordVerificationResult.Success)
            {
                // The password does not match
                return Result.Failure<AuthenticateResultDto>(ERROR_MESSAGE);
            }
        }


        return Result.Success(contactInfo);
    }
    private async Task<List<string>> GetUserRolesAsync(long userId)
    {

        var query = @"
        SELECT r.Name
        FROM AspNetUserRoles ur
        JOIN AspNetRoles r ON r.Id = ur.RoleId
        WHERE ur.UserId = @UserId
    ";
        using var conn = new SqlConnection(_dbConnStr);
        return (await conn.QueryAsync<string>(query, new { UserId = userId })).ToList();
    }

    private async Task<List<string>> GetUserPermissionsAsync(List<string> roleNames)
    {
        var query = @"
        SELECT p.Name
        FROM AspNetRoles r
        JOIN RolePermissions rp ON r.Id = rp.RoleId
        JOIN Permissions p ON rp.PermissionId = p.Id
        WHERE r.Name IN @roleNames
        GROUP BY p.Name
    ";

        using var conn = new SqlConnection(_dbConnStr);
        return (await conn.QueryAsync<string>(query, new { roleNames })).ToList();
    }
}

public class AuthenticateResultDto
{
    public long UserId { get; set; }
    public string PasswordHash { get; set; }
    public string UserName { get; set; }
    public string UserNameAr { get; set; }
    public bool isActive { get; set; }
}

