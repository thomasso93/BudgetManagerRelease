using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Model
{
    class Income : Budget
    {
        public Income() : base() { }

        public Income(Income inc) : base(inc) { }
    }
}
