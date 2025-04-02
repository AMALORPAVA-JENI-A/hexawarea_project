using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsAssignment
{
    internal class Account
    {
        int AccountNumber;
        string AccountType;
        float AccountBalance;
        public int accountNumber
        {
            set { AccountNumber = value; }
            get { return AccountNumber; }
        }
        public string accountType
        {
            get { return AccountType; }
            set { AccountType = value; }
        }
        public float accountBalance
        {
            get { return AccountBalance; }
            set { AccountBalance = value; }
        }
        public Account()
        {

        }
        public void Deposit(float amount)
        {
            if (amount > 0)
            {
                AccountBalance += amount;
            }
            else
            {
                Console.WriteLine("Invalid amount");
            }
        }
        public void WithDraw(float amount)
        {
            if (amount < AccountBalance)
            {
                AccountBalance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
        public void CalculateInterest(float rate)
        {
            Console.WriteLine($"The interest is {AccountBalance * rate * 1}");
        }
        public void Display()
        {
            Console.WriteLine($"Account Number:{AccountNumber} Account Type:{AccountType} Account Balance:{AccountBalance}");
        }
    }
}
