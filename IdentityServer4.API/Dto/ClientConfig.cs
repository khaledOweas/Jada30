namespace IdentityServer4.API.Dto;

public class ClientConfig
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public List<string> AllowedScopes { get; set; }
    public List<string> AllowedGrantTypes { get; set; }
    public int? AccessTokenLifetime { get; set; }
    public int? RefreshTokenLifetime { get; set; }
    public bool? RequireClientSecret { get; set; }

    //------------------------------------------------------
    public List<string>? AllowedCorsOrigins { get; set; }
}
