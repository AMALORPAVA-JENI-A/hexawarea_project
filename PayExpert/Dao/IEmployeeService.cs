using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayExpert.Model;

namespace PayExpert.Dao
{
    public interface IEmployeeService
    {
        Employee GetEmployeeById(int  employeeID);
        List<Employee> GetAllEmployees();
        int AddEmployee(string firstName, string lastName, DateTime dateOfBirth, string gender, string email, string phoneNumber, string address, string position, DateTime joiningDate, DateTime? terminationDate);
       int UpdateEmployee(int employeeID, string firstName, string lastName, DateTime dateOfBirth, string gender, string email, string phoneNumber, string address, string position, DateTime joiningDate, DateTime? terminationDate);
        int RemoveEmployee(int employeeID);
    }
}
