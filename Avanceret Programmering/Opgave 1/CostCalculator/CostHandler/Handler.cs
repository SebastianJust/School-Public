using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostHandler.Models;
using Newtonsoft.Json;

namespace CostHandler
{
    public static class Handler
    {
        public static async Task<CalculateModel> Calculate(decimal income, decimal expenses, DateTime untilDate)
        {
            try
            {
                CalculateModel response = new CalculateModel
                {
                    Income = income,
                    Expenses = expenses,
                    UntilDate = untilDate,
                    DaysInMonth = DateTime.DaysInMonth(untilDate.Year, untilDate.Month)
                };

                Console.WriteLine($"Response: {JsonConvert.SerializeObject(response)}");

                return await Task.FromResult(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }

}
