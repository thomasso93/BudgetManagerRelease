using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace BudgetManager.Model
{
    class Expense : Budget
    {
        public Expense() : base() {}

        public Expense(Expense exp) : base(exp) { }
    }
}
