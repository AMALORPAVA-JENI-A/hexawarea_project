using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    internal class BankServiceProviderImpl:CustomerServiceProviderImpl,IBankServiceProvider
    {
        public string brachName { get; set; }
        public string branchaddress { get; set; }
        public void CreateAccount(Customer customer,string AccountType,float AccountBalance)
        {
            BankAccount newaccount = AccountType switch
            {
                "Savings" => new SavingsAccount(customer, AccountBalance),
                "Current" => new CurrentAccount(customer, AccountBalance),
                "ZeroBalance" => new ZeroAccountBalance(customer, AccountBalance),
                _=> throw new ArgumentException("Invalid account type")
            };
            accounts.Add(newaccount);
        }

        public void ListAccounts()
        {
            foreach (var account in accounts)
            {
                Console.WriteLine(account);
            }
        }
            
        public void CalculateInterest()
        {
            foreach (var acc in accounts.OfType<SavingsAccount>())
            {
                acc.Deposit(acc.AccountNumber,acc.AccountBalance * acc.InterestRate);
            }
            
        }
    }
}
