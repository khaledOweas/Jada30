namespace IdentityServer4.API.Dto;
public class IdentityProviderSettings
{
    public List<ClientConfig> Clients { get; set; }
    public List<ApiResourceConfig> ApiResources { get; set; }
    public List<string> ApiScopes { get; set; }
}
