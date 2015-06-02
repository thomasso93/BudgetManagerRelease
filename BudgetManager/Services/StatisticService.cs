using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Model;

namespace BudgetManager.Services
{
    class StatisticService
    {
        #region Yearly
        public static List<Expense> getYearExpenses() 
        {
            List<Expense> expenses = ExpenseService.getExpenses();
            var sortedExpenses = from expense in expenses orderby expense.Amount descending select new Expense(expense);
            return sortedExpenses.Take(5).ToList();
        }

        public static List<Income> getYearIncome()
        {
            List<Income> incomes = IncomeService.getIncomes();
            var sortedIncomes = from income in incomes orderby income.Amount descending select new Income(income);
            return sortedIncomes.Take(5).ToList();
        }
        #endregion

        #region By Category
        public static List<DisplayCategory> getExpensesByCategory() 
        {
            List<Expense> expenses = ExpenseService.getExpenses();
           
            var expensesByCategory = expenses.GroupBy(exp => exp.Category)
                               .Select(group => new DisplayCategory(group.Key, group.Sum(item => item.Amount)));
           
            return sumUp(expensesByCategory.ToList());
        }

        public static List<DisplayCategory> getIncomesByCategory()
        {
            List<Income> incomes = IncomeService.getIncomes();

            var incomesByCategory = incomes.GroupBy(inc => inc.Category)
                               .Select(group => new DisplayCategory(group.Key, group.Sum(item => item.Amount)));

            return sumUp(incomesByCategory.ToList());
        }
        #endregion

        #region Helper Methods
        private static List<DisplayCategory> sumUp(List<DisplayCategory> list)
        {
            float amount = 0;
            foreach (DisplayCategory dc in list)
            {
                amount += dc.Amount;
            }
            DisplayCategory all = new DisplayCategory("Razem", amount);
            list.Add(all);
            return list;
        }
        #endregion
    }
}