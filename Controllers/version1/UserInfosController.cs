using System.Linq;
using Microsoft.AspNet.Mvc;
using DrinkCounter.Models;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Http;
using DrinkCounter.ViewModels;

namespace DrinkCounter.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserInfosController : Controller
    {
        private DrinkingData _context;

        public UserInfosController(DrinkingData context)
        {
            _context = context;
        }

        // GET api/UserInfos/[id]
        [HttpGet("{id}")]
        public UserViewModel Get(string id)
        {
            var result = _context.UserInfos.Single(a => a.Id == id);
            UserViewModel userviewmodel = new UserViewModel
            {
                Id = result.Id,
                Firstname = result.Firstname,
                Lastname = result.Lastname,
                Address = result.Address,
                Age = result.Age,
                Gender = result.Gender
            };
            return userviewmodel;
        }

        private bool UserExists(string Userid)
        {
            return _context.UserInfos.Count(a => a.Id == Userid) > 0;
        }

        // POST: api/UserInfos
        [HttpPost]
        public async Task<IActionResult> PostUserInfo(UserViewModel userinfo)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
            var result = _context.UserInfos.Single(a => a.Id == userinfo.Id);
            result.Firstname = userinfo.Firstname;
            result.Lastname = userinfo.Lastname;
            result.Address = userinfo.Address;
            result.Age = userinfo.Age;
            result.Gender = userinfo.Gender;

            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(result.Id))
                {                   
                        return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }
    }
}
