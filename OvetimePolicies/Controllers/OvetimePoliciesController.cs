using Microsoft.AspNetCore.Mvc;
using OvetimePolicies_api.Dtos;
using OvetimePolicies_api.Handlers;

namespace OvetimePolicies.Controllers;

[Route("{datatype}/[controller]")]
[ApiController]
public class OvetimePoliciesController : ControllerBase
{
    public OvetimePoliciesController()
    {

    }

    [HttpPost]
    public async Task<ActionResult> OvetimePolicies([FromBody] CommandDto command, [FromServices] AddSalaryHandler handler)
    {
        try
        {
            return Ok(handler.AddSalary(command));
        }
        catch (Exception)
        {
            return NoContent();
        }
    }


}
