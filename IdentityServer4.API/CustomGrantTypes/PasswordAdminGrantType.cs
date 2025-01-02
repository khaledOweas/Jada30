//using CSharpFunctionalExtensions;

//using Dapper;

//using IdentityServer4.API.Dto;
//using IdentityServer4.Models;
//using IdentityServer4.Validation;

//using Microsoft.Data.SqlClient;

//namespace IdentityServer4.API.CustomGrantType;

//public class AdminPasswordGrantValidator : IExtensionGrantValidator
//{
//    private readonly string SMCoreDbConnStr;
//    public string GrantType => CustomGrantTypes.Admins_PASSWORD;

//    public AdminPasswordGrantValidator(
//        IConfiguration configuration
//    )
//    {
//        SMCoreDbConnStr = configuration.GetConnectionString("Default");
//    }

//    public async Task ValidateAsync(ExtensionGrantValidationContext context)
//    {
//        var userName = context.Request.Raw.Get("username");
//        var password = context.Request.Raw.Get("password");

//        var result = await AuthenticateTeamClients(userName, password);
//        if (result.IsFailure)
//        {
//            context.Result = new GrantValidationResult(
//                TokenRequestErrors.InvalidRequest,
//                result.Error
//            );
//            return;
//        }
//        context.Result = result.Value;
//    }

//    public async Task<Result<GrantValidationResult>> AuthenticateTeamClients(
//    string? userName,
//    string? password
//)
//    {
//        const string ERROR_MESSAGE = "You have entered an incorrect username or password.";
//        if ((string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password)))
//            return Result.Failure<GrantValidationResult>(ERROR_MESSAGE);

//        await using var SMCoreDbConnection = new SqlConnection(SMCoreDbConnStr);

//        var userId = await SMCoreDbConnection.QueryFirstOrDefaultAsync<int>(
//            @"SELECT TOP 1 smUser.AllUserID
//                FROM smAllUser smUser
//                WHERE (smUser.UserName = @username) AND (smUser.Password = @password COLLATE Latin1_General_CS_AS)",
//            new { userName, password }
//        );
//        if (userId == 0)
//            return Result.Failure<GrantValidationResult>(ERROR_MESSAGE);

//        return Result.Success<GrantValidationResult>(
//            new GrantValidationResult(subject: userId.ToString(), authenticationMethod: CustomGrantTypes.Admins_PASSWORD)
//        );
//    }

//}