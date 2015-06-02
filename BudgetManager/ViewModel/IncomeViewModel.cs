using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Base;
using BudgetManager.Model;

namespace BudgetManager.ViewModel
{
    class IncomeViewModel : ValidationObject
    {
        public static IncomeViewModel FromIncome(Income income)
        {
            return new IncomeViewModel
            {
                _id = income.Id,
                _name = income.Name,
                _category = income.Category,
                _amount = income.Amount,
                _date = income.Date
            };
        }

        public IncomeViewModel()
        {
            Validators.Add("Name", p => string.IsNullOrWhiteSpace(Name) ? "Nazwa nie może być pusta" : null);
            Validators.Add("Category", p => string.IsNullOrWhiteSpace(Category) ? "Kategoria nie może być pusta" : null);
        }

        private int _id;
        private string _name;
        private string _category;
        private float _amount;
        private string _date;


        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                RaisePropertyChanged();
            }
        }

        public float Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                RaisePropertyChanged();
            }
        }
        
        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                RaisePropertyChanged();
            }
        }
    }
}
