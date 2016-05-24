using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using DrinkCounter.Models;
using DrinkCounter.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DrinkCounter.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class TeamReportsController : Controller
    {

        private DrinkingData _context;

        public TeamReportsController(DrinkingData dataContext)
        {
            _context = dataContext;
        }

        // GET: api/Report
        [HttpGet]
        public IEnumerable<DrinkCount> Get()
        {
            return _context.DrinkCounts;
        }

        // GET api/reports/[id]
        //[HttpGet("{id}")]
        //public DrinkCountViewModel Get(string id, [FromBody] DrinkCount drinkCount)
        //{
        //    var result = _context.DrinkCounts.Single(a => a.UserId == id);
        //    drinkcountviewmodel = new DrinkCountViewModel
        //    {
        //        UserId = result.UserId,
        //        TypeId = result.TypeId,
        //        Date = result.Date,
        //        TotalAmount = result.Amount

        //    };
        //    return drinkcountviewmodel;
        //}

        //GET: /api/v1/teamreports/9
        [HttpGet("{ID}")]
        public ReportViewModel GetTeamByAmount(int id)
        {
            var result = (from tm in _context.TeamMembers
                          join ui in _context.UserInfos on tm.UserId equals ui.Id
                          join dc in _context.DrinkCounts on ui.Id equals dc.UserId
                          where tm.TeamId.Equals(id)
                          select new DrinkCount
                          {
                              Amount = dc.Amount,
                              Date = dc.Date
                          }).ToList();

            var t = new ReportViewModel
            {
                MyCount = result,
                Amount = result.Select(c => c.Amount),
                TotalAmount = result.Select(c => c.Amount).Sum()
            };
            return t;
        }

        //GET: /api/v1/teamreports/9/2016-02-24%2011:18:28.9824702/2016-04-18%2014:28:55.3521218
        [HttpGet("{id}/{startdate}/{enddate}")]
        public ReportViewModel GetTeamByDate(int id, DateTime startdate, DateTime enddate)
        {
            var result = (from tm in _context.TeamMembers
                          join ui in _context.UserInfos on tm.UserId equals ui.Id
                          join dc in _context.DrinkCounts on ui.Id equals dc.UserId
                          where tm.TeamId.Equals(id) && (dc.Date >= startdate && dc.Date <= enddate)
                          select new DrinkCount
                          {
                              Amount = dc.Amount,
                              Date = dc.Date
                          }).ToList();

            var t = new ReportViewModel
            {
                Date = result.Select(c => c.Date),
                //MyCount = result,
                Amount = result.Select(c => c.Amount),
                TotalAmount = result.Select(c => c.Amount).Sum()
            };
            return t;
        }

        //GET: /api/v1/report/9/1092
        //[HttpGet("{id}/{typeid}")]
        //public ReportViewModel GetTeamByTypeId(int id, int typeid)
        //{
        //    var result = (from tm in _context.TeamMembers
        //                  join ui in _context.UserInfos on tm.UserId equals ui.Id
        //                  join dc in _context.DrinkCounts on ui.Id equals dc.UserId
        //                  join dt in _context.DrinkTypes on dc.TypeId equals dt.DrinkTypeId
        //                  where tm.TeamId.Equals(id) && dc.TypeId.Equals(typeid)
        //                  select new                           {
        //                      AmountFromDC = dc.Amount,
        //                      NameFromDT = dt.DrinkName
        //                  }).ToList();

        //    var t = new ReportViewModel
        //    {
        //        DrinkName = result.Select(c => c.NameFromDT),
        //        Amount = result.Select(c => c.AmountFromDC),
        //        TotalAmount = result.Select(c => c.AmountFromDC).Sum()
        //    };
        //    return t;
        //}


        //GET: /api/v1/teamreports/9/1
        [HttpGet("{id}/{categoryid}")]
        public ReportViewModel GetTeamByCategoryId(int id, int categoryid)
        {
            var result = (from tm in _context.TeamMembers
                          join ui in _context.UserInfos on tm.UserId equals ui.Id
                          join dc in _context.DrinkCounts on ui.Id equals dc.UserId
                          join dt in _context.DrinkTypes on dc.TypeId equals dt.DrinkTypeId
                          join dct in _context.DrinkCategories on dt.DrinkCategoryId equals dct.Id
                          where tm.TeamId.Equals(id) && dt.DrinkCategoryId.Equals(categoryid)
                          select new
                          {
                              AmountFromDC = dc.Amount,
                              NameFromDCT = dct.Name
                          }).ToList();

            var t = new ReportViewModel
            {
                DrinkName = result.Select(c => c.NameFromDCT),
                Amount = result.Select(c => c.AmountFromDC),
                TotalAmount = result.Select(c => c.AmountFromDC).Sum()
            };
            return t;
        }

        [HttpGet("{id}/{categoryid}/{startdate}/{enddate}")]
        public ReportViewModel GetTeamByCategoryIdDate(int id, int categoryid, DateTime startdate, DateTime enddate)
        {
            var result = (from tm in _context.TeamMembers
                          join ui in _context.UserInfos on tm.UserId equals ui.Id
                          join dc in _context.DrinkCounts on ui.Id equals dc.UserId
                          join dt in _context.DrinkTypes on dc.TypeId equals dt.DrinkTypeId
                          join dct in _context.DrinkCategories on dt.DrinkCategoryId equals dct.Id
                          where (tm.TeamId.Equals(id) && dt.DrinkCategoryId.Equals(categoryid)) && (dc.Date >= startdate && dc.Date <= enddate)
                          select new
                          {
                              AmountFromDC = dc.Amount,
                              NameFromDCT = dct.Name,
                              Date = dc.Date,
                              Id = dct.Id,
                              DrinkName = dt.DrinkName
                          }).ToList();

            var t = new ReportViewModel
            {
                CategoryId = result.Select(c => c.Id),
                DrinkName = result.Select(c => c.NameFromDCT),
                Amount = result.Select(c => c.AmountFromDC),
                TotalAmount = result.Select(c => c.AmountFromDC).Sum(),
                Date = result.Select(c => c.Date),
                TypeName = result.Select(c => c.DrinkName)
            };
            return t;
        }

        //GET: /api/v1/report/9/gpscs2ern
        //[HttpGet("{teamid}/{userid}")]
        //public IQueryable<DrinkCount> GetTeamDateAmount(int teamid, string userid)
        //{
        //    var result = from tm in _context.TeamMembers
        //                 join ui in _context.UserInfos on tm.UserId equals ui.Id
        //                 join dc in _context.DrinkCounts on ui.Id equals dc.UserId
        //                 where ui.Id.Equals(userid) && tm.TeamId.Equals(teamid)
        //                 select new DrinkCount
        //                 {
        //                     Amount = dc.Amount,
        //                     Date = dc.Date
        //                 };

        //    return result;
        //}
    }
}
