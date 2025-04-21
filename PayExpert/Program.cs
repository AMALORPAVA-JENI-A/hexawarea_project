using PayExpert.Model;

namespace PayExpert
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ValidationService input = new ValidationService();
            while (true)
            {
                try
                {
                    Console.WriteLine("----------------Payroll Management System----------------");
                    Console.WriteLine("1.Add an employee");
                    Console.WriteLine("2.Get employee Details for an id");
                    Console.WriteLine("3.List all employees");
                    Console.WriteLine("4.Update employee details");
                    Console.WriteLine("5.Remove employee");
                    Console.WriteLine("6.Generate payroll");
                    Console.WriteLine("7.Get payroll details for an id");
                    Console.WriteLine("8.Get payroll for an employee");
                    Console.WriteLine("9.Get payroll for a period");
                    Console.WriteLine("10.Calculate tax");
                    Console.WriteLine("11.Get tax details for an id");
                    Console.WriteLine("12.Get tax for an employee");
                    Console.WriteLine("13.Get tax for a year");
                    Console.WriteLine("14.Add financial record");
                    Console.WriteLine("15.Get financial record for an id");
                    Console.WriteLine("16.Get financial record for employee");
                    Console.WriteLine("17.Get financial records for a date");
                    Console.WriteLine("0 to exit");
                    Console.WriteLine("Enter your choice");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("-----------------------------------------------------------");

                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("----------------GoodBye-----------------");
                            return;
                        case 1:
                            input.AddEmployee();
                            break;
                        case 2:
                            input.GetEmployeebyId();
                            break;
                        case 3:
                            input.GetAllEmployees();
                            break;
                        case 4:
                            input.UpdateEmployee();
                            break;
                        case 5:
                            input.RemoveEmployee();
                            break;
                        case 6:
                            input.GeneratePayroll();
                            break;
                        case 7:
                            input.GetPayrollById();
                            break;
                        case 8:
                            input.GetPayrollsForEmployee();
                            break;
                        case 9:
                            input.GetPayrollsForPeriod();
                            break;
                        case 10:
                            input.CalculateTax();
                            break;
                        case 11:
                            input.GetTaxById();
                            break;
                        case 12:
                            input.GetTaxForEmployee();
                            break;
                        case 13:
                            input.GetTaxesForYear();
                            break;
                        case 14:
                            input.AddFinancialRecord();
                            break;
                        case 15:
                            input.GetFinancialRecordById();
                            break;
                        case 16:
                            input.GetFinancialRecordsForEmployee();
                            break;
                        case 17:
                            input.GetFinancialRecordsForDate();
                            break;
                        default:
                            Console.WriteLine("Enter a valid option");
                            break;

                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid input format. Please enter a number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
    


