using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assignment;

namespace assignment
{
    public abstract class BankAccount
    {
        static int lastAccountNumber = 1000;

        public long AccountNumber
        {
            get; set;
        }
        public string AccountType
        {
            get; set;
        }
        public Customer Customer
        {
            get;
            set;
        }
        public float AccountBalance
        {
            get;
            set;
        }
        public BankAccount(Customer customer, string accountType, float balance)
        {
            AccountNumber = ++lastAccountNumber;
            AccountType = accountType;
            Customer = customer;
            AccountBalance = balance;
        }

        public abstract float Withdraw(long accountNo,float amount);
        public abstract float Deposit(long accountNo, float amount);
        public override string ToString()
        {
            return $"AccountNumber:{AccountNumber},Account Type:{AccountType},Acccount Balance:{AccountBalance}\n{Customer}";
        }

    }
    public class SavingsAccount : BankAccount
    {
        public float InterestRate { get; set; } = 1.4f;

        public SavingsAccount(Customer customer, float balance)
            : base(customer, "savings", balance < 500 ? throw new ArgumentException("minimum balance for savings account is 500") : balance)
        {
            
            AccountType = "Savings";
        }

        public override float Deposit(long accountNo, float amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
              AccountBalance += amount;
               
            
            return AccountBalance;
        }

        public override float Withdraw(long accountNo, float amount)
        {
            if (AccountBalance - amount < 500)
            {
                throw new ArgumentException("Insufficient balance. Minimum 500 must be maintained.");
            }
            else
            {
                AccountBalance -= amount;
            }
            return AccountBalance;
        }

        
    }
    class CurrentAccount : BankAccount
    {
        public float OverdraftLimit { get; } = 1000;

        public CurrentAccount(Customer customer, float balance)
            : base(customer, "current", balance)
        {
            
        }

        public override float Deposit(long accountNo, float amount)
        {
            if (amount > 0)
            {
                AccountBalance += amount;
                Console.WriteLine($"Deposited: {amount:C}");
            }
            else
            {
                throw new Exceptions.InsufficientFundException("Deposit amount must be greater than zero");
            }
            return AccountBalance;
        }

        public override float Withdraw(long accountNo, float amount)
        {
            if (amount <= AccountBalance + OverdraftLimit)
            {
                AccountBalance -= amount;
                Console.WriteLine($"Withdrawn: {amount}, Remaining Balance: {AccountBalance}");
            }
            else
            {
                throw new Exceptions.InsufficientFundException("Withdrawal failed. Overdraft limit exceeded.");
            }
            return AccountBalance;
        }

        
    }
    class ZeroAccountBalance : BankAccount
    {
        public ZeroAccountBalance(Customer customer, float balance):base(customer,"ZeroBalance",balance)
        {

        }
        public override float Deposit(long accountNo, float amount)
        {
            if (amount > 0)
            {
                AccountBalance += amount;
                Console.WriteLine("Amount  deposited");
            }
            else
            {
                throw new Exceptions.InvalidAccountException("Invalid account");
            }
            return AccountBalance;
        }
        public override float Withdraw(long accountNo, float amount)
        {
            if(AccountBalance-amount<0)
            {
                throw new Exceptions.InsufficientFundException("Insufficient balance");
            }
            else
            {
                AccountBalance-=amount;
            }
            return AccountBalance;
        }

    }
}