using System.Windows.Forms;

namespace CostCalculator
{
    partial class CalculatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label calculationsMonthlyProfitsLabel;
            System.Windows.Forms.Label calculationsMonthlyExpensesLabel;
            System.Windows.Forms.Label calculationsMonthlyIncomeLabel;
            System.Windows.Forms.Label calculationsMonthlyHeader;
            System.Windows.Forms.Label label7;
            this.CalculateButton = new System.Windows.Forms.Button();
            this.untilDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.income = new System.Windows.Forms.TextBox();
            this.expense = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.calculationsMonthlyProfitsValue = new System.Windows.Forms.Label();
            this.calculationsMonthlyExpensesValue = new System.Windows.Forms.Label();
            this.calculationsMonthlyIncomeValue = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.incomeValue = new System.Windows.Forms.Label();
            this.expenseValue = new System.Windows.Forms.Label();
            this.profit = new System.Windows.Forms.Label();
            this.savings = new System.Windows.Forms.Label();
            calculationsMonthlyProfitsLabel = new System.Windows.Forms.Label();
            calculationsMonthlyExpensesLabel = new System.Windows.Forms.Label();
            calculationsMonthlyIncomeLabel = new System.Windows.Forms.Label();
            calculationsMonthlyHeader = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // calculationsMonthlyProfitsLabel
            // 
            calculationsMonthlyProfitsLabel.AutoSize = true;
            calculationsMonthlyProfitsLabel.Location = new System.Drawing.Point(29, 201);
            calculationsMonthlyProfitsLabel.Name = "calculationsProfitsLabel";
            calculationsMonthlyProfitsLabel.Size = new System.Drawing.Size(56, 13);
            calculationsMonthlyProfitsLabel.TabIndex = 17;
            calculationsMonthlyProfitsLabel.Text = "Overskud:";
            // 
            // calculationsMonthlyExpensesLabel
            // 
            calculationsMonthlyExpensesLabel.AutoSize = true;
            calculationsMonthlyExpensesLabel.Location = new System.Drawing.Point(29, 178);
            calculationsMonthlyExpensesLabel.Name = "calculationsExpensesLabel";
            calculationsMonthlyExpensesLabel.Size = new System.Drawing.Size(47, 13);
            calculationsMonthlyExpensesLabel.TabIndex = 16;
            calculationsMonthlyExpensesLabel.Text = "Udgifter:";
            // 
            // calculationsMonthlyIncomeLabel
            // 
            calculationsMonthlyIncomeLabel.AutoSize = true;
            calculationsMonthlyIncomeLabel.Location = new System.Drawing.Point(29, 155);
            calculationsMonthlyIncomeLabel.Name = "calculationsIncomeLabel";
            calculationsMonthlyIncomeLabel.Size = new System.Drawing.Size(56, 13);
            calculationsMonthlyIncomeLabel.TabIndex = 15;
            calculationsMonthlyIncomeLabel.Text = "Indtægter:";
            // 
            // calculationsMonthlyHeader
            // 
            calculationsMonthlyHeader.AutoSize = true;
            calculationsMonthlyHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            calculationsMonthlyHeader.Location = new System.Drawing.Point(29, 133);
            calculationsMonthlyHeader.Name = "calculationsHeader";
            calculationsMonthlyHeader.Size = new System.Drawing.Size(132, 13);
            calculationsMonthlyHeader.TabIndex = 14;
            calculationsMonthlyHeader.Text = "Månedlig Gennemsnit:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(335, 133);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(116, 13);
            label7.TabIndex = 25;
            label7.Text = "Opsparet i procent:";
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(440, 318);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(75, 23);
            this.CalculateButton.TabIndex = 4;
            this.CalculateButton.Text = "Beregn";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // untilDate
            // 
            this.untilDate.Location = new System.Drawing.Point(315, 49);
            this.untilDate.Name = "untilDate";
            this.untilDate.Size = new System.Drawing.Size(200, 20);
            this.untilDate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 21;
            // 
            // income
            // 
            this.income.AcceptsReturn = true;
            this.income.Location = new System.Drawing.Point(32, 49);
            this.income.Name = "income";
            this.income.Size = new System.Drawing.Size(105, 20);
            this.income.TabIndex = 1;
            // 
            // expense
            // 
            this.expense.Location = new System.Drawing.Point(175, 49);
            this.expense.Name = "expense";
            this.expense.Size = new System.Drawing.Size(100, 20);
            this.expense.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Indkomst i kr.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Udgifter i kr.";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Frem til dato:";
            // 
            // calculationsMonthlyProfitsValue
            // 
            this.calculationsMonthlyProfitsValue.AutoSize = true;
            this.calculationsMonthlyProfitsValue.Location = new System.Drawing.Point(112, 201);
            this.calculationsMonthlyProfitsValue.Name = "calculationsMonthlyProfitsValue";
            this.calculationsMonthlyProfitsValue.Size = new System.Drawing.Size(0, 13);
            this.calculationsMonthlyProfitsValue.TabIndex = 20;
            // 
            // calculationsMonthlyExpensesValue
            // 
            this.calculationsMonthlyExpensesValue.AutoSize = true;
            this.calculationsMonthlyExpensesValue.Location = new System.Drawing.Point(112, 178);
            this.calculationsMonthlyExpensesValue.Name = "calculationsMonthlyExpensesValue";
            this.calculationsMonthlyExpensesValue.Size = new System.Drawing.Size(0, 13);
            this.calculationsMonthlyExpensesValue.TabIndex = 19;
            // 
            // calculationsMonthlyIncomeValue
            // 
            this.calculationsMonthlyIncomeValue.AutoSize = true;
            this.calculationsMonthlyIncomeValue.Location = new System.Drawing.Point(112, 155);
            this.calculationsMonthlyIncomeValue.Name = "calculationsMonthlyIncomeValue";
            this.calculationsMonthlyIncomeValue.Size = new System.Drawing.Size(0, 13);
            this.calculationsMonthlyIncomeValue.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 0;
            // 
            // incomeValue
            // 
            this.incomeValue.AutoSize = true;
            this.incomeValue.Location = new System.Drawing.Point(125, 155);
            this.incomeValue.Name = "incomeValue";
            this.incomeValue.Size = new System.Drawing.Size(20, 13);
            this.incomeValue.TabIndex = 22;
            this.incomeValue.Text = "Kr.";
            // 
            // expenseValue
            // 
            this.expenseValue.AutoSize = true;
            this.expenseValue.Location = new System.Drawing.Point(125, 178);
            this.expenseValue.Name = "expenseValue";
            this.expenseValue.Size = new System.Drawing.Size(20, 13);
            this.expenseValue.TabIndex = 23;
            this.expenseValue.Text = "Kr.";
            // 
            // profit
            // 
            this.profit.AutoSize = true;
            this.profit.Location = new System.Drawing.Point(125, 201);
            this.profit.Name = "profit";
            this.profit.Size = new System.Drawing.Size(20, 13);
            this.profit.TabIndex = 24;
            this.profit.Text = "Kr.";
            // 
            // savings
            // 
            this.savings.AutoSize = true;
            this.savings.Location = new System.Drawing.Point(335, 155);
            this.savings.Name = "savings";
            this.savings.Size = new System.Drawing.Size(15, 13);
            this.savings.TabIndex = 26;
            this.savings.Text = "%";
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 368);
            this.Controls.Add(this.savings);
            this.Controls.Add(label7);
            this.Controls.Add(this.profit);
            this.Controls.Add(this.expenseValue);
            this.Controls.Add(this.incomeValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.calculationsMonthlyProfitsValue);
            this.Controls.Add(this.calculationsMonthlyExpensesValue);
            this.Controls.Add(this.calculationsMonthlyIncomeValue);
            this.Controls.Add(calculationsMonthlyProfitsLabel);
            this.Controls.Add(calculationsMonthlyExpensesLabel);
            this.Controls.Add(calculationsMonthlyIncomeLabel);
            this.Controls.Add(calculationsMonthlyHeader);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.expense);
            this.Controls.Add(this.income);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.untilDate);
            this.Controls.Add(this.CalculateButton);
            this.Name = "CalculatorForm";
            this.Text = "Omkostningsberegner";
            this.Load += new System.EventHandler(this.CostCalculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.DateTimePicker untilDate;
        private Label label1;
        private TextBox income;
        private TextBox expense;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label calculationsMonthlyProfitsValue;
        private Label calculationsMonthlyExpensesValue;
        private Label calculationsMonthlyIncomeValue;
        private Label label6;
        private Label incomeValue;
        private Label expenseValue;
        private Label profit;
        private Label savings;
    }


}


