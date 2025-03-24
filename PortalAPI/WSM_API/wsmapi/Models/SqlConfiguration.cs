public class SqlConfiguration
{
    public Dictionary<string, string> SqlStatements { get; set; } = new();
    public Dictionary<string, string> EndpointNames { get; set; } = new();

}
public class EndpointNamesConfig
{
    public Dictionary<string, string> EndpointNames { get; set; } = new();
}