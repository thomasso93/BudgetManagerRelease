using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Base;
using BudgetManager.Model;

namespace BudgetManager.ViewModel
{
    class DisplayCategoryViewModel : ValidationObject
    {
        public static DisplayCategoryViewModel FromDisplayCategory(DisplayCategory dispCategory)
        {
            return new DisplayCategoryViewModel
            {
                _name = dispCategory.Name,
                _amount =dispCategory.Amount

            };
        }

        public DisplayCategoryViewModel() {}

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        private float _amount;
        public float Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                RaisePropertyChanged();
            }
        }

    }
}
