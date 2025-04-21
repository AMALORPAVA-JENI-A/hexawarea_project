using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayExpert.Util;
using PayExpert.ExceptionClass;
using System.Linq.Expressions;
using PayExpert.Model;

namespace PayExpert.Dao
{
    public class PayrollService:IPayrollService
    {
        public int GeneratePayroll(int employeeID, DateTime startDate, DateTime endDate,decimal basicSalary,decimal overTimePay,decimal deductions)
        {
            SqlConnection con = null;
            SqlCommand cmd= null;
            int rowsAffected = 0;
            int payrollID = 0;
            decimal tax = 0;
            string query = $"select top 1 PayrollID from payroll order by payrollId desc";
            string query1 = $"insert into Payroll(PayrollID,EmployeeID,PayPeriodStartDate,PayPeriodEndDate,BasicSalary,OvertimePay,Deductions,NetSalary)values(@id,@eid,@sdate,@edate,@salary,@overpay,@deduct,@netsalary)";
            string query2 = $"select TaxAmount from Tax where EmployeeID=@eid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        payrollID = (int)reader["PayrollID"];
                    }
                    cmd= new SqlCommand(query2, con);
                    cmd.Parameters.AddWithValue("@eid", employeeID);
                    reader = cmd.ExecuteReader();
                    if(reader.Read()) 
                    {
                            tax = (decimal)reader["TaxAmount"];
                    }
                }
                payrollID = ++payrollID;
                int months = (endDate.Year - startDate.Year) * 12 + endDate.Month - startDate.Month;
                decimal netSalary = (basicSalary * months) + overTimePay - deductions-tax;
                using (con = DBUtility.GetConnection())
                {
                    cmd = new SqlCommand(query1, con);
                    cmd.Parameters.Add(new SqlParameter("@id", payrollID));
                    cmd.Parameters.Add(new SqlParameter("@eid", employeeID));
                    cmd.Parameters.Add(new SqlParameter("@sdate", startDate));
                    cmd.Parameters.Add(new SqlParameter("@edate", endDate));
                    cmd.Parameters.Add(new SqlParameter("@salary", basicSalary));
                    cmd.Parameters.Add(new SqlParameter("@overpay", overTimePay));
                    cmd.Parameters.Add(new SqlParameter("@deduct", deductions));
                    cmd.Parameters.Add(new SqlParameter("@netsalary", netSalary));
                    rowsAffected = cmd.ExecuteNonQuery();

                }
                if (rowsAffected <= 0)
                {
                    throw new PayrollNotAdded("Payroll not added");
                }
            }
            catch (PayrollNotAdded ex)
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
            
            return rowsAffected;
        }
        public Payroll GetPayrollById(int payrollID)
        {
            Payroll payroll = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            string query = $"select * from payroll where payrollId=@id";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", payrollID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        payroll = new Payroll
                        {
                            payrollID = (int)reader["PayrollID"],
                            employeeID = (int)reader["EmployeeID"],
                            payPeriodStartDate = (DateTime)reader["PayPeriodStartDate"],
                            payPeriodEndDate = (DateTime)reader["PayPeriodEndDate"],
                            basicSalary = (decimal)reader["BasicSalary"],
                            overtimepay = (decimal)reader["OvertimePay"],
                            deductions = (decimal)reader["Deductions"],
                            netSalary = (decimal)reader["NetSalary"]
                        };

                    }
                    if (payroll == null)
                    {
                        throw new PayrollNotFound($"Payroll {payrollID} not found");
                    }
                }
            }
            catch(PayrollNotFound ex)
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
            return payroll;
        }
        public Payroll GetPayrollsForEmployee(int employeeID)
        {
            Payroll payroll = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            IEmployeeService employeeService = new EmployeeService();
            Employee employee =employeeService.GetEmployeeById(employeeID);
            if (employee == null)
            {
                throw new EmployeeNotFound($"Employee {employeeID} not found");
            }
            string query = $"select * from Payroll where employeeID=@id";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", employeeID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        payroll = new Payroll
                        {
                            payrollID = (int)reader["PayrollID"],
                            employeeID = (int)reader["EmployeeID"],
                            payPeriodStartDate = (DateTime)reader["PayPeriodStartDate"],
                            payPeriodEndDate = (DateTime)reader["PayPeriodEndDate"],
                            basicSalary = (decimal)reader["BasicSalary"],
                            overtimepay = (decimal)reader["OvertimePay"],
                            deductions = (decimal)reader["Deductions"],
                            netSalary = (decimal)reader["NetSalary"]
                        };

                    }
                    if (payroll == null)
                    {
                        throw new PayrollNotFound($"Payroll not found for the employee {employeeID}");
                    }
                }

            }
            catch(EmployeeNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(PayrollNotFound ex)
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
            return payroll;
        }
        public List<Payroll> GetPayrollsForPeriod(DateTime startDate, DateTime endDate)
        {
            List<Payroll> payrollList=new List<Payroll>();
            Payroll payroll = null ;

            SqlConnection con = null;
            SqlCommand cmd = null;
            string query = $"select * from payroll where PayPeriodStartDate>=@sdate and  PayPeriodEndDate<=@edate";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@sdate", startDate);
                    cmd.Parameters.AddWithValue("@edate", endDate);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        payroll = new Payroll
                        {
                            payrollID = (int)reader["PayrollID"],
                            employeeID = (int)reader["EmployeeID"],
                            payPeriodStartDate = (DateTime)reader["PayPeriodStartDate"],
                            payPeriodEndDate = (DateTime)reader["PayPeriodEndDate"],
                            basicSalary = (decimal)reader["BasicSalary"],
                            overtimepay = (decimal)reader["OvertimePay"],
                            deductions = (decimal)reader["Deductions"],
                            netSalary = (decimal)reader["NetSalary"]
                        };
                        payrollList.Add(payroll);
                    }
                    if(payroll==null)
                    {
                        throw new PayrollNotFound("No payroll in this date");
                    }
                }
            }
            catch(PayrollNotFound ex)
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
            return payrollList;
        }
        public decimal CalculateNetSalary(Payroll payroll)
        {
            
            return payroll.basicSalary+payroll.overtimepay-payroll.deductions;
        }
        public decimal GrossSalary(Payroll payroll)
        {

            return payroll.basicSalary + payroll.overtimepay;
        }
    }   

}
