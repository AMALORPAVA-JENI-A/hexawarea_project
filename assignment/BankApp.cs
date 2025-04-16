using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{

    internal class BankApp
    {
        BankServiceProviderImpl bankservice = new BankServiceProviderImpl();
        public void CreateAccount()
        {
            Console.WriteLine("enter the first name ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the email");
            string emailAddress = Console.ReadLine();
            Console.WriteLine("Enter the Phone number");
            string phoneNo = Console.ReadLine();
            Console.WriteLine("Enter the address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter the account type(Savings/Current/ZeroBalance)");
            string accType = Console.ReadLine();
            
            float balance = 0;
            if (accType != "ZeroBalance")
            {
                Console.WriteLine("Enter a initial balnce");
                balance = float.Parse(Console.ReadLine());
            }
            Customer customer = new Customer(firstName, lastName, emailAddress, phoneNo, address);
            bankservice.CreateAccount(customer, accType, balance);
        }
        public void PerformDeposit()
        {
            Console.WriteLine("Enter the account number");
            long accNo = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount  to be deposited");
            float amount = float.Parse(Console.ReadLine());
            float newBalance = bankservice.Deposit(accNo, amount);
            Console.WriteLine($"New Balance:{newBalance}");
        }
        public void PerformWithdraw()
        {
            Console.WriteLine("Enter the account number");
            long accNo = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount to withdraw");
            float aamount = float.Parse(Console.ReadLine());
            float newBalance = bankservice.Withdraw(accNo, aamount);
            Console.WriteLine($"New balance:{newBalance}");
        }
        public void PerformTransfer()
        {
            Console.WriteLine("Enter the account number from which the money has to be transacted");
            long from = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the account number to which the money has to be debited");
            long to = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount");
            float amount = float.Parse(Console.ReadLine());
            bankservice.Transfer(from, to, amount);

        }
        public void CheckBalance()
        {
            Console.WriteLine("Enter the account number");
            long accNo = long.Parse(Console.ReadLine());
            float balance = bankservice.GetAccountBalance(accNo);
            Console.WriteLine($"Account balance of account:{accNo} is {balance}");
        }
        public void ShowAccountDetails()

        {
            Console.WriteLine("Enter the account number");
            long accNo = long.Parse(Console.ReadLine());
            string accountDetails = bankservice.GetAccountDetails(accNo);
            Console.WriteLine(accountDetails);
        }
        public void  ListAccounts()
        {
            bankservice.ListAccounts();
            //foreach (var a in accounts)
            //{
            //    Console.WriteLine(a.ToString);
            //}
        }

    }
}
