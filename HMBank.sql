create database HMBank;
use HMBank;
create table customers(customer_id int constraint pk_customer_id primary key,first_name varchar(20),last_name varchar(20),DOB date,email varchar(30) constraint uq_email unique,phone_number varchar(10),address varchar(50));
create table accounts(account_id int constraint pk_account_id primary key,customer_id int constraint fk_customer_id foreign key references customers(customer_id) on delete no action,account_type varchar(20),balance decimal(15,2));
create table transactions(transaction_id int constraint pk_transaction_id primary key,account_id int constraint fk_account_id foreign key references accounts(account_id) on delete no action,transaction_type varchar(20),amount decimal(15,2),transaction_date date);
insert into customers (customer_id, first_name, last_name, DOB, email, phone_number, address) values
(1, 'John', 'Doe', '1985-03-15', 'john@gmail.com', '9876543210', '44 tv nagar,pondy'),
(2, 'Jane', 'Smith', '1992-07-22', 'jane@gmail.com', '9123456789', '18 rainbow nagar,pondy'),
(3, 'Alice', 'Brown', '1988-11-05', 'alice@gmail.com', '9234567890', '78 krishna nagar,pondy'),
(4, 'Bob', 'Johnson', '1995-02-28', 'bobn@gmail.com', '9345678901', '10 lawspet, pondy'),
(5, 'Charlie', 'Miller', '1990-06-14', 'charlie@gmail.com', '9456789012', '22 madagadipet, pondy'),
(6, 'David', 'Wilson', '1983-09-10', 'david@gmail.com', '9567890123', '33 muthu street, pondy'),
(7, 'Eve', 'Taylor', '1998-12-25', 'eve@gmail.com', '9678901234', '47 ariankuppam, pondy'),
(8, 'Frank', 'Anderson', '1991-04-08', 'frank@gmail.com', '9789012345', '50 muthialpet, pondy'),
(9, 'Grace', 'Thomas', '1986-08-19', 'grace@gmail.com', '9890123456', '666 white town,pondy'),
(10, 'Henry', 'Moore', '1993-05-30', 'henry@gmail.com', '9901234567', '777 gandhi street,pondy');
insert into accounts (account_id, customer_id, account_type, balance) values
(101, 1, 'Savings', 5000.75),
(102, 2, 'current', 12000.50),
(103, 3, 'zero_balance', 7500.25),
(104, 4, 'current', 18000.00),
(105, 5, 'Savings', 6200.60),
(106, 6, 'zero_balance', 14000.90),
(107, 7, 'Savings', 3000.45),
(108, 8, 'current', 19500.75),
(109, 9, 'Savings', 8200.35),
(110, 10, 'zero_balance', 15000.00);
select* from customers;
insert into transactions (transaction_id, account_id, transaction_type, amount, transaction_date) values
(1001, 101, 'Deposit', 2000.00, '2025-03-20'),
(1002, 102, 'Withdrawal', 500.00, '2025-03-20'),
(1003, 103, 'Transfer', 1500.50, '2025-03-21'),
(1004, 104, 'Deposit', 2500.75, '2025-03-21'),
(1005, 105, 'Withdrawal', 1000.00, '2025-03-22'),
(1006, 106, 'Transfer', 300.25, '2025-03-22'),
(1007, 107, 'Deposit', 1800.90, '2025-03-23'),
(1008, 108, 'Withdrawal', 750.60, '2025-03-23'),
(1009, 109, 'Transfer', 2200.00, '2025-03-24'),
(1010, 110, 'Deposit', 1300.75, '2025-03-24');
select * from transactions;

