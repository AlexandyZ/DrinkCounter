using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DrinkCounter.Models;
using DrinkCounter.ViewModels;


namespace DrinkCounter.Controllers
{
    [Route("api/v1/[controller]")]
    public class PersonalReportsController : Controller
    {
        private DrinkingData _context;

        public PersonalReportsController(DrinkingData dataContext)
        {
            _context = dataContext;
        }

        // GET api/v1/personalreports/ts7kpdpvz
        [HttpGet("{id}")]
        public ReportViewModel GetAmountByUserId(string id)
        {
            var result = (from dc in _context.DrinkCounts
                          join dt in _context.DrinkTypes on dc.TypeId equals dt.DrinkTypeId
                          where dc.UserId.Equals(id)
                          select new 
                          {
                              AmountFromDC = dc.Amount,
                            NameFromDT = dt.DrinkName
                             
                          }).ToList();

            var t = new ReportViewModel
            {
                 DrinkName = result.Select(c => c.NameFromDT),
                Amount = result.Select(c => c.AmountFromDC),
                TotalAmount = result.Select(c => c.AmountFromDC).Sum()

            };

            return t;
        }

        // GET api/v1/personalreports/ts7kpdpvz/2016-03-31%2001:25:59.7338745/2016-05-31%2001:25:59.7338745
        [HttpGet("{id}/{startdate}/{enddate}")]
        public ReportViewModel GetAmountByDate(string id, DateTime startdate, DateTime enddate)
        {
            var result = (from dt in _context.DrinkCounts
                          where dt.UserId.Equals(id) && (dt.Date >= startdate && dt.Date <= enddate)
                          select new DrinkCount
                          {
                              Amount = dt.Amount,
                              Date = dt.Date

                          }).ToList();

            var t = new ReportViewModel
            {   Date =  result.Select(c => c.Date),
                Amount = result.Select(c => c.Amount),
                TotalAmount = result.Select(c => c.Amount).Sum()

            };

            return t;
        }

        // GET api/v1/personalreports/ts7kpdpvz/1074
        //[HttpGet("{id}/{typeid}")]
        //public ReportViewModel GetAmountByTypeId(string id, int typeid)
        //{
        //    var result = (from dt in _context.DrinkCounts
        //                  where dt.UserId.Equals(id) && dt.TypeId.Equals(typeid)
        //                  select new DrinkCount
        //                  {
        //                      Amount = dt.Amount
        //                  }).ToList();

        //    var t = new ReportViewModel
        //    {
        //        Amount = result.Select(c => c.Amount),
        //        TotalAmount = result.Select(c => c.Amount).Sum()

        //    };

        //    return t;
        //}

        // GET api/v1/personalreports/ts7kpdpvz/1
        [HttpGet("{id}/{categoryid}")]
        public ReportViewModel GetAmountByCategoryId(string id, int categoryid)
        {
            var result = (from dc in _context.DrinkCounts
                          join dt in _context.DrinkTypes on dc.TypeId equals dt.DrinkTypeId
                          join dct in _context.DrinkCategories on dt.DrinkCategoryId equals dct.Id
                          where dc.UserId.Equals(id) && dt.DrinkCategoryId.Equals(categoryid)
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
        public ReportViewModel GetAmountByCategoryIdDate(string id, int categoryid, DateTime startdate, DateTime enddate)
        {
            var result = (from dc in _context.DrinkCounts
                          join dt in _context.DrinkTypes on dc.TypeId equals dt.DrinkTypeId
                          join dct in _context.DrinkCategories on dt.DrinkCategoryId equals dct.Id
                          where (dc.UserId.Equals(id) && dt.DrinkCategoryId.Equals(categoryid)) && (dc.Date >= startdate && dc.Date <= enddate)
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
    }
}
