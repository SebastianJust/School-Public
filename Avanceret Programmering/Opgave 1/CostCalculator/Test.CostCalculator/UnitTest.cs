using System;
using System.Threading.Tasks;
using CostHandler;
using CostHandler.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.CostCalculator
{
    [TestClass]
    public class UnitTest
    {
        readonly string _income = "246.585";
        readonly string _expense = "100.704,1";

        [TestMethod]
        public void DaysInMonth()
        {
            decimal days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            Assert.AreEqual(30, days); //September
        }

        [TestMethod]
        public void DaysInMonth_Assignment()
        {

            TimeSpan time = new DateTime(DateTime.Now.Year, 1, 1) - new DateTime(DateTime.Now.Year, 1, 16); //Put in one more day to handle actually 15 days
            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, new DateTime(DateTime.Now.Year, 1, 1).Month);
            decimal total = (decimal) time.Days / daysInMonth;

            Assert.AreEqual(Convert.ToDecimal("-0,4838709677419354838709677419"), total); //September
        }

        [TestMethod]
        public void Calculation_Profit()
        {
            CalculateModel model = new CalculateModel {Income = 1, Expenses = 1};

            Assert.AreEqual(0, model.TotalProfit);

        }

        [TestMethod]
        public void Calculation_IncomeAverage_Form()
        {
        

            var r = new CalculateModel { Income = Convert.ToDecimal(_income), Expenses = Convert.ToDecimal(_expense), UntilDate = DateTime.Now, DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) };
            string vI = r.IncomeAverage.ToString("C");


            Assert.AreEqual("29.472,31 kr.", vI);

        }

        [TestMethod]
        public void Calculation_IncomeAverage_Form_DifferentDay()
        {
            
            CalculateModel r = new CalculateModel { Income = Convert.ToDecimal(_income), Expenses = Convert.ToDecimal(_expense), UntilDate = DateTime.Now, DaysInMonth = 30.4375 };
            string vI = r.IncomeAverage.ToString("C");

            Assert.AreEqual("29.902,12 kr.", vI);

        }


        [TestMethod]
        public async Task Calculation_Handler()
        {

            var r = await Handler.Calculate(Convert.ToDecimal(_income), Convert.ToDecimal(_expense), DateTime.Now);
            string vI = r.IncomeAverage.ToString("C");

            Assert.AreEqual("29.472,31 kr.", vI);

        }

    }
}
