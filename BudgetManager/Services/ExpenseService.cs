using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script;
using System.Web.Script.Serialization;
using BudgetManager.Model;
using Newtonsoft.Json;

namespace BudgetManager.Services
{
    class ExpenseService
    {
        //Thread.Sleep(TimeSpan.FromSeconds(3));

        private const String JSON_PATH = @"..\..\Data\expenses.json";

        public static List<Expense> getExpenses()
        {
            List<Expense> result;
            using (StreamReader reader = new StreamReader(JSON_PATH))
            {
                String json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<Expense>>(json);
            }
            return result;
        }

        public static void saveExpense(Expense expense)
        {
            List<Expense> inscription = getExpenses();
            inscription.Add(expense);
            saveListAsJson(inscription);
        }

        public static void editExpense(Expense expense)
        {
            List<Expense> expenses = getExpenses();
            Expense oldExpense = expenses.Find(item => item.Id.Equals(expense.Id));
            expenses.RemoveAt(expenses.IndexOf(oldExpense));
            expenses.Add(expense);
            saveListAsJson(expenses);    
        }

        private static void saveListAsJson(List<Expense> list)
        {
            String json = JsonConvert.SerializeObject(list.ToArray(), Formatting.Indented);
            File.WriteAllText(JSON_PATH, json);
        }
    }
}