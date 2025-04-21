using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PayExpert.Dao;

namespace PayExpert.Model
{
    public class ValidationService
    {
        IEmployeeService employeeService = new EmployeeService();
        ITaxService taxService = new TaxService();
        IFinancialRecordService financialRecordService = new FinancialRecordService();
        IPayrollService payrollService = new PayrollService();


        public void GetEmployeebyId()
        {

            int id = EmployeeId();
            Employee employee = employeeService.GetEmployeeById(id);
            Console.WriteLine(employee);
        }
        public void GetAllEmployees()
        {
            List<Employee> employee = employeeService.GetAllEmployees();
            foreach (Employee emp in employee)
            {
                Console.WriteLine(emp);
            }
        }
        public void AddEmployee()
        {
            string firstName = FirstName();
            string lastName = LastName();
            DateTime dob = DOB();
            string gender = Gender();
            string email = Email();
            string phoneNo = PhoneNo();
            string address = Address();
            string position = Position();
            DateTime joinDate = JoiningDate();
            DateTime? terminateDate = TerminationDate();
            int add = employeeService.AddEmployee(firstName, lastName, dob, gender, email, phoneNo, address, position, joinDate, terminateDate);
            Console.WriteLine($"Rows affected={add}");
        }
        public void UpdateEmployee()
        {
            int id = EmployeeId();

            // Fetch existing employee details
            Employee existing = employeeService.GetEmployeeById(id);
            if (existing == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            // Ask user which fields to update
            Console.Write("Update First Name? (y/n): ");
            string firstName = Console.ReadLine().ToLower() == "y" ? FirstName() : existing.firstName;

            Console.Write("Update Last Name? (y/n): ");
            string lastName = Console.ReadLine().ToLower() == "y" ? LastName() : existing.lastName;

            Console.Write("Update DOB? (y/n): ");
            DateTime dob = Console.ReadLine().ToLower() == "y" ? DOB() : existing.dateOfBirth;

            Console.Write("Update Gender? (y/n): ");
            string gender = Console.ReadLine().ToLower() == "y" ? Gender() : existing.gender;

            Console.Write("Update Email? (y/n): ");
            string email = Console.ReadLine().ToLower() == "y" ? Email() : existing.email;

            Console.Write("Update Phone No? (y/n): ");
            string phoneNo = Console.ReadLine().ToLower() == "y" ? PhoneNo() : existing.phoneNumber;

            Console.Write("Update Address? (y/n): ");
            string address = Console.ReadLine().ToLower() == "y" ? Address() : existing.address;

            Console.Write("Update Position? (y/n): ");
            string position = Console.ReadLine().ToLower() == "y" ? Position() : existing.position;

            Console.Write("Update Joining Date? (y/n): ");
            DateTime joinDate = Console.ReadLine().ToLower() == "y" ? JoiningDate() : existing.joiningDate;

            Console.Write("Update Termination Date? (y/n): ");
            DateTime? terminateDate = Console.ReadLine().ToLower() == "y" ? TerminationDate() : existing.terminationDate;

            int result = employeeService.UpdateEmployee(id, firstName, lastName, dob, gender, email, phoneNo, address, position, joinDate, terminateDate);
            Console.WriteLine($"Rows affected = {result}");
        }

        public void RemoveEmployee()
        {
            int id = EmployeeId();
            int remove = employeeService.RemoveEmployee(id);
            Console.WriteLine($"Rows Affected={remove}");
        }
        public void GeneratePayroll()
        {
            int id=EmployeeId();
            
            DateTime sdate=PayPeriodStartDate();
            DateTime edate=PayPeriodEndDate();
            decimal salary = BasicSalary();
            decimal pay=OvertimePay();
            decimal deduction = Deductions();
            int payroll = payrollService.GeneratePayroll(id,sdate,edate,salary,pay,deduction);
            Console.WriteLine($"Rows affected={payroll}");
        }
        public void GetPayrollById()
        {
            int id = PayrollID();
            Payroll payroll=payrollService.GetPayrollById(id);
            Console.WriteLine(payroll);
        }
        public void GetPayrollsForEmployee()
        {
            int id = EmployeeId();
            Payroll payroll = payrollService.GetPayrollsForEmployee(id);
            Console.WriteLine(payroll);
        }
        public void GetPayrollsForPeriod()
        {
            DateTime sdate = PayPeriodStartDate();
            DateTime edate = PayPeriodEndDate();
            List<Payroll> plist=payrollService.GetPayrollsForPeriod(sdate,edate);
            foreach(Payroll payroll in plist)
            {
                Console.WriteLine(payroll);
            }
        }
        public void CalculateTax()
        {
            int year = TaxYear();
            int id = EmployeeId();
            int rows=taxService.Calculatetax(id,year);
            Console.WriteLine($"Rows Affected={rows}");
        }
        public void GetTaxById()
        {
            int id = TaxID();
            Tax tax=taxService.GetTaxById(id);
            Console.WriteLine(tax);
        }
        public void GetTaxForEmployee()
        {
            int id = EmployeeId();
            Tax tax=taxService.GetTaxesForEmployee(id);
            Console.WriteLine(tax);
        }
        public void GetTaxesForYear()
        {
            int year = TaxYear();
            List<Tax> tax=taxService.GetTaxesForYear(year);
            foreach(Tax tax1 in tax)
            {
                Console.WriteLine(tax1);
            }
        }
        public void AddFinancialRecord()
        {
            int id=EmployeeId();
            decimal amt = amount();
            DateTime recordDate = RecordDate();
            string description = Description();
            string type = RecordType();
            int rows = financialRecordService.AddFinancialRecord(id, recordDate, description, amt, type);
            Console.WriteLine($"Rows Affected ={rows}");
        }
        public void GetFinancialRecordById()
        {
            int id=recordID();
            FinancialRecord record=financialRecordService.GetFinancialRecordsById(id);
            Console.WriteLine(record);
        }
        public void GetFinancialRecordsForEmployee()
        {
            int id = EmployeeId();
            FinancialRecord record = financialRecordService.GetFinancialRecordsById(id);
            Console.WriteLine(record);
        }
        public void GetFinancialRecordsForDate()
        {
            DateTime recordDate=RecordDate();
            List<FinancialRecord> record=financialRecordService.GetFinancialRecordsForDate(recordDate);
            foreach(FinancialRecord record2 in record)
            {
                Console.WriteLine(record2);
            }
        }
        public string FirstName()
        {
            try
            {
                Console.WriteLine("Enter the First name of the employee");
                return Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return FirstName();
            }
        }
        public int EmployeeId()
        {
            try
            {
                Console.WriteLine("Enter the employee id");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EmployeeId();
            }
        }
        public string LastName()
        {
            try
            {
                Console.WriteLine("Enter the last name");
                return Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return LastName();
            }
        }
        public DateTime DOB()
        {
            try
            {

                Console.WriteLine("Enter the date of birth (dd-mm-yyyy)");
                return DateTime.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return DOB();
            }
        }
        public string Gender()
        {
            try
            {
                Console.WriteLine("Enter the gender");
                return Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Gender();
            }
        }
        public string Email()
        {
            Console.WriteLine("Enter the mail id");
            string EmailAddress = Console.ReadLine();
            try
            {
                if (!Regex.IsMatch(EmailAddress, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    throw new Exception("Invalid mail");
                }
                return EmailAddress;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Email();
            }
        }
        public string PhoneNo()
        {
            Console.WriteLine("Enter the phone number");
            string phoneNo = Console.ReadLine();
            try
            {
                if (!Regex.IsMatch(phoneNo, @"^\d{10}$"))
                {
                    throw new Exception("Invalid phone number");
                }
                return phoneNo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return PhoneNo();
            }

        }
        public string Address()
        {
            try
            {
                Console.WriteLine("Enter the address");
                string address = Console.ReadLine();
                return address;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Address();
            }

        }
        public string Position()
        {
            try
            {
                Console.WriteLine("Enter the position");
                string position = Console.ReadLine();
                return position;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Position();
            }
        }
        public DateTime JoiningDate()

        {
            try
            {
                Console.WriteLine("Enter the  joining date (dd-mm-yyyy)");
                return DateTime.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return JoiningDate();
            }
        }
        public DateTime? TerminationDate()
        {
            Console.WriteLine("Enter the termination date (dd-mm-yyyy) or press Enter to skip:");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return null;
            try
            {
                return DateTime.ParseExact(input, "dd-MM-yyyy", null);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please enter in dd-MM-yyyy format.");
                return TerminationDate();
            }
        }
        public int PayrollID()
        {
            try
            {
                Console.WriteLine("Enter the payroll id");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                {
                    Console.WriteLine(ex.Message);
                    return PayrollID();
                }
            }

        }
        public DateTime PayPeriodStartDate()
        {
            try
            {
                Console.WriteLine("Enter the start date (dd-mm-yyyy)");
                return DateTime.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return PayPeriodStartDate();
            }
        }
        public DateTime PayPeriodEndDate()
        {
            try
            {
                Console.WriteLine("Enter the end date (dd-mm-yyyy)");
                return DateTime.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return PayPeriodEndDate();
            }
        }
        public decimal BasicSalary()
        {
            try
            {
                Console.WriteLine("Enter the basic salary");
                return Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BasicSalary();
            }
        }
        public decimal OvertimePay()
        {
            try
            {
                Console.WriteLine("Enter the overtime pay");
                return Convert.ToDecimal(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return OvertimePay();
            }
        }
        public decimal Deductions()
        {
            try
            {
                Console.WriteLine("Enter the deduction amount");
                return Convert.ToDecimal(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return Deductions();
            }
        }
        public int TaxID()
        {
            try
            {
                Console.WriteLine("Enter the tax ID");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return TaxID();
            }
        }
        public int TaxYear()
        {
            try
            {
                Console.WriteLine("Enter the tax year");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return TaxYear();
            }
        }
        
        public int recordID()
        {
            try
            {
                Console.WriteLine("Enter the record ID");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return recordID();
            }
        }
        public DateTime RecordDate()
        {
            try
            {
                Console.WriteLine("Enter the record date (dd-mm-yyyy)");
                return Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RecordDate();
            }
        }
        public string Description()
        {
            try
            {
                Console.WriteLine("Enter the description");
                return Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Description();
            }
        }
        public decimal amount()
        {
            try
            {
                Console.WriteLine("Enter the amount");
                return Convert.ToDecimal(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return amount();
            }
        }
        public string RecordType()
        {
            try
            {
                Console.WriteLine("Enter the record type");
                return Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return RecordType();
            }
        }

    }
}
