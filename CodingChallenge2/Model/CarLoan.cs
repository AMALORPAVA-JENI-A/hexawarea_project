using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge2.Model
{
    public class CarLoan:Loan
    {
        public string carModel
        {
            get;  set;
        }
        public decimal carValue
        {
            get; set;
        }
        public CarLoan() :base(){ }
        public CarLoan(int loanId, Customer customer, decimal principalAmount, decimal interestRate, int loanTerm, string loanType, string loanStatus,string carModel,decimal carValue)
            :base(loanId, customer, principalAmount, interestRate, loanTerm, "Car Loan", loanStatus)
        {
            this.carModel = carModel;
            this.carValue = carValue;
        }
        public override string ToString()
        {
            return base.ToString() ;
            return $"Car model={carModel} , car value={carValue}";
        }
    }
}
