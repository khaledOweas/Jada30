using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

public interface IDatabaseService
{
    Task<IEnumerable<dynamic>> ExecuteQueryAsync(string statementKey

    , string param1 = "", string param2 = ""
    , string param3 = "", string param4 = ""
    );
}
public class DatabaseService : IDatabaseService
{
    private readonly string _connectionString;
    private readonly Dictionary<string, string> _sqlStatements;

    public DatabaseService(
        IConfiguration config,
        IOptions<SqlConfiguration> sqlConfig)
    {
        _connectionString = config.GetConnectionString("DynamicDb");
        _sqlStatements = config.GetSection("SqlStatements").Get<Dictionary<string, string>>();

        // Optional: Verify statements loaded
        if (_sqlStatements.Count == 0)
        {
            throw new InvalidOperationException("No SQL statements loaded from configuration");
        }
    }

    public async Task<IEnumerable<dynamic>> ExecuteQueryAsync(string statementKey
    , string param1 = "", string param2 = ""
    , string param3 = "", string param4 = ""
    )
    {
        if (!_sqlStatements.TryGetValue(statementKey, out var sql))
            throw new KeyNotFoundException($"SQL statement {statementKey} not found");
        if (sql != null)
        {
            sql = param1 != "" ? sql.Replace("{param1}", param1) : sql;
            sql = param2 != "" ? sql.Replace("{param2}", param2) : sql;
            sql = param3 != "" ? sql.Replace("{param3}", param3) : sql;
            sql = param4 != "" ? sql.Replace("{param4}", param4) : sql;
        }
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        return await connection.QueryAsync(sql);
    }
}