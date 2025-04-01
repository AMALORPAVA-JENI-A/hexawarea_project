using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task 1

            Console.WriteLine("Enter the customer credit score");
            Double CreditScore = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the annual income");
            Double salary = Convert.ToDouble(Console.ReadLine());
            if (CreditScore > 700 && salary > 50000)
            {
                Console.WriteLine("The customer is eligible to take a loan");
            }
            else
            {
                Console.WriteLine("The customer is not eligible to take a loan");
            }

            ////task2

            Console.WriteLine("Enter the current balance");
            int balance = Convert.ToInt32(Console.ReadLine());

            int Continue = 1;
            while (Continue >= 1)
            {
                Console.WriteLine("Enter 1 for withdrawal 2 to deposit 3 to check the balance");
                int opt = Convert.ToInt32(Console.ReadLine());
                if (opt == 1)
                {
                    Console.WriteLine("Enter the amount to withdraw");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    if (amount > balance)
                    {
                        Console.WriteLine("Insufficient balance");
                    }
                    else if (amount % 100 != 0 || amount % 500 != 0)
                    {
                        Console.WriteLine("Enter a valid amount");
                    }
                    else
                    {
                        balance = balance - amount;
                    }
                }
                else if (opt == 2)
                {
                    Console.WriteLine("Enter the amount to deposit");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    balance = balance + amount;
                }
                else
                {
                    Console.WriteLine($"The balance amount={balance}");
                }
                Console.WriteLine("if you want to continue press 1 or else 0");
                Continue = Convert.ToInt32(Console.ReadLine());
            }

            //task3

            int n = 1;
            Double FutureBalance;
            Double years;
            Double InterestRate;
            Double BalanceAmount;
            while (n == 1)
            {
                Console.WriteLine("Enter the balance");
                BalanceAmount = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the annual interest rate ");
                InterestRate = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the number of years");
                years = Convert.ToDouble(Console.ReadLine());
                FutureBalance = Math.Pow((BalanceAmount * (1 + InterestRate / 100)), years);
                Console.WriteLine($"The future balance after {years} years = {FutureBalance}");
                Console.WriteLine("If you want to continue press 1 or else 0");
                n = Convert.ToInt32(Console.ReadLine());
            }

            //task4

            Console.WriteLine("Enter the number of customers");
            int m=Convert.ToInt32(Console.ReadLine());
            string[] AccNumber=new string[m];
            int[] Balance = new int[m];
            for(int i=0; i < m;i++)
            {
                Console.WriteLine("Enter the account number");
                AccNumber[i] = Console.ReadLine();
                while (AccNumber[i].Contains("INDB")==false || Regex.IsMatch(AccNumber[i], @"\d{4}$")==false || AccNumber[i].Length!=8)
                {
                    Console.WriteLine("Enter a valid account number");
                    AccNumber[i] = Console.ReadLine();
                }
                
                    
                    Console.WriteLine("Enter the  account balance");
                    Balance[i] = Convert.ToInt32(Console.ReadLine());
                
            }
            for(int i=0;i<m;i++)
            {
                Console.WriteLine($"The account {AccNumber[i]} balance = {Balance[i]}");
            }

            //task5

            string password=Console.ReadLine();
            if(password.Length>=8 || (Regex.IsMatch(password, @"\d")) || (password.Any(char.IsUpper)))
            {
                Console.WriteLine("Is a strong password");
            }
            else
            {
                Console.WriteLine("Password not valid");
            }

            //task6

            

        }
    }
}
