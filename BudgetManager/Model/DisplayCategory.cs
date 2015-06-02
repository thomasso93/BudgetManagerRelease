using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Model
{
    class DisplayCategory
    {
        private string _name;
        private float _amount;

        public DisplayCategory(string name, float amount)
        {
            Name = name;
            Amount = amount;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set 
            {
                _name = value;
            }
        }

        public float Amount 
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }

    }
}
