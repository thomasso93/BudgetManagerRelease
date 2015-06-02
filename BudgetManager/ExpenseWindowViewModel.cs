using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Base;
using BudgetManager.Model;
using BudgetManager.Services;
using BudgetManager.ViewModel;

namespace BudgetManager
{
    class ExpenseWindowViewModel : NotificationObject
    {

        #region Collections 
        private ObservableCollection<ExpenseViewModel> _expenses = new ObservableCollection<ExpenseViewModel>();
        public ObservableCollection<ExpenseViewModel> Expenses
        {
            get
            {
                return _expenses;
            }
            set
            {
                _expenses = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<DisplayCategoryViewModel> _displayExpenseCategories = new ObservableCollection<DisplayCategoryViewModel>();
        public ObservableCollection<DisplayCategoryViewModel> DisplayExpenseCategories
        {
            get
            {
                return _displayExpenseCategories;
            }
            set
            {
                _displayExpenseCategories = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<DisplayCategoryViewModel> _displayIncomeCategories = new ObservableCollection<DisplayCategoryViewModel>();
        public ObservableCollection<DisplayCategoryViewModel> DisplayIncomeCategories
        {
            get
            {
                return _displayIncomeCategories;
            }
            set
            {
                _displayIncomeCategories = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<ExpenseViewModel> _expensesYear = new ObservableCollection<ExpenseViewModel>();
        public ObservableCollection<ExpenseViewModel> ExpensesYear
        {
            get
            {
                return _expensesYear;
            }
            set
            {
                _expensesYear = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<IncomeViewModel> _incomesYear = new ObservableCollection<IncomeViewModel>();
        public ObservableCollection<IncomeViewModel> IncomesYear
        {
            get
            {
                return _incomesYear;
            }
            set
            {
                _incomesYear = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<IncomeViewModel> _incomes = new ObservableCollection<IncomeViewModel>();
        public ObservableCollection<IncomeViewModel> Incomes
        {
            get
            {
                return _incomes;
            }
            set
            {
                _incomes = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ViewModels
        private ExpenseViewModel _selectedExpense;
        public ExpenseViewModel SelectedExpense
        {
            get { return _selectedExpense; }
            set
            {
                _selectedExpense = value;
                var expense = SelectedExpense;
                ExpenseName = expense.Name;
                CategoryName = expense.Category;
                AmountValue = expense.Amount;
                DateValue = expense.Date;
                RaisePropertyChanged();
            }
        }

        private IncomeViewModel _selectedIncome;
        public IncomeViewModel SelectedIncome
        {
            get { return _selectedIncome; }
            set
            {
                _selectedIncome = value;
                var income = SelectedIncome;
                IncomeName = income.Name;
                CategoryIncomeName = income.Category;
                AmountIncomeValue = income.Amount;
                DateValue = income.Date;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Loaders etc.
        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                RaisePropertyChanged();
                LoadExpenseData.RaiseCanExecuteChanged();
            }
        }

        private bool _isLoadingIncomes;
        public bool IsLoadingIncomes
        {
            get
            {
                return _isLoadingIncomes;
            }
            set
            {
                _isLoadingIncomes = value;
                RaisePropertyChanged();
                LoadIncomeData.RaiseCanExecuteChanged();
            }
        }

        private bool _wasLoaded = false;
        public bool WasLoaded
        {
            get
            {
                return _wasLoaded;
            }
            set
            {
                _wasLoaded = value;
            }
        }

        private bool CanLoad(object _)
        {
            return !IsLoading;
        }

        private bool CanLoadIncomes(object _)
        {
            return !IsLoadingIncomes;
        }

        #endregion

        #region Commands 
        private BasicCommand _loadExpenseData;
        public BasicCommand LoadExpenseData
        {
            get
            {
                return _loadExpenseData ?? (_loadExpenseData = new BasicCommand(OnExpenseLoad, CanLoad));
            }
        }

        private BasicCommand _loadIncomeData;
        public BasicCommand LoadIncomeData
        {
            get
            {
                return _loadIncomeData ?? (_loadIncomeData = new BasicCommand(OnIncomeLoad, CanLoadIncomes));
            }
        }

        private BasicCommand _newExpenseCommand;
        public BasicCommand NewExpenseCommand
        {
            get
            {
                return _newExpenseCommand ?? (_newExpenseCommand = new BasicCommand(OnNewExpense));
            }
        }

        private BasicCommand _newIncomeCommand;
        public BasicCommand NewIncomeCommand
        {
            get
            {
                return _newIncomeCommand ?? (_newIncomeCommand = new BasicCommand(OnNewIncome));
            }
        }

        private BasicCommand _editData;
        public BasicCommand EditData
        {
            get { return _editData ?? (_editData = new BasicCommand(OnEditExpense)); }
        }

        private BasicCommand _showCommand;
        public BasicCommand ShowCommand
        {
            get { return _showCommand ?? (_showCommand = new BasicCommand(OnShowCommand)); }
        }
        #endregion

        #region Command Executions

        private void OnExpenseLoad(object _)
        {
            IsLoading = true;
            // if (!_wasLoaded)
            //{
            Task<List<Expense>>.Factory.StartNew(
                () =>
                {
                    return ExpenseService.getExpenses();
                },
                TaskCreationOptions.LongRunning)
            .ContinueWith(
                task =>
                {
                    foreach (var expense in task.Result)
                    {
                        Expenses.Add(ExpenseViewModel.FromExpense(expense));
                    }
                    IsLoading = false;
                    WasLoaded = true;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            //}
        }

        private void OnIncomeLoad(object _)
        {
            IsLoadingIncomes = true;
         
            Task<List<Income>>.Factory.StartNew(
                () =>
                {
                    return IncomeService.getIncomes();
                },
                TaskCreationOptions.LongRunning)
            .ContinueWith(
                task =>
                {
                    foreach (var income in task.Result)
                    {
                        Incomes.Add(IncomeViewModel.FromIncome(income));
                    }
                    IsLoading = false;
                    WasLoaded = true;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            
        }

        private void OnNewExpense(object _)
        {
            var expense = new ExpenseViewModel
            {
                Id = Expenses.Count > 0 ? Expenses.Max(e => e.Id) + 1 : 1,
                Name = ExpenseName,
                Amount = AmountValue,
                Category = CategoryName,
                Date = DateValue
             };

            Expense expenseToWrite = new Expense
            {
                Id = expense.Id,
                Name = ExpenseName,
                Amount = AmountValue,
                Category = CategoryName,
                Date = DateValue
            };

            if (String.IsNullOrEmpty(expense.Date))
                expense.Date = DateTime.Now.ToShortDateString();

            if (!(expense.Category == null) && !(expense.Name == null))
            {
                Expenses.Add(expense);
                ExpenseService.saveExpense(expenseToWrite);
            }
                //SelectedExpense = expense;
        }

        private void OnNewIncome(object _)
        {
            var income = new IncomeViewModel
            {
                Id = Incomes.Count > 0 ? Incomes.Max(e => e.Id) + 1 : 1,
                Name = IncomeName,
                Amount = AmountIncomeValue,
                Category = CategoryIncomeName,
                Date = DateIncomeValue
            };

            Income incomeToWrite = new Income
            {
                Id = income.Id,
                Name = IncomeName,
                Amount = AmountIncomeValue,
                Category = CategoryIncomeName,
                Date = DateIncomeValue
            };

            if (String.IsNullOrEmpty(income.Date))
                income.Date = DateTime.Now.ToShortDateString();

           // if (!(income.Category == null) && !(income.Name == null))
           // {
                Incomes.Add(income);
                IncomeService.saveIncome(incomeToWrite);
            //}
        }

        private void OnEditExpense(object _)
        {

            var expense = SelectedExpense;
            Expense expenseToEdit = new Expense
            {
                Id = expense.Id,
                Name = ExpenseName,
                Amount = AmountValue,
                Category = CategoryName,
                Date = DateValue
            };

            ExpenseService.editExpense(expenseToEdit);
            SelectedExpense = expense;
        }

        private void OnShowCommand(object _)
        {
            showMostExpensiveThisYear();
            showExpenseSumByCategory();
            showIncomesSumByCategory();
            showBiggestIncomesThisYear();
        }
        #endregion

        #region Helper Methods

        private void showMostExpensiveThisYear() 
        {
            Task<List<Expense>>.Factory.StartNew(
                () =>
                {
                    return StatisticService.getYearExpenses();
                },
                TaskCreationOptions.LongRunning)
            .ContinueWith(
                task =>
                {
                    foreach (var expense in task.Result)
                    {
                        ExpensesYear.Add(ExpenseViewModel.FromExpense(expense));
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void showBiggestIncomesThisYear()
        {
            Task<List<Income>>.Factory.StartNew(
                () =>
                {
                    return StatisticService.getYearIncome();
                },
                TaskCreationOptions.LongRunning)
            .ContinueWith(
                task =>
                {
                    foreach (var income in task.Result)
                    {
                        IncomesYear.Add(IncomeViewModel.FromIncome(income));
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void showExpenseSumByCategory()
        {
            Task<List<DisplayCategory>>.Factory.StartNew(
                    () =>
                    {
                        return StatisticService.getExpensesByCategory();
                    },
                    TaskCreationOptions.LongRunning)
                .ContinueWith(
                    task =>
                    {
                        foreach (var category in task.Result)
                        {
                            DisplayExpenseCategories.Add(DisplayCategoryViewModel.FromDisplayCategory(category));
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void showIncomesSumByCategory()
        {
            Task<List<DisplayCategory>>.Factory.StartNew(
                    () =>
                    {
                        return StatisticService.getIncomesByCategory();
                    },
                    TaskCreationOptions.LongRunning)
                .ContinueWith(
                    task =>
                    {
                        foreach (var category in task.Result)
                        {
                            DisplayIncomeCategories.Add(DisplayCategoryViewModel.FromDisplayCategory(category));
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion

        #region Fields
        private String _expenseName;
        public String ExpenseName
        {
            get
            {
                return _expenseName;
            }
            set
            {
                _expenseName = value;
                RaisePropertyChanged();
            }
        }

        private String _incomeName;
        public String IncomeName
        {
            get
            {
                return _incomeName;
            }
            set
            {
                _incomeName = value;
                RaisePropertyChanged();
            }
        }

        private String _categoryName;
        public String CategoryName
        {
            get
            {
                return _categoryName;
            }
            set
            {
                _categoryName = value;
                RaisePropertyChanged();
            }
        }

        private String _categoryIncomeName;
        public String CategoryIncomeName
        {
            get
            {
                return _categoryIncomeName;
            }
            set
            {
                _categoryIncomeName = value;
                RaisePropertyChanged();
            }
        }

        private float _amountValue;
        public float AmountValue
        {
            get
            {
                return _amountValue;
            }
            set
            {
                _amountValue = value;
                RaisePropertyChanged();
            }
        }

        private float _amountIncomeValue;
        public float AmountIncomeValue
        {
            get
            {
                return _amountIncomeValue;
            }
            set
            {
                _amountIncomeValue = value;
                RaisePropertyChanged();
            }
        }

        private String _dateValue;
        public String DateValue
        {
            get
            {
                return _dateValue;
            }
            set
            {
                _dateValue = value;
                RaisePropertyChanged();
            }
        }

        private String _dateIncomeValue;
        public String DateIncomeValue
        {
            get
            {
                return _dateIncomeValue;
            }
            set
            {
                _dateIncomeValue = value;
                RaisePropertyChanged();
            }
        }

        private float _amountStatisticValue;
        public float AmountStatisticValue
        {
            get
            {
                return _amountStatisticValue;
            }
            set
            {
                _amountStatisticValue = value;
                RaisePropertyChanged();
            }
        }

        private string _displayCategoryName;
        public string DisplayCategoryName
        {
            get
            {
                return _displayCategoryName;
            }
            set
            {
                _displayCategoryName = value;
                RaisePropertyChanged();
            }
        }
        #endregion

    }
}