using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PayExpert.Model;
using PayExpert.Util;
using PayExpert.ExceptionClass;
using System.Security.Principal;
using System.Data;

namespace PayExpert.Dao
{
    public class EmployeeService:IEmployeeService
    {
        public Employee GetEmployeeById(int employeeID)
        {
            Employee employee = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = $"select * from employee where employeeID=@id";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@id", employeeID);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                       
                        employee = new Employee
                        {
                            employeeID = (int)reader["employeeId"],
                            firstName = (string)reader["FirstName"],
                            lastName = (string)reader["LastName"],
                            dateOfBirth = (DateTime)reader["DateOfBirth"],
                            gender = (string)reader["Gender"],
                            email = (string)reader["Email"],
                            phoneNumber = (string)reader["PhoneNumber"],
                            address = (string)reader["Address"],
                            position = (string)reader["Position"],
                            joiningDate = (DateTime)reader["JoiningDate"],
                            terminationDate = reader["TerminationDate"] == DBNull.Value ? null : (DateTime?)reader["TerminationDate"]
                        };

                    }
                    if (employee == null)
                    {
                        throw new EmployeeNotFound($"Employee {employeeID} not found");
                    }
                }
            }
            catch (EmployeeNotFound ex)
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
            return employee;
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Employee employee = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = $"select * from employee";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employee = new Employee
                        {
                            employeeID = (int)reader["employeeId"],
                            firstName = (string)reader["FirstName"],
                            lastName = (string)reader["LastName"],
                            dateOfBirth = (DateTime)reader["DateOfBirth"],
                            gender = (string)reader["Gender"],
                            email = (string)reader["Email"],
                            phoneNumber = (string)reader["PhoneNumber"],
                            address = (string)reader["Address"],
                            position = (string)reader["Position"],
                            joiningDate = (DateTime)reader["JoiningDate"],
                            terminationDate = reader["TerminationDate"] == DBNull.Value ? null : (DateTime?)reader["TerminationDate"]
                        };
                        employees.Add(employee);
                    }
                    if (employee == null)
                    {
                        throw new EmployeeNotFound("no data of employees found");
                    }
                }

            }
            catch(EmployeeNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return employees;
        }
        public int UpdateEmployee(int employeeID, string firstName, string lastName, DateTime dateOfBirth , string gender, string email, string phoneNumber, string address, string position, DateTime joiningDate, DateTime? terminationDate)
        {
            int rowsAffected = 0;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = $"update employee set FirstName=@fname,LastName=@lname,DateOfBirth=@dob,Gender=@gender,Email=@email,PhoneNumber=@phoneno,Address=@address,Position=@position,JoiningDate=@joindate,TerminationDate=@terminatedate where EmployeeId=@id";
            try
            {
                Employee employee = GetEmployeeById(employeeID);
                if (employee == null)
                {
                    throw new EmployeeNotFound("Employee {employeeID} not found");
                }

                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.Add(new SqlParameter("@id", employeeID));
                    command.Parameters.Add(new SqlParameter("@fname", firstName));
                    command.Parameters.Add(new SqlParameter("@lname", lastName));
                    command.Parameters.Add(new SqlParameter("@dob", dateOfBirth));
                    command.Parameters.Add(new SqlParameter("@gender", gender));
                    command.Parameters.Add(new SqlParameter("@email", email));
                    command.Parameters.Add(new SqlParameter("@phoneno", phoneNumber));
                    command.Parameters.Add(new SqlParameter("@address", address));
                    command.Parameters.Add(new SqlParameter("@position", position));
                    command.Parameters.Add(new SqlParameter("@joindate", joiningDate));
                    command.Parameters.AddWithValue("@terminatedate", (object?)terminationDate ?? DBNull.Value);
                    rowsAffected = command.ExecuteNonQuery();
                }
                if (rowsAffected <= 0)
                {
                    throw new EmployeeNotAdded("Employee {employeeID} not updated");
                }
            }
            catch (EmployeeNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (EmployeeNotAdded ex)
            {
                Console.WriteLine(ex.Message);
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
       

        
        public int AddEmployee(string firstName, string lastName, DateTime dateOfBirth, string gender, string email, string phoneNumber, string address, string position, DateTime joiningDate, DateTime? terminationDate)
        {
            SqlConnection con = null;
            SqlCommand command = null;
            int rowsAffected = 0;
            int employeeId = 0;                              
            string query = $"Insert into Employee(EmployeeID,FirstName,LastName,DateOfBirth,Gender,Email,PhoneNumber,Address,Position,JoiningDate,TerminationDate)values(@id,@fname,@lname,@dob,@gender,@email,@phoneno,@address,@position,@joindate,@terminatedate)";
            string query1 = $"select top 1 EmployeeID from Employee order by EmployeeID desc";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query1, con);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        employeeId = (int)reader["EmployeeID"];
                    }

                }
 
                employeeId=++employeeId;
                Employee employee = new Employee
                {
                    employeeID = employeeId,
                    firstName = firstName,
                    lastName= lastName,
                    dateOfBirth = dateOfBirth,
                    gender = gender,
                    email = email,
                    phoneNumber = phoneNumber,
                    address = address,
                    position = position,
                    joiningDate = joiningDate,
                    terminationDate = terminationDate

                };
               
                using (con= DBUtility.GetConnection())
                {
                    command= new SqlCommand(query, con);
                    command.Parameters.Add(new SqlParameter("@id", employee.employeeID));
                    command.Parameters.Add(new SqlParameter("@fname", employee.firstName));
                    command.Parameters.Add(new SqlParameter("@lname",employee.lastName));
                    command.Parameters.Add(new SqlParameter("@dob",employee.dateOfBirth));
                    command.Parameters.Add(new SqlParameter("@gender", employee.gender));
                    command.Parameters.Add(new SqlParameter("@email", email));
                    command.Parameters.Add(new SqlParameter("@phoneno", phoneNumber));
                    command.Parameters.Add(new SqlParameter("@address", address));
                    command.Parameters.Add(new SqlParameter("@position", position));
                    command.Parameters.Add(new SqlParameter("@joindate", joiningDate));
                    command.Parameters.AddWithValue("@terminatedate", (object?)terminationDate ?? DBNull.Value);

                    rowsAffected = command.ExecuteNonQuery();
                }
                if (rowsAffected <= 0)
                {
                    throw new EmployeeNotAdded("Employee not added");
                }
                
            }
            catch(EmployeeNotAdded ex)
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
        public int RemoveEmployee(int employeeID)
        {
            SqlConnection con = null;
            SqlCommand command = null;
            int rowsAffected = 0;
            string query = $"delete from employee where EmployeeID=@id";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.Add(new SqlParameter("@id", employeeID));
                    rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        throw new EmployeeNotAdded($"Employee {employeeID} not deleted");
                    }
                }
            }
            catch (EmployeeNotAdded ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rowsAffected ;
        }
    }
}