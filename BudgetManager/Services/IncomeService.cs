using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Model;
using Newtonsoft.Json;

namespace BudgetManager.Services
{
    class IncomeService
    {
        private const String JSON_PATH = @"..\..\Data\incomes.json";

        public static List<Income> getIncomes()
        {
            List<Income> result;
            using (StreamReader reader = new StreamReader(JSON_PATH))
            {
                String json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<Income>>(json);
            }
            return result;
        }

        public static void saveIncome(Income income)
        {
            List<Income> inscription = getIncomes();
            inscription.Add(income);
            saveListAsJson(inscription);
        }

        public static void editIncome(Income income)
        {
            List<Income> incomes = getIncomes();
            Income oldIncome = incomes.Find(item => item.Id == income.Id);
            incomes.RemoveAt(incomes.IndexOf(oldIncome));
            incomes.Add(income);
            saveListAsJson(incomes);    
        }

        private static void saveListAsJson(List<Income> list)
        {
            String json = JsonConvert.SerializeObject(list.ToArray(), Formatting.Indented);
            File.WriteAllText(JSON_PATH, json);
        }
    }

}
