﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMBank
{
    internal class BankApp
    {
      
            private static IBankRepository bankRepo = new BankRepositoryImpl();

            public static void Run()
            {
                while (true)
                {
                    Console.WriteLine("\n===== HMBank System Menu =====");
                    Console.WriteLine("1. Create Account");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Withdraw");
                    Console.WriteLine("4. Get Balance");
                    Console.WriteLine("5. Transfer");
                    Console.WriteLine("6. Get Account Details");
                    Console.WriteLine("7. List Accounts");
                    Console.WriteLine("8. Get Transactions");
                    Console.WriteLine("9.Calculate Interest");
                    Console.WriteLine("10. Exit");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            CreateAccountMenu();
                            break;
                        case "2":
                            Deposit();
                            break;
                        case "3":
                            Withdraw();
                            break;
                        case "4":
                            GetBalance();
                            break;
                        case "5":
                            Transfer();
                            break;
                        case "6":
                            GetAccountDetails();
                            break;
                        case "7":
                            ListAccounts();
                            break;
                        case "8":
                            GetTransactions();
                            break;
                    case "9":
                        CalculateInterest();
                        break;
                        case "10":
                            Console.WriteLine("Exiting system. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid option, try again.");
                            break;
                    }
                }
            }

            private static void CreateAccountMenu()
            {
            Account a = new Account();
                    Console.WriteLine("\nChoose Account Type: 1. Savings 2. Current 3. ZeroBalance");
                    string input = Console.ReadLine();
                    

                    
                    Console.Write("First Name: "); string first = Console.ReadLine();
                    Console.Write("Last Name: "); string last = Console.ReadLine();
                    Console.Write("Email: "); string email = Console.ReadLine();
                    Console.Write("Phone: "); string phone = Console.ReadLine();
                    Console.Write("Address: "); string address = Console.ReadLine();
                    Console.Write("Opening Balance: "); decimal balance = decimal.Parse(Console.ReadLine());

                    var customer = new Customer
                    {
                       
                        firstName = first,
                        lastName = last,
                        emailAdress = email,
                        phoneNo = phone,
                        address = address
                    };

                string accType = null;
                if (input == "1")
                {
                    accType = "Savings";
                }
                else if (input == "2")
                {
                    accType = "Current";
                }
                else if (input == "3")
                {
                    accType = "ZeroBalance";
                }
                    bankRepo.CreateAccount(customer, accType, balance);
                    Console.WriteLine("Account created successfully.");
                
            }

            private static void Deposit()
            {
                Console.Write("Account Number: ");
                long accNo = long.Parse(Console.ReadLine());
                Console.Write("Amount to Deposit: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            decimal newBalance = bankRepo.Deposit(accNo, amount);
                Console.WriteLine($"New Balance: {newBalance}");
            }

            private static void Withdraw()
            {
                Console.Write("Account Number: ");
                long accNo = long.Parse(Console.ReadLine());
                Console.Write("Amount to Withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            decimal newBalance = bankRepo.Withdraw(accNo, amount);
                Console.WriteLine($"Rows affected: {newBalance}");
            }

            private static void GetBalance()
            {
                Console.Write("Account Number: ");
                long accNo = long.Parse(Console.ReadLine());
            decimal balance = bankRepo.GetAccountBalance(accNo);
                Console.WriteLine($"Account Balance: {balance}");
            }

            private static void Transfer()
            {
                Console.Write("From Account: ");
                long from = long.Parse(Console.ReadLine());
                Console.Write("To Account: ");
                long to = long.Parse(Console.ReadLine());
                Console.Write("Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
                bankRepo.Transfer(from, to, amount);
                Console.WriteLine("Transfer successful.");
            }

            private static void GetAccountDetails()
            {
                Console.Write("Account Number: ");
                long accNo = long.Parse(Console.ReadLine());
                var account = bankRepo.GetAccountDetails(accNo);
                Console.WriteLine(account);
            }

            private static void ListAccounts()
            {
                var list = bankRepo.ListAccounts();
            foreach (var acc in list)
            {
                Console.WriteLine(acc);
            }
            }

            private static void GetTransactions()
            {
                Console.Write("Start Date (yyyy-mm-dd): ");
                DateTime from = DateTime.Parse(Console.ReadLine());
                Console.Write("End Date (yyyy-mm-dd): ");
                DateTime to = DateTime.Parse(Console.ReadLine());
                var transactions = bankRepo.GetTransactions(from, to);
            foreach (var tx in transactions)
            {
                Console.WriteLine(tx);
            }
            }
        private static void CalculateInterest()
        {
           
            int rows = bankRepo.CalculateInterest();
            Console.WriteLine($"rows affected={rows}");
            Console.WriteLine("Interest calculated successfully");
        }
        }

       
    }
