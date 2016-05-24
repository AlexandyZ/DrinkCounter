using DrinkCounter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkCounter.ViewModels
{
    public class TypeViewModel
    {
        public IEnumerable<String> TypeName { get; set; }
        public IEnumerable<int> TypeId { get; set; }
    }
}
