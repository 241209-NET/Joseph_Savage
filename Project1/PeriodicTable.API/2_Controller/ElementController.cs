using Microsoft.AspNetCore.Mvc;
using PeriodicTable.API.Model;
using PeriodicTable.API.Service;

namespace PeriodicTable.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class ElementController : ControllerBase
{   
    private readonly IElementService _elementService;

    public ElementController(IElementService elementService)
    {
        _elementService = elementService;
    }

    [HttpGet]
    public IActionResult GetAllElements()
    {
        var ElementList = _elementService.GetAllElements();        
        return Ok(ElementList);
    }

    [HttpPost]
    public IActionResult CreateNewElement([FromBody] Element newElement)
    {
        var Element = _elementService.CreateNewElement(newElement);
        return Ok(Element);
    }

    [HttpGet("number/{Enumber}")]
    public IActionResult GetElementByEnumber([FromRoute] int Enumber )
    {
        var findElement = _elementService.GetElementByEnumber(Enumber);

        if(findElement is null) return NotFound();
        
        return Ok(findElement);
    }

    [HttpGet("name/{name}")]
    public IActionResult GetElementByName([FromRoute] string name )
    {
        var findElement = _elementService.GetElementByName(name);

        if(findElement is null) return NotFound();
        
        return Ok(findElement);
    }

    [HttpDelete]
    public IActionResult DeleteElement(int Enumber)
    {
        var deleteElement = _elementService.DeleteElementByEnumber(Enumber);

        if(deleteElement is null) return NotFound();

        return Ok(deleteElement);
    }


}