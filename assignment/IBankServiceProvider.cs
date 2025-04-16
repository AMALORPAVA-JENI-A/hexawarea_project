using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    internal interface IBankServiceProvider
    {
        void CreateAccount(Customer customer, string AccountType, float AccountBalance);
        void ListAccounts();
        void CalculateInterest();
    }
}
