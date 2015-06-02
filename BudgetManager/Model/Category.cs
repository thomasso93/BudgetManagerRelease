using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Model
{
    class Category
    {
        public static List<string> _categories = new List<string> 
        {
            "Sport", "Rozrywka", "Nauka", "Żywność", "Transport", "Opłaty stałe", "Inne", "Rehabilitacja",
            "Turnusy na ranczo", "Zachcianki" 
        } ;

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
