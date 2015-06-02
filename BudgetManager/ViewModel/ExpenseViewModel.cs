using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Base;
using BudgetManager.Model;

namespace BudgetManager.ViewModel
{
    class ExpenseViewModel : ValidationObject
    {
        public static ExpenseViewModel FromExpense(Expense expense)
        {
            return new ExpenseViewModel
            {
                _id = expense.Id,
                _name = expense.Name,
                _category = expense.Category,
                _amount = expense.Amount,
                _date = expense.Date //dodac przecinek po Amount
            };
        }

        public ExpenseViewModel()
        {
            Validators.Add("Name", p => string.IsNullOrWhiteSpace(Name) ? "Nazwa nie może być pusta" : null);
            Validators.Add("Category", p => string.IsNullOrWhiteSpace(Category) ? "Kategoria nie może być pusta" : null);
        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged();
               // RaiseErrorsChanged();
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
              //  RaiseErrorsChanged();
            }
        }

        private string _category;

        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                RaisePropertyChanged();
              //  RaiseErrorsChanged();
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
             //   RaiseErrorsChanged();
            }
        }
        
        private string _date;

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
              //  RaiseErrorsChanged();
            }
        }
        
    }
}
