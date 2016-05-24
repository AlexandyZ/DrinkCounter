using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DrinkCounter.Models;
using DrinkCounter.ViewModels;

namespace DrinkCounter.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class DrinkTypesController : Controller
    {

        private DrinkingData _context;

        public DrinkTypesController(DrinkingData dataContext)
        {
            _context = dataContext;
        }

        // GET api/v1/categoryid
        [HttpGet("{CategoryId}")]
        public TypeViewModel GetTypeByCategotyId(int CategoryId)
        {
            var result = (from dt in _context.DrinkTypes
                          join dc in _context.DrinkCategories on dt.DrinkCategoryId equals dc.Id
                          where dt.DrinkCategoryId.Equals(CategoryId)
                          select new DrinkType
                          {
                             DrinkTypeId = dt.DrinkTypeId,
                             DrinkName = dt.DrinkName
                          }).ToList();

            var t = new TypeViewModel
            {
                TypeId = result.Select(c => c.DrinkTypeId),
                TypeName = result.Select(c => c.DrinkName)
            };

            return t;
        }
    }
}
