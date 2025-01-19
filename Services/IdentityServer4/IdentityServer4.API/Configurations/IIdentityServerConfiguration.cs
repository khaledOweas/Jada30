using IdentityServer4.Models;

namespace IdentityServer4.API.Configurations;

public interface IIdentityServerConfiguration
{
    IEnumerable<Client> GetClients();
    IEnumerable<ApiResource> GetApiResources();
    IEnumerable<IdentityResource> GetIdentityResources();
    IEnumerable<ApiScope> GetApiScopes();
}
