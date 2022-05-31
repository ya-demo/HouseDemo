using HouseDemo.Core.Service.Interface;
using HouseDemo.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
namespace HouseDemo.API.Controllers;

[Route("api/[controller]")]
public class HouseController : ControllerBase
{
    private readonly IHouseService _service;

    public HouseController(IHouseService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost]
    public async Task<ActionResult<HouseResult>> Post([FromBody] HouseRequest request)
    {
        try
        {
            var result = await _service.AddHouse(request);
            return result;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}

