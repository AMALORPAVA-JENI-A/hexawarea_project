using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assignment;

namespace assignment
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
            public Account(int AccountNumber, string AccountType, float AccountBalance)
        {
           this.AccountNumber = AccountNumber;
            this.AccountType = AccountType;
            this.AccountBalance = AccountBalance;
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
        public void Deposit(int amount)
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
        public virtual void WithDraw(int amount)
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
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                AccountBalance += Convert.ToSingle(amount);
            }
            else
            {
                Console.WriteLine("Invalid amount");
            }
        }
        public virtual void WithDraw(double amount)
        {
            if (amount < AccountBalance)
            {
                AccountBalance -= Convert.ToSingle(amount);
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
        public virtual void CalculateInterest()
            {
                Console.WriteLine($"The interest is {(AccountBalance * 4.5)/100}");
            }
            public void Display()
            {
                Console.WriteLine($"Account Number:{AccountNumber} Account Type:{AccountType} Account Balance:{AccountBalance}");
            }
       
        }
    }
class Savingsaccount : Account
{
    float InterestRate;
    public Savingsaccount(int AccountNumber, string AccountType, float AccountBalance) : base(AccountNumber, AccountType, AccountBalance)
    {

    }
    public float interestRate
    {
        get { return InterestRate; }
        set { InterestRate = value; }
    }
    public override void CalculateInterest()
    {
        Console.WriteLine($"The interest is {(accountBalance * 4.5) / 100}");
    }

}

class Currentaccount : Account
{
    float OverDraftLimit=5000;
    public Currentaccount(int AccountNumber, string AccountType, float AccountBalance) : base(AccountNumber, AccountType, AccountBalance)
    {

    }
    public float overdraftLimit
    {
        get { return OverDraftLimit; }
        set { OverDraftLimit = value; }
    }
    public override void WithDraw(double amount)
    {
        if (amount > accountBalance + OverDraftLimit)
        {
            Console.WriteLine($"Withdraw failed.overdraft limit of {OverDraftLimit} exceeded.");

        }
        else
        {
            accountBalance -= Convert.ToSingle(amount);
            Console.WriteLine("Succesfully amount credited");
        }
    }

}
abstract class bankAccount
{
    int AccountNumber;
    string CustomerName;
    float Balance;

    public bankAccount()
    {

    }
    public bankAccount(int accountNumber, string customerName, float balance)
    {
        AccountNumber = accountNumber;
        CustomerName = customerName;
        Balance = balance;
    }
    public int accountNumber
    {
        get { return AccountNumber; }
        set {  AccountNumber = value; }
    }
    public string customerName
    {
        get { return CustomerName; }
        set { CustomerName = value; }
    }
    public float balance
    {
        get { return Balance; }
        set { Balance = value; }
    }
    public abstract void Withdraw(float amount);
    public abstract void Deposit(float amount);
    public abstract void CalculateInterest();

    public void Display()
    {
        Console.WriteLine("Customer name={customerName} Account Number={accountNumber} Account Balance={balance}");
    }
}
class SavingsAccount : bankAccount
{
    private float InterestRate;

    public SavingsAccount(int accountNumber, string customerName, float balance, float interestRate)
        : base(accountNumber, customerName, balance)
    {
        InterestRate = interestRate;
    }

    public override void Deposit(float amount)
    {
        if (amount > 0)
        {
           balance += amount;
            Console.WriteLine($"Deposited: {amount}");
        }
    }

    public override void Withdraw(float amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public override void CalculateInterest()
    {
        float interest = balance * InterestRate / 100;
        balance += interest;
        Console.WriteLine($"Interest of {interest} added. New Balance: {balance}");
    }
}
class CurrentAccount : bankAccount
{
    private const float OverdraftLimit = 5000;

    public CurrentAccount(int accountNumber, string customerName, float balance)
        : base(accountNumber, customerName, balance)
    {
    }

    public override void Deposit(float amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount:C}");
        }
    }

    public override void Withdraw(float amount)
    {
        if (amount <= balance + OverdraftLimit)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount:C}. Remaining Balance: {balance:C}");
        }
        else
        {
            Console.WriteLine("Withdrawal failed. Overdraft limit exceeded.");
        }
    }

    public override void CalculateInterest()
    {
        Console.WriteLine("Current Account has no interest.");
        
    }
}
