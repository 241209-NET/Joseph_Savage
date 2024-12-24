using Microsoft.AspNetCore.Mvc;
using PeriodicTable.API.Data;
using Microsoft.EntityFrameworkCore;

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

        // Example of returning data from the database (e.g., a list of elements)
        [HttpGet]
        public IActionResult Welcome()
        {
            // Retrieve data from the 'Elements' table in the database
            //var elements = _context.Elements.GetAllElements();
            var elements = _context.Elements.ToList();

            // Return the list of elements as JSON
            return Ok("Hello");
        }
    }
}