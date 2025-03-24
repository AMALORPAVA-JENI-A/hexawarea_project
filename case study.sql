create database payexpert;
use payexpert;
create table Employee(EmployeeID int constraint pk_employee_id primary key,FirstName varchar(20),LastName varchar(20),DateOfBirth date,Gender character,Email varchar(20),PhoneNumber varchar(10),Address text,Position varchar(30),JoiningDate date,TerminationDate date);
create table Payroll(PayrollID int constraint pk_payroll_id primary key,EmployeeID int constraint fk_employee_id foreign key references Employee(EmployeeID),payPeriodStartDate date,PayPeriodEndDate date,BasicSalary int,OvertimePay int,Deductions int,NetSalary int);
create table Tax(TaxID int constraint pk_tax_id primary key,EmployeeID int constraint fk_employeeid foreign key references Employee(EmployeeID),TaxYear int,TaxableIncome int,TaxAmount int);
create table FinancialRecord(RecordID int,EmployeeID int,RecordDate date,Description varchar(30),Amount int,RecordType varchar(20));
insert into Employee (EmployeeID, FirstName, LastName, DateOfBirth, Gender, Email, PhoneNumber, Address, Position, JoiningDate, TerminationDate) values
(1, 'Amit', 'Sharma', '1985-06-15', 'M', 'amit.sharma@email.com', '9876543210', '123 MG Road, Delhi', 'Manager', '2015-04-20', NULL),
(2, 'Priya', 'Iyer', '1990-08-22', 'F', 'priya.iyer@email.com', '8765432109', '456 Brigade Road, Bangalore', 'Engineer', '2018-05-15', NULL),
(3, 'Ravi', 'Verma', '1992-12-10', 'M', 'ravi.verma@email.com', '7654321098', '789 Park Street, Kolkata', 'HR', '2019-07-10', '2023-12-31'),
(4, 'Sneha', 'Patel', '1988-04-05', 'F', 'sneha.patel@email.com', '6543210987', '234 CG Road, Ahmedabad', 'Accountant', '2017-09-01', NULL),
(5, 'Vikas', 'Reddy', '1995-09-30', 'M', 'vikas.reddy@email.com', '5432109876', '890 Hitech City, Hyderabad', 'Developer', '2020-06-21', NULL),
(6, 'Ananya', 'Nair', '1987-03-14', 'F', 'ananya.nair@email.com', '4321098765', '567 Marine Drive, Mumbai', 'Analyst', '2016-11-10', '2022-05-30'),
(7, 'Arjun', 'Mishra', '1993-07-18', 'M', 'arjun.mishra@email.com', '3210987654', '901 MG Road, Pune', 'Consultant', '2021-01-05', NULL),
(8, 'Meera', 'Joshi', '1986-05-25', 'F', 'meera.joshi@email.com', '2109876543', '345 Anna Nagar, Chennai', 'Technician', '2014-12-14', '2021-08-15'),
(9, 'Kiran', 'Singh', '1991-11-02', 'M', 'kiran.singh@email.com', '1098765432', '678 FC Road, Pune', 'Supervisor', '2018-03-12', NULL),
(10, 'Pooja', 'Yadav', '1989-01-20', 'F', 'pooja.yadav@email.com', '9988776655', '789 Rajpath, Jaipur', 'Sales Rep', '2016-08-19', '2023-07-10');
insert into Payroll (PayrollID, EmployeeID, PayPeriodStartDate, PayPeriodEndDate, BasicSalary, OvertimePay, Deductions, NetSalary) values
(1, 1, '2024-03-01', '2024-03-31', 60000, 5000, 3000, 62000),
(2, 2, '2024-03-01', '2024-03-31', 55000, 4000, 2500, 56500),
(3, 3, '2024-03-01', '2024-03-31', 50000, 3500, 2800, 50700),
(4, 4, '2024-03-01', '2024-03-31', 65000, 6000, 4000, 67000),
(5, 5, '2024-03-01', '2024-03-31', 58000, 5000, 3500, 59500),
(6, 6, '2024-03-01', '2024-03-31', 62000, 5500, 3200, 64300),
(7, 7, '2024-03-01', '2024-03-31', 56000, 4000, 3000, 57000),
(8, 8, '2024-03-01', '2024-03-31', 63000, 6000, 4000, 65000),
(9, 9, '2024-03-01', '2024-03-31', 59000, 5000, 3500, 60500),
(10, 10, '2024-03-01', '2024-03-31', 57000, 3500, 3000, 57500);
insert into Tax (TaxID, EmployeeID, TaxYear, TaxableIncome, TaxAmount) values
(1, 1, 2024, 720000, 108000),
(2, 2, 2024, 660000, 99000),
(3, 3, 2024, 600000, 90000),
(4, 4, 2024, 780000, 117000),
(5, 5, 2024, 696000, 104400),
(6, 6, 2024, 744000, 111600),
(7, 7, 2024, 672000, 100800),
(8, 8, 2024, 756000, 113400),
(9, 9, 2024, 708000, 106200),
(10, 10, 2024, 684000, 102600);
insert into FinancialRecord (RecordID, EmployeeID, RecordDate,Description, Amount, RecordType) values
(1, 1, '2024-03-05', 'Diwali Bonus', 10000, 'income'),
(2, 2, '2024-03-10', 'Medical Reimbursement', 5000, 'expense'),
(3, 3, '2024-03-15', 'Loan Deduction', 3000, 'tax payment'),
(4, 4, '2024-03-20', 'Salary Advance', 7000, 'income'),
(5, 5, '2024-03-25', 'Training Fee', 4000, 'expense'),
(6, 6, '2024-03-30', 'Travel Allowance', 8000, 'tax payment'),
(7, 7, '2024-03-10', 'Laptop Purchase', 50000, 'income'),
(8, 8, '2024-03-15', 'Overtime Bonus', 6000, 'expense'),
(9, 9, '2024-03-20', 'Uniform Purchase', 3000, 'income'),
(10, 10, '2024-03-25', 'Performance Incentive', 15000, 'income');
