using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    internal class CustomerServiceProviderImpl : ICustomerServiceProvider
    {
        public List<BankAccount> accounts = new();
        public float GetAccountBalance(long accountNumber)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found");
            }

            return account.AccountBalance;
        }
        public float Deposit(long accountNumber, float Amount)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found");

            }
            account.Deposit(accountNumber,Amount);
            return account.AccountBalance;
        }
        public float Withdraw(long accountNumber, float Amount)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found");
            }
            account.Withdraw(accountNumber,Amount);
            return account.AccountBalance;
        }
        public void Transfer(long From, long To, float Amount)
        {
            var from = accounts.FirstOrDefault(a => a.AccountNumber == From);
            var to = accounts.FirstOrDefault(b => b.AccountNumber == To);
            if (from == null || to == null)
            {
                Console.WriteLine("Account not found");
            }
            from.Withdraw(From,Amount);
            to.Deposit(To,Amount);
            Console.WriteLine("Successfully transfered");
        }
        public string GetAccountDetails(long accountNumber)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if(account == null)
            {
                Console.WriteLine("Account not found");
            }
            return account.ToString();
        }

    }
}
