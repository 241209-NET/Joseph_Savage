using Microsoft.AspNetCore.Mvc;
using PeriodicTable.API.Model;
using PeriodicTable.API.Service;

namespace PeriodicTable.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{   
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public IActionResult GetAllGroups()
    {
        var GroupList = _groupService.GetAllGroups();        
        return Ok(GroupList);
    }


    [HttpGet("{Gnumber}")]
    public IActionResult GetGroupByGnumber(int Gnumber)
    {
        var findGroup = _groupService.GetGroupByGnumber(Gnumber);

        if(findGroup is null) return NotFound();
        
        return Ok(findGroup);
    }



    // [HttpDelete]
    // public IActionResult DeleteElement(int Enumber)
    // {

    // }
}