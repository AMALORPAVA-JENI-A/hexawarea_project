using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge2.Model
{

    public class HomeLoan : Loan
    {
        public string propertyAddress
        {
            get; set;
        }
        public decimal propertyValue
        {
            get; set;
        }
        public HomeLoan() : base() { }


        public HomeLoan(int loanId, Customer customer, decimal principalAmount, decimal interestRate, int loanTerm, string loanType, string loanStatus, string propertyAddress, decimal propertyValue)
                : base(loanId, customer, principalAmount, interestRate, loanTerm, "Home Loan", loanStatus)
        {
            this.propertyAddress = propertyAddress;
            this.propertyValue=propertyValue;
        }
        public override string ToString()
        {
            return base.ToString();
            return $"Property Address={propertyAddress} , property value={propertyValue}";
        }
    }
}
