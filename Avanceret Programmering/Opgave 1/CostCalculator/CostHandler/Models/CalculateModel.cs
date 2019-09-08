using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostHandler.Models
{

    public class CalculateModel
    {
        readonly DateTime _startDate = new DateTime(DateTime.Now.Year, 1, 1);

        #region Inputs

        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public DateTime UntilDate { get; set; }
        public double DaysInMonth { get; set; }

        #endregion



        #region Calculations && Returns

        public double Month => ((UntilDate - _startDate).Days + 1) / DaysInMonth; //Put in extra day to handle actually how long

        public decimal TotalProfit => Income - Expenses;
        public decimal IncomeAverage => Income / (decimal)Month;

        public decimal ExpensesAverage => Expenses / (decimal)Month;

        public decimal ProfitAverage => TotalProfit / (decimal)Month;

        public double SavingsTotalRate => (double)(TotalProfit / Income);


        #endregion

    }


}
