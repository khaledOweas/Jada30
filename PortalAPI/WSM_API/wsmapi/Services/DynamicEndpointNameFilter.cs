using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class DynamicEndpointNameFilter : IOperationFilter
{

    private readonly Dictionary<string, string> _endpointNames;

    public DynamicEndpointNameFilter(IConfiguration config)
    {

        _endpointNames = config.GetSection("EndpointNames").Get<Dictionary<string, string>>();

    }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var route = context.ApiDescription.RelativePath;
        var endpointKey = route.Split('/').Last();

        if (_endpointNames.TryGetValue(endpointKey, out var displayName))
        {
            operation.Summary = displayName;
            operation.OperationId = displayName;
        }
    }
}