using Microsoft.AspNetCore.Mvc;
using PeriodicTable.API.Model;
using PeriodicTable.API.Service;

namespace PeriodicTable.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class DiscovererController : ControllerBase
{   
    private readonly IDiscovererService _discovererService;

    public DiscovererController(IDiscovererService DiscovererService)
    {
        _discovererService = DiscovererService;
    }

    [HttpGet]
    public IActionResult GetAllDiscoverers()
    {
        var DiscovererList = _discovererService.GetAllDiscoverers();        
        return Ok(DiscovererList);
    }

    [HttpPost]
    public IActionResult CreateNewDiscoverer([FromBody] Discoverer newDiscoverer)
    {
        var Discoverer = _discovererService.CreateNewDiscoverer(newDiscoverer);
        return Ok(Discoverer);
    }

    [HttpGet("{Did}")]
    public IActionResult GetDiscovererByDid(int Did)
    {
        var findDiscoverer = _discovererService.GetDiscovererById(Did);

        if(findDiscoverer is null) return NotFound();
        
        return Ok(findDiscoverer);
    }

    [HttpGet("name/{Lname}")]
    public IActionResult GetDiscovererByLastName(string Lname)
    {
        var findDiscoverer = _discovererService.GetDiscovererByLastName(Lname);

        if(findDiscoverer is null) return NotFound();
        
        return Ok(findDiscoverer);
    }


    [HttpGet("element/{number}")]
    public IActionResult GetDiscovererOfElement(int number)
    {
        var findDiscoverer = _discovererService.GetDiscovererOfElement(number);

        if(findDiscoverer is null) return NotFound();
        
        return Ok(findDiscoverer);
    }

    [HttpDelete]
    public IActionResult DeleteDiscovererByDid(int Did)
    {
        var deleteDiscoverer = _discovererService.DeleteDiscovererById(Did);

        if(deleteDiscoverer is null) return NotFound();

        return Ok(deleteDiscoverer);
    }

}