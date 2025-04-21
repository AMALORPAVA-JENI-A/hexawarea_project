using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayExpert.Model
{
    public  class Tax
    {
        public int taxID
        {
            get; set;
        }
        public int employeeID
        {
            get; set;
        }
        public int taxYear
        {
            get; set;
        }
        public decimal taxableIncome
        {
            get; set;
        }
        public decimal taxAmount
        {
            get; set;
        }
        public Tax() { }
        public Tax(int taxID, int employeeID, int taxYear, decimal taxableIncome, decimal taxAmount)
        {
            this.taxID = taxID;
            this.employeeID = employeeID;
            this.taxYear = taxYear;
            this.taxableIncome = taxableIncome;
            this.taxAmount = taxAmount;
        }
        public override string ToString()
        {
            return $"tax ID={taxID} , Enployee ID={employeeID} , tax year={taxYear} , taxable income={taxableIncome} , tax amount={taxAmount}";
        }
    }
}
