using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge2.Model;
using CodingChallenge2.ExceptionClass;
using System.Data.SqlClient;
using CodingChallenge2.Util;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.Design;

namespace CodingChallenge2.Dao
{
    internal class LoanRepositoryImplementation : ILoanRepository
    {
        public int ApplyLoan(Loan loan)
        {
            int rowsAffected = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            string query = @"insert into Loan (LoanId, CustomerId, principleAmount, InterestRate, LoanTerm, LoanType, LoanStatus, PropertyAddress, PropertyValue, CarModel, CarValue)
                                     values (@LoanId, @CustomerId, @PrincipalAmount, @InterestRate, @LoanTerm, @LoanType, @LoanStatus, @PropertyAddress, @PropertyValue, @CarModel, @CarValue)";
            try
            {
                Console.WriteLine("Do you want to apply for this loan ?(yes/no)");
                string confirm = Console.ReadLine();
                if (confirm?.ToLower() != "yes")
                {
                    throw new Exception("Loan application cancelled");

                }
                Customer customer = new Customer();
                using (con = DBUtil.GetConnection())
                {
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoanId", loan.loanId);
                    cmd.Parameters.AddWithValue("@CustomerId", loan.customer.customerID);
                    cmd.Parameters.AddWithValue("@PrincipalAmount", loan.principalAmount);
                    cmd.Parameters.AddWithValue("@InterestRate", loan.interestRate);
                    cmd.Parameters.AddWithValue("@LoanTerm", loan.loanTerm);
                    cmd.Parameters.AddWithValue("@LoanType", loan.loanType);
                    cmd.Parameters.AddWithValue("@LoanStatus", "Pending");
                    if (loan is HomeLoan homeLoan)
                    {
                        cmd.Parameters.AddWithValue("@PropertyAddress", homeLoan.propertyAddress);
                        cmd.Parameters.AddWithValue("@PropertyValue", homeLoan.propertyValue);
                        cmd.Parameters.AddWithValue("@CarModel", DBNull.Value);
                        cmd.Parameters.AddWithValue("@CarValue", DBNull.Value);
                    }
                    else if (loan is CarLoan carLoan)
                    {
                        cmd.Parameters.AddWithValue("@CarModel", carLoan.carModel);
                        cmd.Parameters.AddWithValue("@CarValue", carLoan.carValue);
                        cmd.Parameters.AddWithValue("@PropertyAddress", DBNull.Value);
                        cmd.Parameters.AddWithValue("@PropertyValue", DBNull.Value);
                    }
                    rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Loan successfully inserted into the database.");
                    }
                    

                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rowsAffected;
        }
        public decimal CalculateInterest(int loanId)
        {
            //SqlConnection con = null;
            //SqlCommand cmd = null;
            //string query=@""
            try
            {
                Loan loan = GetLoanById(loanId);
                return CalculateInterest(loan.principalAmount, loan.interestRate, loan.loanTerm);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public decimal CalculateInterest(decimal principal,decimal interestRate,int loanTerm)
        {
            try
            {
                return (principal * interestRate * loanTerm) / (12 * 100);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public int LoanStatus(int loanId) {
            int rowsAffected = 0;
            SqlConnection con = null;
            SqlCommand  cmd = null;
            string query = @"update loan set LoanStatus=@status where loanId=@loanId";
            try
            {
                Loan loan = GetLoanById(loanId);
                string status = loan.customer.creditScore > 650 ? "Approved" : "Rejected";
                using (con = DBUtil.GetConnection())
                {
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@loanId", loanId);
                   rowsAffected=  cmd.ExecuteNonQuery();
                }
                Console.WriteLine($"Loan status updated to {status}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               
            }
            return rowsAffected;
            }
        public decimal CalculateEMI(int loanId)
        {
            
            try
            {
                Loan loan = GetLoanById(loanId);
                return CalculateEMI(loan.principalAmount, loan.interestRate, loan.loanTerm);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public decimal CalculateEMI(decimal principal, decimal interestRate, int loanTerm)
        {
            try
            {
                decimal monthlyRate = interestRate / 12 / 100;

                // Convert to double for Math.Pow
                double r = (double)monthlyRate;
                double n = (double)loanTerm;
                double emi = (double)principal * r * Math.Pow(1 + r, n) / (Math.Pow(1 + r, n) - 1);
                return Convert.ToDecimal(emi);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public void LoanRepayment(int loanId, decimal amount)
        {
            try
            {
                Loan loan = GetLoanById(loanId);
                decimal emi = CalculateEMI(loanId);
                if (amount < emi)
                {
                    throw new InvalidLoanException("Amount is less than one EMI.Payment rejected");
                }
                int emiPaid = (int)(amount / emi);
                Console.WriteLine($"EMI paid={emiPaid}");


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
        }
            public List<Loan> GetAllLoans()
                {
            Loan loan = null;
            List<Loan> loans = new List<Loan>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            string query = @"select * from loan";
            try
            {
                using (con = DBUtil.GetConnection())
                {
                    cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        loan = MapReaderToLoan(reader);
                        loans.Add(loan);
                    }
                    if(reader==null)
                    {
                        throw new InvalidLoanException("loan not found");
                    }
                }
            }
            catch(InvalidLoanException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return loans;
            }

        public Loan GetLoanById(int id)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            Loan loan = null;
            string query = @"select * from loan where LoanId=@id";
            try
            {   
                using(con= DBUtil.GetConnection())
                {
                    cmd= new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {

                        loan= MapReaderToLoan(reader);

                    }
                    else
                    {
                        throw new InvalidLoanException("loan not found");
                    }
                }
            }
            catch(InvalidLoanException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return loan;
        }
private Loan MapReaderToLoan(SqlDataReader reader)
        {
            

            try
            {
                int loanId = Convert.ToInt32(reader["LoanId"]);
                decimal principal = Convert.ToDecimal(reader["PrincipleAmount"]);
                decimal rate = Convert.ToDecimal(reader["InterestRate"]);
                int term = Convert.ToInt32(reader["LoanTerm"]);
                string status = reader["LoanStatus"].ToString();
                string type = reader["LoanType"].ToString();
                int customerId = Convert.ToInt32(reader["CustomerId"]);
                //Customer dummyCustomer = new Customer(Convert.ToInt32(reader["CustomerId"]), "Dummy", "dummy@email.com", "000", "Nowhere", 700); // Replace later
                Customer customer = null;
                customer=GetCustomerById(customerId);
                if (type == "HomeLoan")
                {
                    return new HomeLoan(
                        loanId,
                        customer,
                        Convert.ToDecimal(principal),
                        Convert.ToDecimal(rate),
                        term,
                        type,
                        status,
                        reader["PropertyAddress"].ToString(),
                        Convert.ToDecimal(reader["PropertyValue"])
);


                }
                else if(type =="CarLoan")
                {
                    return new CarLoan(
                                loanId,
                                customer,
                                Convert.ToDecimal(principal),
                                Convert.ToDecimal(rate),
                                term,
                                type, // loanType
                                status,
                                reader["CarModel"].ToString(),
                                Convert.ToDecimal(reader["CarValue"])
                            );

                }
                else
                {
                    Console.WriteLine($"Unknown loan type: {type}");
                    return null;
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error mapping loan: {ex.Message}");
                return null;
            }
        }
        public Customer GetCustomerById(int customerId)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            string query = "SELECT * FROM Customer WHERE CustomerID = @CustomerId";
            Customer customer = null;

            try
            {
                using (con = DBUtil.GetConnection())
                {
                    if (con == null)
                    {
                        Console.WriteLine("Database connection failed.");
                        return null;
                    }

                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        customer = new Customer(
                            Convert.ToInt32(reader["CustomerID"]),
                            reader["Name"].ToString(),
                            reader["EmailAddress"].ToString(),
                            reader["Phone_Number"].ToString(),
                            reader["Address"].ToString(),
                            Convert.ToDecimal(reader["CreditScore"])
                        );
                    }
                    else
                    {
                        Console.WriteLine("Customer not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving customer: " + ex.Message);
            }

            return customer;
        }

    }


}