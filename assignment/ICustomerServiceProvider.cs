using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    internal interface ICustomerServiceProvider
    {
        float GetAccountBalance(long AccountNumber);
        float Deposit(long AccountNumber,float amount);
        float Withdraw(long AccountNumber,float amount);
        void Transfer(long fromAccountNumber, long toAccountNumber, float amount);
        string GetAccountDetails(long AccountNumber);

       
    }
}
