using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayExpert.Model;
using PayExpert.Util;
using PayExpert.ExceptionClass;

namespace PayExpert.Dao
{
    public class FinancialRecordService:IFinancialRecordService
    {
        public int AddFinancialRecord(int employeeID, DateTime recordDate,string description, decimal amount, string recordType)
        {
            int rowsAffected = 0;
            SqlConnection con=null;
            SqlCommand cmd = null;
            IEmployeeService employeeService=new EmployeeService();
            Employee employee = employeeService.GetEmployeeById(employeeID);
            int recordID = 0;
            string query = $"insert into FinancialRecord(RecordID,EmployeeID,RecordDate,Descriptions,Amount,RecordType)values(@id,@eid,@date,@description,@amt,@type)";
            string query1 = $"select top 1 RecordID from FinancialRecord order by RecordID desc";
            try

            {
                if (employee == null)
                {
                    throw new EmployeeNotFound($"Employee {employeeID} not found");
                }
                using (con = DBUtility.GetConnection())
                {
                    cmd = new SqlCommand(query1, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        recordID = (int)reader["RecordID"];
                    }
                    recordID = ++recordID;
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@id", recordID));
                    cmd.Parameters.Add(new SqlParameter("@eid", employeeID));
                    cmd.Parameters.Add(new SqlParameter("@description", description));
                    cmd.Parameters.Add(new SqlParameter("@amt", amount));
                    cmd.Parameters.Add(new SqlParameter("@type", recordType));
                    cmd.Parameters.Add(new SqlParameter("@date", recordDate));
                    rowsAffected = cmd.ExecuteNonQuery();
                }

                if (rowsAffected <= 0)
                {
                    throw new FinanceRecordAdded("Financial record not added");
                }
            }
            catch(EmployeeNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FinanceRecordAdded ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rowsAffected;
        }
        public FinancialRecord GetFinancialRecordsById(int recordID)
        {
            FinancialRecord record = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            IEmployeeService employeeService = null;
            string query = $"select * from FinancialRecord where RecordID=@id";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", recordID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        record = new FinancialRecord
                        {
                            recordID = recordID,
                            employeeID = (int)reader["EmployeeID"],
                            recordDate = (DateTime)reader["RecordDate"],
                            description = (string)reader["Descriptions"],
                            amount = (decimal)reader["Amount"],
                            recordType = (string)reader["RecordType"]
                        };
                    }
                }
                if(record==null)
                {
                    throw new RecordNotFound($"Record {recordID} not found");
                }
            }
            catch(RecordNotFound ex)
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
            return record;
        }
        public FinancialRecord GetFinancialRecordsForEmployee(int employeeID)
        {
            FinancialRecord record = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            IEmployeeService employeeService = new EmployeeService();
            Employee employee = employeeService.GetEmployeeById(employeeID);
            string query = $"select * from FinancialRecord where EmployeeID=@id";
            try
            {
                if (employee == null)
                {
                    throw new EmployeeNotFound("Employee {employeeID} not found");
                }
                using (con = DBUtility.GetConnection())
                {
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", employeeID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        record = new FinancialRecord
                        {
                            employeeID = employeeID,
                            recordID = (int)reader["RecordID"],
                            recordDate = (DateTime)reader["RecordDate"],
                            description = (string)reader["Descriptions"],
                            amount = (decimal)reader["Amount"],
                            recordType = (string)reader["RecordType"]
                        };
                    }
                }
                if (record == null)
                {
                    throw new RecordNotFound("Record not found for employee{employeeID}");
                }
            }
            catch(EmployeeNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (RecordNotFound ex)
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
            return record;
        }
        public List<FinancialRecord> GetFinancialRecordsForDate(DateTime recordDate)
        {
            FinancialRecord record = null;
            List<FinancialRecord> recordList= new List<FinancialRecord>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            string query = $"select * from FinancialRecord where RecordDate=@date";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    cmd = new SqlCommand(query, con);
                    
                    cmd.Parameters.AddWithValue("@date", recordDate);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        record = new FinancialRecord
                        {
                            recordID = (int)reader["RecordID"],
                            employeeID = (int)reader["employeeID"],
                            recordDate = (DateTime)reader["RecordDate"],
                            description = (string)reader["Descriptions"],
                            amount = (decimal)reader["Amount"],
                            recordType = (string)reader["RecordType"]
                        };
                        recordList.Add(record);
                        ;
                    }
                    if (record == null)
                    {
                        throw new RecordNotFound("No records");
                    }

                }
            }
            catch(RecordNotFound ex)
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
            return recordList;
        }
    }
}
