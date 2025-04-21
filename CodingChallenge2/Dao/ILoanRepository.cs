using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge2.Model;

namespace CodingChallenge2.Dao
{
    public interface ILoanRepository
    {
        int ApplyLoan(Loan loan);
        decimal CalculateInterest(int loanId);
        decimal CalculateInterest(decimal principal, decimal interestRate, int loanTerm);
        int LoanStatus(int loanId);
        decimal CalculateEMI(int loanId);
        decimal CalculateEMI(decimal principal, decimal annualInterestRate, int loanTerm);
        void LoanRepayment(int loanId, decimal amount);
        List<Loan> GetAllLoans();
        Loan GetLoanById(int loanId);
    }
}
