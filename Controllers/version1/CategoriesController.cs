using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using DrinkCounter.Models;
using System.Linq;

namespace DrinkCounter.Controllers
{
    [Route("api/v1/[controller]")]
    public class CategoriesController : Controller
    {
        private DrinkingData _context;
        
        public CategoriesController(DrinkingData context)
        {
            _context = context;
        }

        // GET: api/v1/Categories
        [HttpGet]
        public IEnumerable<DrinkCategory> Get()
        {
            return _context.DrinkCategories;
        }

        // GET: api/v1/Categories/[id]
        [HttpGet("{id}")]
        public DrinkCategory Get(int id)
        {
            return _context.DrinkCategories.Single(x => x.Id == id);
        }
    }
}
