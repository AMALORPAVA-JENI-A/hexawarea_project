using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayExpert.Model
{
    public class Payroll
    {
        public int payrollID
        {
            get; set;
        }
        public int employeeID
        {
            get; set;
        }
        public DateTime payPeriodStartDate
        {
            get; set;
        }
        public DateTime payPeriodEndDate
        {
            get; set;
        }
        public decimal basicSalary
        {
            get; set;
        }
        public decimal overtimepay
        {
            get; set;
        }
        public decimal deductions
        {
            get; set;
        }
        public decimal netSalary
        {
            get; set;
        }
        public Payroll()
        {
        }
        public Payroll(int payrollID, int employeeID, DateTime payPeriodStartDate, DateTime payPeriodEndDate, decimal basicSalary, decimal overtimepay, decimal deductions, decimal netSalary) 
        {
            this.payrollID = payrollID;
            this.employeeID = employeeID;
            this.payPeriodStartDate = payPeriodStartDate;
            this.payPeriodEndDate = payPeriodEndDate;
            this.basicSalary = basicSalary;
            this.overtimepay = overtimepay;
            this.deductions = deductions;
            this.netSalary = netSalary;
        }
        public override string ToString()
        {
            return $"Pyroll ID={payrollID} , employee ID={employeeID} , start date ={payPeriodStartDate} , end date={payPeriodEndDate} , basic salary={basicSalary} , overtime pay={overtimepay} , deductions={deductions} , net salary={netSalary}";
        }
    }
}
