using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayExpert.Model;

namespace PayExpert.Dao
{
    public interface IPayrollService
    {
        int GeneratePayroll(int employeeID, DateTime startDate, DateTime endDate, decimal BasicSalary, decimal OverTimePay, decimal deductions);
        Payroll GetPayrollById(int payrollId);
        Payroll GetPayrollsForEmployee(int employeeID);
        List<Payroll> GetPayrollsForPeriod(DateTime startDate, DateTime endDate);


    }
}
