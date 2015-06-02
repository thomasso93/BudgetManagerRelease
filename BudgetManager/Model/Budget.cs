using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Model
{
    [DataContract]
    class Budget
    {

        public Budget() { }

        public Budget(Budget budget) 
        {
            Id = budget.Id;
            Name = budget.Name;
            Amount = budget.Amount;
            Category = budget.Category;
            Date = budget.Date;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public float Amount { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public string Date { get; set; }
    }
}
