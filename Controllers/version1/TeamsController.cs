using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using DrinkCounter.Models;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Http;
using DrinkCounter.ViewModels;
using System;

namespace DrinkCounter.Controllers
{
    [Route("api/v1/[controller]")]
    public class TeamsController : Controller
    {
        private DrinkingData _context;

        public TeamsController(DrinkingData context)
        {
            _context = context;
        }

        // GET: api/Teams
        [HttpGet]
        public List<TeamViewModel> Get()
        {
            var result = (from tm in _context.TeamMembers
                          select new TeamViewModel
                          {
                              TeamId = tm.Team.Id,
                              TeamName = tm.Team.Name,
                              Date = tm.Team.CreateDate,
                              //Activated = tm.Activated
                          }).Distinct().ToList();
            return result;
        }

        // GET api/Teams/name
        [HttpGet("{name}")]
        public List<TeamViewModel> Get(string name)
        {
            var result = (from tm in _context.TeamMembers
                          where tm.Team.Name.Contains(name)
                          select new TeamViewModel
                          {
                              TeamId = tm.Team.Id,
                              TeamName = tm.Team.Name,
                              Date = tm.Team.CreateDate,
                          }).Distinct().ToList();

            //var result = (from tm in _context.TeamMembers
            //              where tm.Team.Name.Equals(name)
            //              group new { tm.Team, tm } by new
            //              {
            //                  tm.Team.Name,
            //                  tm.Team.Id
            //              } into g
            //              select new TeamViewModel
            //              {
            //                  TeamId = g.Key.TeamId,
            //                  TeamName = g.Key.Name,
            //                  Size = g.Count()
            //              }).ToList();  

            return result;
        }

        // POST api/Teams
        [HttpPost]
        public int Post(TeamViewModel tv)
        {
            if (!ModelState.IsValid)
            {
                return 400;
            }

            if (tv.TeamId == 0)
            {
                Team t = new Team();
                t.Name = tv.TeamName;
                t.CreateDate = DateTime.Now;

                if (!TeamExists(tv.TeamName))
                {
                    _context.Teams.Add(t);
                    _context.SaveChanges();
                    var id = _context.Teams.Single(a => a.Name == tv.TeamName).Id;

                    TeamMember tm = new TeamMember();
                    tm.UserId = tv.UserId;
                    tm.TeamId = id;
                    tm.Activated = true;

                    _context.TeamMembers.Add(tm);
                }
                else
                {
                    return 409;
                }

            }
            else
            {
                if (TeamMemberExists(tv.UserId, tv.TeamId))
                {
                    var t = _context.TeamMembers.AsNoTracking().Single(e => e.UserId == tv.UserId && e.TeamId == tv.TeamId);
                    TeamMember tm = new TeamMember();
                    tm.UserId = tv.UserId;
                    tm.TeamId = tv.TeamId;
                    tm.Activated = (t.Activated != true) ? true : false;
                    _context.Entry(tm).State = EntityState.Modified;
                }
                else
                {
                    TeamMember tm = new TeamMember();
                    tm.UserId = tv.UserId;
                    tm.TeamId = tv.TeamId;
                    tm.Activated = true;

                    _context.TeamMembers.Add(tm);
                }
            }
            _context.SaveChangesAsync();

            return 200;
        }
        private bool TeamExists(string name)
        {
            return _context.Teams.Count(e => e.Name == name) > 0;
        }

        private bool TeamMemberExists(string id, int tmid)
        {
            return _context.TeamMembers.Count(e => e.TeamId == tmid && e.UserId == id) > 0;
        }
    }
}
