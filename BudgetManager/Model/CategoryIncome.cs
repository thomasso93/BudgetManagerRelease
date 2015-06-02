using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Model
{
    class CategoryIncome 
    {
        public static List<string> _categories = new List<string> 
        {
            "Wypłata", "Premia", "Nagroda", "Haracz", "Łapówka", "Okup", "Zdrapka za 2zł",
            "Łup", "Spadek", "Skarb piratów", "Rabunek" 
        };

        public List<string> Categories
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
            }
        }
    }
}
