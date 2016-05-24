using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DrinkCounter.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DrinkCounter.Controllers
{
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        private DrinkingData _context;

        public RegisterController(DrinkingData context)
        {
            _context = context;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        private bool UserExists(string id)
        {
            return _context.UserInfos.Count(e => e.Id == id) > 0;
        }
    }
}
