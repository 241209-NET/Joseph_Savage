using Microsoft.AspNetCore.Mvc;
using PeriodicTable.API.Model;
using PeriodicTable.API.Service;

namespace PeriodicTable.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class PeriodicTableController : ControllerBase
{   
    private readonly IPeriodicTableService _periodicTableService;

    public PeriodicTableController(IPeriodicTableService PeriodicTableService)
    {
        _periodicTableService = PeriodicTableService;
    }

    [HttpGet]
    public IActionResult GetAllElements()
    {
        var ElementList = _periodicTableService.GetAllElements();        
        return Ok(ElementList);
    }

    [HttpPost]
    public IActionResult CreateNewElement(Element newElement)
    {
        var Element = _periodicTableService.CreateNewElement(newElement);
        return Ok(Element);
    }

    [HttpGet("{Enumber}")]
    public IActionResult GetElementByEnumber(int Enumber)
    {
        var findElement = _periodicTableService.GetElementByEnumber(Enumber);

        if(findElement is null) return NotFound();
        
        return Ok(findElement);
    }

    [HttpDelete]
    public IActionResult DeleteElement(int Enumber)
    {
        var deleteElement = _periodicTableService.DeleteElementByEnumber(Enumber);

        if(deleteElement is null) return NotFound();

        return Ok(deleteElement);
    }

    // [HttpDelete]
    // public IActionResult DeleteElement(int Enumber)
    // {

    // }
}