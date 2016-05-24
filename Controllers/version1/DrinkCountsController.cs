using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using DrinkCounter.Models;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using DrinkCounter.ViewModels;
using System;

namespace DrinkCounter.Controllers
{
    [Route("api/v1/[controller]")]
    public class DrinkCountsController : Controller
    {
        private DrinkingData _context;

        public DrinkCountsController(DrinkingData context)
        {
            _context = context;
        }

        // GET: api/DrinkCounts
        [HttpGet]
        public IEnumerable<DrinkCount> GetAll()
        {
            return _context.DrinkCounts;
        }

        // GET api/DrinkCounts/[id]
        [HttpGet("{id}")]
        public AddDrinkViewModel GetByUserId(string id)
        {
            var result = _context.DrinkCounts.Single(a => a.UserId == id);

            AddDrinkViewModel viewModel = new AddDrinkViewModel
            {
                Amount = result.Amount,
                UserId = result.UserId,
                TypeId = result.TypeId
            };
            return viewModel;
        }


        // POST api/DrinkCounts
        [HttpPost]
        public int Post(AddDrinkViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //return "Failed";
                //returHttpBadRequest (ModelState);
                return 400;
            }

            DrinkCount counter = new DrinkCount
            {
                Amount = viewModel.Amount,
                Date = DateTime.Now,
                TypeId = viewModel.TypeId,
                UserId = viewModel.UserId             
            };

            _context.DrinkCounts.Add(counter);
            _context.SaveChanges();

            return counter.Id;
        }
    }
}
