using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PayExpert.Model;
using PayExpert.Util;
using PayExpert.ExceptionClass;
using System.Collections;

namespace PayExpert.Dao
{
    public class TaxService:ITaxService
    {
       public int Calculatetax(int employeeID, int taxYear)
        {
            IEmployeeService employeeService = new EmployeeService();
            Employee employee=employeeService.GetEmployeeById(employeeID);
            if(employee==null)
            {
                throw new EmployeeNotFound($"Employee {employeeID} not found");
            }
            SqlConnection con = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;
            string query = $"select top 1 TaxID from Tax order by TaxID desc";
            string query1 = $"insert into Tax (TaxID,EmployeeID,TaxYear,TaxableIncome,TaxAmount)values(@id,@eid,@year,@income,@amt)";
            string query2 = $"SELECT SUM(NetSalary) as salary FROM Payroll WHERE EmployeeID = @employeeID AND YEAR(PayPeriodEndDate) = @taxYear or  YEAR(PayPeriodStartdate)=@taxYear";
            decimal tax = 0;
            int taxID = 0;
            decimal amount = 0;
            
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        taxID = (int)reader["TaxID"];
                    }
                    cmd = new SqlCommand(query2, con);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@taxYear", taxYear);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if(reader["salary"]==null)
                        {
                            throw new PayrollNotFound($"Payroll not found for employee {employeeID} on the year {taxYear}");
                        }
                        amount = (decimal)reader["salary"];
                    }
                    taxID = ++taxID;
                    

                    if (amount <= 25000)
                    {
                        tax = 0;
                    }
                    else if (amount <= 50000)
                    {
                        tax = (amount - 25000) * 0.05M;
                    }
                    else if (amount <= 100000)
                    {
                        tax = (25000 * 0.05M) + (amount - 50000) * 0.20M;
                    }
                    else
                    {
                        tax = (25000 * 0.05M) + (50000 * 0.20M) + (amount - 100000) * 0.30M;
                        tax = (25000 * 0.05M) + (50000 * 0.20M) + (amount - 100000) * 0.30M;
                    }
                    cmd = new SqlCommand(query1, con);
                
                    
                    cmd.Parameters.Add(new SqlParameter("@id", taxID));
                    cmd.Parameters.Add(new SqlParameter("@eid",employeeID));
                    cmd.Parameters.Add(new SqlParameter("@year",taxYear));
                    cmd.Parameters.Add(new SqlParameter("@income", amount));
                    cmd.Parameters.Add(new SqlParameter("@amt", tax));
                    rowsAffected = cmd.ExecuteNonQuery();
                }
                if(rowsAffected<=0)
                {
                    throw new TaxNotAdded("Financial record not added");
                }
            }
            catch(EmployeeNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(TaxNotAdded ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return rowsAffected;
            
        }
        public Tax GetTaxById(int taxID)
        {
            Tax tax = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            string query = $"select * from Tax where TaxID=@id";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", taxID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tax = new Tax
                        {
                            taxID = taxID,
                            employeeID = (int)reader["EmployeeID"],
                            taxYear = (int)reader["TaxYear"],
                            taxableIncome = (decimal)reader["TaxableIncome"],
                            taxAmount = (decimal)reader["TaxAmount"]
                        };
                    }
                    if (tax == null)
                    {
                        throw new TaxNotFound("Tax TaxID {taxID} not found");
                    }
                }
            }
            catch(TaxNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tax;

        }
        public Tax GetTaxesForEmployee(int employeeID)
        {
        Tax tax = null;
        SqlConnection con = null;
        SqlCommand cmd = null;
            string query = $"select * from Tax where EmployeeID=@id";
            try
            {
                IEmployeeService employeeService = new EmployeeService();
                Employee employee = employeeService.GetEmployeeById(employeeID);
                if (employee == null)
                {
                    throw new EmployeeNotFound($"Employee {employeeID} not found");
                }
                using (con = DBUtility.GetConnection())
                {
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", employeeID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tax = new Tax
                        {
                            taxID = (int)reader["TaxID"],
                            employeeID = employeeID,
                            taxYear = (int)reader["TaxYear"],
                            taxableIncome = (decimal)reader["TaxableIncome"],
                            taxAmount = (decimal)reader["TaxAmount"]
                        };
                    }
                    if (tax == null)
                    {
                        throw new TaxNotFound("Tax not found for employee {employeeID}");
                    }
                }
            }
            catch(EmployeeNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(TaxNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tax;

        }
        public List<Tax> GetTaxesForYear(int taxYear)
        {
            Tax tax = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            string query = $"select * from Tax where TaxYear=@year";
            List<Tax> taxList = new List<Tax>();
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@year", taxYear);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tax = new Tax
                        {
                            taxID = (int)reader["TaxID"],
                            employeeID = (int)reader["EmployeeID"],
                            taxYear = taxYear,
                            taxableIncome = (decimal)reader["TaxableIncome"],
                            taxAmount = (decimal)reader["TaxAmount"]

                        };
                        taxList.Add(tax);
                    }
                    if (tax == null)
                    {
                        throw new TaxNotFound("Tax not found for the year {taxYear}");
                    }
                }

            }
            catch(TaxNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return taxList;

        }
    }
}
