using Microsoft.AspNetCore.Mvc;
using OvetimePolicies_Core.Dtos;
using OvetimePolicies_Data.Handlers;

namespace OvetimePolicies_api.Controllers;

[Route("{datatype}/[controller]/")]
[ApiController]
public class OvetimePoliciesController : ControllerBase
{
    public OvetimePoliciesController()
    {

    }

    [HttpPost("add")]
    public async Task<ActionResult> OvetimePolicies([FromBody] AddCommandDto command, [FromServices] AddSalaryHandler handler)
    {
        try
        {
            return Ok(handler.AddSalary(command));
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPost("edit")]
    public async Task<ActionResult> EditSalary([FromBody] EditPersonDto command, [FromServices] EditSalaryHandler handler)
    {
        try
        {
            return Ok(handler.Handle(command));
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPost("delete/{id}")]
    public async Task<ActionResult> DeleteSalary([FromRoute] Guid id, [FromServices] DeleteSalaryHandler handler)
    {
        try
        {
            return Ok(handler.Handle(id));
        }
        catch
        {
            return NoContent();
        }
    }

}
