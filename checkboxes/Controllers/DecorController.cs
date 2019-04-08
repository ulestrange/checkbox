using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkboxes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace checkboxes.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DecorController : Controller
    {

        private readonly MyContext _context;

        public DecorController(MyContext context)
        {
            _context = context;

        }
        // GET: /<controller>/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Decor>>> GetDecors()
        {
            return await _context.Decors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Decor>> GetDecor(int id)
        {
            var decor = await _context.Decors.FindAsync(id);

            if (decor == null)
            {
                return NotFound();
            }

            return decor;
        }

    }
}
