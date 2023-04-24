using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OvetimePolicies_api.Dto;

namespace OvetimePolicies.Controllers;

[Route("{datatype}/[controller]")]
[ApiController]
public class OvetimePoliciesController : ControllerBase
{
    public OvetimePoliciesController()
    {

    }

    [HttpPost]
    public async Task<ActionResult> add([FromBody] PersonDto data)
    {
        return Ok();
    }

}
