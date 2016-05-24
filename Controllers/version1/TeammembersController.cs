using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using DrinkCounter.Models;
using DrinkCounter.ViewModels;

namespace DrinkCounter.Controllers
{
    [Route("api/v1/[controller]")]
    public class TeamMembersController : Controller
    {
        private DrinkingData _context;

        public TeamMembersController(DrinkingData context)
        {
            _context = context;
        }

        // GET api/v1/userid
        [HttpGet("{id}")]
        public List<TeamViewModel> Get(string id)
        {

            /* select teamid, t.name, count(*)
               from teammember tm join team t on t.id = tm.teamid 
               group by t.name, teamid
            */

            /*  select  t.id,t.name
                from userinfo ui inner join teammember tm on tm.userid = ui.id
                inner join team t on t.id = tm.teamid
                where ui.id ='ts7kpdpvz' */
            var result = (from tm in _context.TeamMembers
                          where tm.UserId.Equals(id)
                                && tm.Activated.Equals(true)
                          select new TeamViewModel
                          {
                              TeamId = tm.Team.Id,
                              TeamName = tm.Team.Name,
                              Date = tm.Team.CreateDate,
                              Activated = tm.Activated
                          }).Distinct().ToList();
            return result;
        }
    }
}
