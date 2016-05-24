using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using DrinkCounter.Models;

namespace DrinkCounter.Controllers
{
    [Route("api/v1/[controller]")]
    public class ValuesController : Controller
    {
        private DrinkingData _context;


        public ValuesController(DrinkingData dataContext)
        {
            _context = dataContext;
        }
        
     
        // GET: api/values
        [HttpGet]
        public DrinkType Get()
        {
            return _context.DrinkTypes.Single(x => x.DrinkTypeId == 1002);
            //return new string[] { "Alex", "Ninew" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
