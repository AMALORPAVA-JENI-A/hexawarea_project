using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace assignment
{
    internal class Program
    {
        static BankServiceProviderImpl bankservice = new BankServiceProviderImpl();
        public static void Main(string[] args)
        {

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n===== BANKING SYSTEM MENU =====");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Check Balance");
                Console.WriteLine("6. Show Account Details");
                Console.WriteLine("7. List All Accounts");
                Console.WriteLine("8. Calculate Interest (Savings)");
                Console.WriteLine("9. Exit");
                Console.Write("Enter choice: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            CreateAccount();
                            break;
                        case 2:
                            PerformDeposit();
                            break;
                        case 3:
                            PerformWithdraw();
                            break;
                        case 4:
                            PerformTransfer();
                            break;
                        case 5:
                            CheckBalance();
                            break;
                        case 6:
                            ShowAccountDetails();
                            break;
                        case 7:
                            ListAccounts();
                            break;
                        case 8:
                            bankservice.CalculateInterest();
                            Console.WriteLine("Interest calculated for all Savings Accounts.");
                            break;
                        case 9:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
                public static void CreateAccount()
                    {
            Console.WriteLine("enter the first name ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the last name");
            string lastName=Console.ReadLine();
            Console.WriteLine("Enter the email");
            string emailAddress = Console.ReadLine();
            Console.WriteLine("Enter the Phone number");
            string phoneNo=Console.ReadLine();
            Console.WriteLine("Enter the address");
            string address=Console.ReadLine();
            Console.WriteLine("Enter the account type(Savings/Current/ZeroBalance)");
            string accType=Console.ReadLine();
            
            float balance = 0;
            if(accType!="ZeroBalance")
            {
                Console.WriteLine("Enter a initial balnce");
                balance = float.Parse(Console.ReadLine());
            }
            Customer customer = new Customer(firstName,lastName,emailAddress,phoneNo,address);
            bankservice.CreateAccount(customer,accType,balance);
                }
        public static void PerformDeposit()
        {
            Console.WriteLine("Enter the account number");
            long accNo=long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount  to be deposited");
            float amount=float.Parse(Console.ReadLine());
            float newBalance = bankservice.Deposit(accNo, amount);
            Console.WriteLine($"New Balance:{newBalance}");
        }
        public static void PerformWithdraw()
        {
            Console.WriteLine("Enter the account number");
            long accNo = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount to withdraw");
            float aamount=float.Parse(Console.ReadLine());
            float newBalance=bankservice.Withdraw(accNo, aamount);
            Console.WriteLine($"New balance:{newBalance}");
        }
        public static void PerformTransfer()
        {
            Console.WriteLine("Enter the account number from which the money has to be transacted");
            long from=long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the account number to which the money has to be debited");
            long to=long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount");
            float amount = float.Parse(Console.ReadLine());
            bankservice.Transfer(from, to,amount);
        
        }
        public static void CheckBalance()
        {
            Console.WriteLine("Enter the account number");
            long accNo=long.Parse(Console.ReadLine());
            float balance=bankservice.GetAccountBalance(accNo);
            Console.WriteLine($"Account balance of account:{accNo} is {balance}");
        }
        public static void ShowAccountDetails()

        {
            Console.WriteLine("Enter the account number");
            long accNo = long.Parse(Console.ReadLine());
            string accountDetails = bankservice.GetAccountDetails(accNo);
            Console.WriteLine(accountDetails);
        }
        public static void ListAccounts()
        {
            bankservice.ListAccounts();
            //foreach(var a in accounts)
            //{
            //    Console.WriteLine(a.ToString);
            //}
        }
            }



        }
    

//Console.WriteLine("Enter your options for account type either Current or savings.Pres 1 for current and 2 for savings");
//int opt=int.Parse(Console.ReadLine());
//Console.WriteLine("Enter the account number");
//int num=int.Parse(Console.ReadLine());
//Console.WriteLine("Enter the account balance");
//int balance=int.Parse(Console.ReadLine());
//Account account = null;
//switch(opt)
//{
//    case 1:
//        account= new Currentaccount(num, "Current", balance);
//        break;
//        case 2:
//        account = new Savingsaccount(num, "Savings", balance);
//        break;
//    default:
//        Console.WriteLine("Invalid op-tion");
//        return;

//}
//Console.WriteLine("enter the value to withdraw");
//float withdraw=float.Parse(Console.ReadLine());
//Console.WriteLine("Enter the value to deposit");
//float deposit=float.Parse(Console.ReadLine());
//account.Deposit(deposit);
//account.WithDraw(withdraw);
//account.CalculateInterest();
//account.Display();


//Console.WriteLine("Enter your options for account type either Current or savings.Pres 1 for current and 2 for savings");
//int opt1 = int.Parse(Console.ReadLine());
//Console.WriteLine("Enter the account number");
//int num1 = int.Parse(Console.ReadLine());
//Console.WriteLine("Enter the customer name");
//string name1 = Console.ReadLine();
//Console.WriteLine("Enter the balance");
//int balance1=int.Parse(Console.ReadLine());
//Console.WriteLine("Enter the interest rate");
//int rate=int.Parse(Console.ReadLine());
//bankAccount account1 = null;
//switch (opt)
//{
//    case 1:
//        account1 = new CurrentAccount(num, name1, balance1);
//        break;
//    case 2:
//        account1 = new SavingsAccount(num, name1, balance1,rate);
//        break;
//    default:
//        Console.WriteLine("Invalid op-tion");
//        return;

//}
//Console.WriteLine("enter the value to withdraw");
//float withdraw1 = float.Parse(Console.ReadLine());
//Console.WriteLine("Enter the value to deposit");
//float deposit1 = float.Parse(Console.ReadLine());
//account1.Deposit(deposit1);
//account1.Withdraw(withdraw1);
//account1.CalculateInterest();
//account1.Display();



////task 1

//Console.WriteLine("Enter the customer credit score");
//Double CreditScore = Convert.ToDouble(Console.ReadLine());
//Console.WriteLine("Enter the annual income");
//Double salary = Convert.ToDouble(Console.ReadLine());
//if (CreditScore > 700 && salary > 50000)
//{
//    Console.WriteLine("The customer is eligible to take a loan");
//}
//else
//{
//    Console.WriteLine("The customer is not eligible to take a loan");
//}

//////task2

//Console.WriteLine("Enter the current balance");
//int balance = Convert.ToInt32(Console.ReadLine());

//int Continue = 1;
//while (Continue >= 1)
//{
//    Console.WriteLine("Enter 1 for withdrawal 2 to deposit 3 to check the balance");
//    int opt = Convert.ToInt32(Console.ReadLine());
//    if (opt == 1)
//    {
//        Console.WriteLine("Enter the amount to withdraw");
//        int amount = Convert.ToInt32(Console.ReadLine());
//        if (amount > balance)
//        {
//            Console.WriteLine("Insufficient balance");
//        }
//        else if (amount % 100 != 0 || amount % 500 != 0)
//        {
//            Console.WriteLine("Enter a valid amount");
//        }
//        else
//        {
//            balance = balance - amount;
//        }
//    }
//    else if (opt == 2)
//    {
//        Console.WriteLine("Enter the amount to deposit");
//        int amount = Convert.ToInt32(Console.ReadLine());
//        balance = balance + amount;
//    }
//    else
//    {
//        Console.WriteLine($"The balance amount={balance}");
//    }
//    Console.WriteLine("if you want to continue press 1 or else 0");
//    Continue = Convert.ToInt32(Console.ReadLine());
//}

////task3

//int n = 1;
//Double FutureBalance;
//Double years;
//Double InterestRate;
//Double BalanceAmount;
//while (n == 1)
//{
//    Console.WriteLine("Enter the balance");
//    BalanceAmount = Convert.ToDouble(Console.ReadLine());
//    Console.WriteLine("Enter the annual interest rate ");
//    InterestRate = Convert.ToDouble(Console.ReadLine());
//    Console.WriteLine("Enter the number of years");
//    years = Convert.ToDouble(Console.ReadLine());
//    FutureBalance = Math.Pow((BalanceAmount * (1 + InterestRate / 100)), years);
//    Console.WriteLine($"The future balance after {years} years = {FutureBalance}");
//    Console.WriteLine("If you want to continue press 1 or else 0");
//    n = Convert.ToInt32(Console.ReadLine());
//}

////task4

//Console.WriteLine("Enter the number of customers");
//int m=Convert.ToInt32(Console.ReadLine());
//string[] AccNumber=new string[m];
//int[] Balance = new int[m];
//for(int i=0; i < m;i++)
//{
//    Console.WriteLine("Enter the account number");
//    AccNumber[i] = Console.ReadLine();
//    while (AccNumber[i].Contains("INDB")==false || Regex.IsMatch(AccNumber[i], @"\d{4}$")==false || AccNumber[i].Length!=8)
//    {
//        Console.WriteLine("Enter a valid account number");
//        AccNumber[i] = Console.ReadLine();
//    }


//        Console.WriteLine("Enter the  account balance");
//        Balance[i] = Convert.ToInt32(Console.ReadLine());

//}
//for(int i=0;i<m;i++)
//{
//    Console.WriteLine($"The account {AccNumber[i]} balance = {Balance[i]}");
//}

////task5

//string password=Console.ReadLine();
//if(password.Length>=8 || (Regex.IsMatch(password, @"\d")) || (password.Any(char.IsUpper)))
//{
//    Console.WriteLine("Is a strong password");
//}
//else
//{
//    Console.WriteLine("Password not valid");
//}

////task6