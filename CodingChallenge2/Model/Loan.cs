using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge2.Model
{
    public class Loan
    {
        public int loanId
        {
            get; set;
        }
        public Customer customer 
        { 
            get; set; 
        }
        public decimal principalAmount
        {
            get; set;
        }
        public decimal interestRate
        {
            get; set;
        }
        public int loanTerm
        {
            get; set;
        }
        public string loanType
        {
            get; set;
        }
        public string loanStatus
        {
            get; set;
        }
        public Loan()
        {

        }
        public Loan(int loanId, Customer customer, decimal principalAmount, decimal interestRate, int loanTerm, string loanType, string loanStatus)
        {
            this.loanId = loanId;
            this.customer = customer;
            this.principalAmount = principalAmount;
            this.interestRate = interestRate;
            this.loanTerm = loanTerm;
            this.loanType = loanType;
            this.loanStatus = loanStatus;
        }
        public override string ToString()
        {
            return $"LoanId={loanId} , Customer={customer} , principal amount={principalAmount} , interest rate={interestRate} , loan term={loanTerm} , loan type={loanType} , loan status={loanStatus}";
        }
        
    }
}
