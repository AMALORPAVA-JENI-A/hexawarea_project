using CodingChallenge2.Dao;
using CodingChallenge2.Model;

namespace CodingChallenge2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILoanRepository loanRepo = new LoanRepositoryImplementation();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n====== Loan Management System ======");
                Console.WriteLine("1. Apply Loan");
                Console.WriteLine("2. View All Loans");
                Console.WriteLine("3. Get Loan By ID");
                Console.WriteLine("4. Loan Repayment");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ApplyLoan(loanRepo);
                        break;
                    case "2":
                        GetAllLoans(loanRepo);
                        break;
                    case "3":
                        GetLoanById(loanRepo);
                        break;
                    case "4":
                        LoanRepayment(loanRepo);
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting the system. Thank you!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void ApplyLoan(ILoanRepository loanRepo)
        {
            try
            {
                Console.Write("Enter Loan Type (HomeLoan / CarLoan): ");
                string type = Console.ReadLine();

                Console.Write("Enter Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());

                Console.Write("Enter Principal Amount: ");
                decimal principal = decimal.Parse(Console.ReadLine());

                Console.Write("Enter Interest Rate (%): ");
                decimal rate = decimal.Parse(Console.ReadLine());

                Console.Write("Enter Loan Term (months): ");
                int term = int.Parse(Console.ReadLine());

                string status = "Pending";

                Loan loan = null;

                if (type == "HomeLoan")
                {
                    Console.Write("Enter Property Address: ");
                    string address = Console.ReadLine();

                    Console.Write("Enter Property Value: ");
                    decimal value = decimal.Parse(Console.ReadLine());

                    loan = new HomeLoan(0, new Customer(customerId, "", "", "", "", 0), principal, rate, term, type, status, address, value);
                }
                else if (type == "CarLoan")
                {
                    Console.Write("Enter Car Model: ");
                    string model = Console.ReadLine();

                    Console.Write("Enter Car Value: ");
                    decimal value = decimal.Parse(Console.ReadLine());

                    loan = new CarLoan(0, new Customer(customerId, "", "", "", "", 0), principal, rate, term, type, status, model, value);
                }
                else
                {
                    Console.WriteLine("Invalid Loan Type.");
                    return;
                }

                Console.Write("Do you want to submit the loan application? (Yes/No): ");
                string confirm = Console.ReadLine();

                if (confirm.ToLower() == "yes")
                {
                    loanRepo.ApplyLoan(loan);
                }
                else
                {
                    Console.WriteLine("Loan application cancelled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in loan application: " + ex.Message);
            }
        }

        static void GetLoanById(ILoanRepository loanRepo)
        {
            try
            {
                Console.Write("Enter Loan ID: ");
                int id = int.Parse(Console.ReadLine());
                Loan loan=loanRepo.GetLoanById(id);
                Console.WriteLine(loan);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching loan: " + ex.Message);
            }
        }
        public static void GetAllLoans(ILoanRepository loanRepo)
        {
            try
            {
                List<Loan> loans = loanRepo.GetAllLoans();

               
                    foreach (Loan loan in loans)
                    {
                        Console.WriteLine(loan);
                    }
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching loans: " + ex.Message);
            }
        }

        static void LoanRepayment(ILoanRepository loanRepo)
        {
            try
            {
                Console.Write("Enter Loan ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Repayment Amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                loanRepo.LoanRepayment(id, amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during loan repayment: " + ex.Message);
            }
        }
    }
    
}
