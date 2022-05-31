using HouseDemo.Common.PageExtention;
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
    public async Task<ActionResult<PageResult<HouseResult>>> Get([FromQuery] HouseQueryRequest request)
    {
        try
        {
            var result = await _service.GetHouses(request);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HouseResult>> Get(Guid id)
    {
        try
        {
            var result = await _service.GetHouse(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
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
    public async Task<ActionResult<HouseResult>> Put(Guid id, [FromBody] HouseRequest request)
    {
        try
        {
            HouseResult result = await _service.UpdateHouse(id, request);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        try
        {
            await _service.DeleteHouse(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}

