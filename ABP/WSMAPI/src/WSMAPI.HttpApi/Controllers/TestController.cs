using WSMAPI.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using System;

namespace WSMAPI.Controllers;

[ApiController]
[Route("api/test")]
[Produces("application/json")]
public class TestController : AbpController
{
    /// <summary>
    /// Returns a simple hello message.
    /// </summary>
    [HttpGet("hello")]
    [ProducesResponseType(typeof(string), 200)]
    public ActionResult<string> GetHello()
    {
        return "Hello from ABP!";
    }

 
}