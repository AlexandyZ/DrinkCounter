using DrinkCounter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkCounter.ViewModels
{
    public class ReportViewModel
    {
        public string UserId { get; set; }
        public int TeamId { get; set; }
        public IEnumerable<int> CategoryId { get; set; }
        public int TypeId { get; set; }
        public int TotalAmount { get; set; }
        public List<DrinkCount> MyCount { get; set; }
        public IEnumerable<int> Amount { get; set; }
        public IEnumerable<DateTime> Date { get; set; }
        public IEnumerable<String> DrinkName { get; set; }
        public IEnumerable<String> TypeName { get; set; }


    }
}