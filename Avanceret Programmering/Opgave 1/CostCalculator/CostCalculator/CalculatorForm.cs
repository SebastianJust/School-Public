using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CostHandler;
using CostHandler.Models;

namespace CostCalculator
{
    public partial class CalculatorForm : Form
    {


        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void CostCalculator_Load(object sender, EventArgs e)
        {

        }

        private async void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string income = this.income.Text;
                string expenses = expense.Text;


                //We check for null
                if (string.IsNullOrEmpty(income))
                {
                    MessageBox.Show($"Indkomst må ikke være tom", $"Du har ikke angivet en indkomst", MessageBoxButtons.OK);
                    throw new NullReferenceException($"Income cannot be null"); // Consider to remove - so you have option to put in. Right now it breaks.

                }

                if (string.IsNullOrEmpty(expenses))
                {
                    MessageBox.Show($"Udgift må ikke være tom", $"Du har ikke angivet en udgift", MessageBoxButtons.OK);
                    throw new NullReferenceException($"Expense cannot be null");
                }


                //Let's get results
                CalculateModel costResponse = await Handler.Calculate(Convert.ToDecimal(income),
                    Convert.ToDecimal(expenses), Convert.ToDateTime(untilDate?.Value));

                FormMapping(costResponse);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }


        private void FormMapping(CalculateModel r)
        {
            try
            {
                incomeValue.Text = r.IncomeAverage.ToString("C");
                expenseValue.Text = r.ExpensesAverage.ToString("C");
                profit.Text = r.ProfitAverage.ToString("C");
                savings.Text = r.SavingsTotalRate.ToString("P");


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
