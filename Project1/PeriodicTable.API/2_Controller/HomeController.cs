using Microsoft.AspNetCore.Mvc;
using PeriodicTable.API.Data;
using Microsoft.EntityFrameworkCore;
using PeriodicTable.API.Model;

namespace PeriodicTable.API.Controller
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly PeriodicTableContext _context;

        // Inject PeriodicTableContext through constructor
        public HomeController(PeriodicTableContext context)
        {
            _context = context;
        }

        // Retrieve and display all elements in the PeriodicTableDB
        [HttpGet]
        public async Task<IActionResult> Welcome()
        {
            try
            {
                var elements = await _context.Elements.ToListAsync();


                var groups = await _context.Groups.ToListAsync();

                var discoverers = await _context.Discoverers.ToListAsync();


                return Ok(new { Elements = elements, Groups = groups, Discoverers = discoverers });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }

}