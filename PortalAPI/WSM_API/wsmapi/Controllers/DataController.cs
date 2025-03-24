using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

[ApiController]
[Route("api/data")]
public class DataController : ControllerBase
{
    private readonly IDatabaseService _dbService;
    private readonly IOptions<SqlConfiguration> _config;

    public DataController(IDatabaseService dbService, IOptions<SqlConfiguration> config)
    {
        _dbService = dbService;
        _config = config;
    }

    [HttpGet("Endpoint1")]
    public async Task<IActionResult> GetEndpoint1()
    {
        var result = await _dbService.ExecuteQueryAsync("Endpoint1");
        return Ok(result);
    }

    [HttpGet("Endpoint2")]
    public async Task<IActionResult> GetEndpoint2()
    {
        var result = await _dbService.ExecuteQueryAsync("Endpoint2");
        return Ok(result);
    }

    [HttpGet("Endpoint3")]
    public async Task<IActionResult> GetEndpoint3()
    {
        var result = await _dbService.ExecuteQueryAsync("Endpoint3");
        return Ok(result);
    }

    [HttpGet("Endpoint4")]
    public async Task<IActionResult> GetEndpoint4()
    {
        var result = await _dbService.ExecuteQueryAsync("Endpoint4");
        return Ok(result);
    }
    [HttpGet("Endpoint5")]
    public async Task<IActionResult> GetEndpoint5()
    {
        var result = await _dbService.ExecuteQueryAsync("Endpoint5");
        return Ok(result);
    }
    [HttpGet("Endpoint6")]
    public async Task<IActionResult> GetEndpoint6()
    {
        var result = await _dbService.ExecuteQueryAsync("Endpoint6");
        return Ok(result);
    }
    [HttpGet("Endpoint7")]
    public async Task<IActionResult> GetEndpoint7()
    {
        var result = await _dbService.ExecuteQueryAsync("Endpoint7");
        return Ok(result);
    }
    [HttpGet("Endpoint8")]
    public async Task<IActionResult> GetEndpoint8()
    {
        var result = await _dbService.ExecuteQueryAsync("Endpoint8");
        return Ok(result);
    }
    [HttpGet("Endpoint9")]
    public async Task<IActionResult> GetEndpoint9()
    {
        var result = await _dbService.ExecuteQueryAsync("Endpoint9");
        return Ok(result);
    }
    [HttpGet("Endpoint10")]
    public async Task<IActionResult> GetEndpoint10()
    {
        var result = await _dbService.ExecuteQueryAsync("Endpoint10");
        return Ok(result);
    }

    [HttpGet("endpoint11")]
    public async Task<IActionResult> GetEndpoint11([FromQuery] string param1)
    {
        var result = await _dbService.ExecuteQueryAsync("Endpoint11", param1);
        return Ok(result);
    }

    [HttpGet("endpoint12")]
    public async Task<IActionResult> GetEndpoint12([FromQuery] string param1, [FromQuery] string param2)
    {
        var result = await _dbService.ExecuteQueryAsync("Endpoint12", param1, param2);
        return Ok(result);
    }

    [HttpGet("endpoint13")]
    public async Task<IActionResult> GetEndpoint13([FromQuery] string param1, [FromQuery] string param2, [FromQuery] string param3)
    {
        var result = await _dbService.ExecuteQueryAsync("Endpoint13", param1, param2, param3);
        return Ok(result);
    }
}