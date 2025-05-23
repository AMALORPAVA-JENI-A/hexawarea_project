﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMBank.Exceptions;
namespace HMBank
{
    public class Account
    {
        public int lastAccountNumber = 1000;

        public long accountNumber
        {
            get; set;
        }
        public string accountType
        {
            get; set;
        }
        public Customer customer
        {
            get;
            set;
        }
        public decimal accountBalance
        {
            get;
            set;

        }
        public Account()
        {

        }
        public Account(Customer Customer, string AccountType, decimal balance)
        {
            accountNumber = ++lastAccountNumber;
            accountType = AccountType;
            customer = Customer;
            accountBalance = balance;
        }

        public virtual decimal Withdraw(long accountNo, decimal amount)
        {
            if (accountBalance - amount < 0)
            {
                throw new ArgumentException("Insufficient balance.");
            }
            else
            {
                accountBalance -= amount;
            }
            return accountBalance;
        }
        public virtual decimal Deposit(long accountNo, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
            accountBalance += amount;


            return accountBalance;
        }
        public override string ToString()
        {
            return $"AccountNumber:{accountNumber},Account Type:{accountType},Acccount Balance:{accountBalance}\n{customer}";
        }

    }
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; } = 4;

        public SavingsAccount(Customer customer, decimal balance)
            : base(customer, "Savings", balance < 500 ? throw new ArgumentException("minimum balance for savings account is 500") : balance)
        {
        }

        public override decimal Deposit(long accountNo, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
            else
            {
                accountBalance += amount;
            }


            return accountBalance;
        }

        public override decimal Withdraw(long accountNo, decimal amount)
        {
            if (accountBalance - amount < 500)
            {
                throw new ArgumentException("Insufficient balance. Minimum 500 must be maintained.");
            }
            else
            {
                accountBalance -= amount;
            }
            return accountBalance;
        }


    }
    class CurrentAccount : Account
    {
        public decimal OverdraftLimit { get; } = 100;

        public CurrentAccount(Customer customer, decimal balance)
            : base(customer, "Current", balance)
        {

        }

        public override decimal Deposit(long accountNo, decimal amount)
        {
            if (amount > 0)
            {
                accountBalance += amount;
                //Console.WriteLine($"Deposited: {amount:C}");
            }
            else
            {
                throw new Exceptions.InsufficientFundException("Deposit amount must be greater than zero");
            }
            return accountBalance;
        }

        public override decimal Withdraw(long accountNo, decimal amount)
        {
            if (amount <= accountBalance + OverdraftLimit)
            {
                accountBalance -= amount;
                //Console.WriteLine($"Withdrawn: {amount}, Remaining Balance: {accountBalance}");
            }
            else
            {
                throw new Exceptions.InsufficientFundException("Withdrawal failed. Overdraft limit exceeded.");
            }
            return accountBalance;
        }


    }
    class ZeroAccountBalance : Account
    {
        public ZeroAccountBalance(Customer customer, decimal balance) : base(customer, "Zero Balance", balance)
        {

        }
        public override decimal Deposit(long accountNo, decimal amount)
        {
            if (amount > 0)
            {
                accountBalance += amount;
                //Console.WriteLine("Amount  deposited");
            }
            else
            {
                throw new Exceptions.InvalidAccountException("Invalid account");
            }
            return accountBalance;
        }
        public override decimal Withdraw(long accountNo, decimal amount)
        {
            if (accountBalance - amount < 0)
            {
                throw new Exceptions.InsufficientFundException("Insufficient balance");
            }
            else
            {
                accountBalance -= amount;
            }
            return accountBalance;
        }

    }
}
   
