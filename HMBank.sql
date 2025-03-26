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

INSERT INTO customers (customer_id, first_name, last_name, DOB, email, phone_number, address) VALUES
(11, 'Sophia', 'Williams', '1995-04-12', 'sophia@gmail.com', '9911223344', '23 Main Road, Pondy'),
(12, 'Liam', 'Davis', '1987-09-25', 'liam@gmail.com', '9922334455', '45 Beach Street, Pondy'),
(13, 'Olivia', 'Johnson', '1990-06-18', 'olivia@gmail.com', '9933445566', '12 Green Park, Pondy'),
(14, 'Noah', 'Martin', '1985-12-30', 'noah@gmail.com', '9944556677', '7 Lake View, Pondy'),
(15, 'Emma', 'Clark', '1993-08-22', 'emma@gmail.com', '9955667788', '99 River Road, Pondy'),
(16, 'James', 'Lee', '1982-11-05', 'james@gmail.com', '9966778899', '88 Town Square, Pondy'),
(17, 'Ava', 'Hall', '1998-07-14', 'ava@gmail.com', '9977889900', '56 New Colony, Pondy'),
(18, 'William', 'Young', '1989-03-09', 'william@gmail.com', '9988990011', '100 Old Town, Pondy'),
(19, 'Mia', 'King', '1996-05-02', 'mia@gmail.com', '9999001122', '77 Garden Lane, Pondy'),
(20, 'Lucas', 'Scott', '1991-01-28', 'lucas@gmail.com', '9900112233', '33 Park Avenue, Pondy');


INSERT INTO accounts (account_id, customer_id, account_type, balance) VALUES
(111, 11, 'Savings', 0.00),
(112, 11, 'Current', 15000.75),
(113, 12, 'Zero Balance', 0.00),
(114, 13, 'Savings', 3000.50),
(115, 14, 'Current', 17500.00),
(116, 15, 'Zero Balance', 0.00),
(117, 16, 'Savings', 8700.25),
(118, 17, 'Current', 9200.75),
(119, 18, 'Zero Balance', 0.00),
(120, 19, 'Savings', 4500.45),
(121, 20, 'Current', 20000.00),
(122, 12, 'Savings', 6200.90),
(123, 14, 'Current', 0.00),
(124, 15, 'Savings', 1000.50),
(125, 16, 'Zero Balance', 0.00),
(126, 17, 'Current', 3500.75),
(127, 18, 'Savings', 7900.80),
(128, 19, 'Zero Balance', 0.00),
(129, 20, 'Current', 6000.30),
(130, 11, 'Savings', 0.00); 


INSERT INTO transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES
(1011, 111, 'Deposit', 5000.00, '2025-03-25'),
(1012, 112, 'Withdrawal', 1000.00, '2025-03-26'),
(1013, 113, 'Transfer', 2000.50, '2025-03-27'),
(1014, 114, 'Deposit', 1200.75, '2025-03-28'),
(1015, 115, 'Withdrawal', 800.00, '2025-03-29'),
(1016, 116, 'Deposit', 3000.25, '2025-03-30'),
(1017, 117, 'Transfer', 1500.90, '2025-03-31'),
(1018, 118, 'Deposit', 2500.60, '2025-04-01'),
(1019, 119, 'Withdrawal', 750.75, '2025-04-02'),
(1020, 120, 'Deposit', 4000.45, '2025-04-03'),
(1021, 121, 'Deposit', 8000.00, '2025-04-04'),
(1022, 122, 'Withdrawal', 1200.90, '2025-04-05'),
(1023, 123, 'Transfer', 300.00, '2025-04-06'),
(1024, 124, 'Deposit', 500.50, '2025-04-07'),
(1025, 125, 'Withdrawal', 600.00, '2025-04-08'),
(1026, 126, 'Deposit', 750.75, '2025-04-09'),
(1027, 127, 'Transfer', 1800.80, '2025-04-10'),
(1028, 128, 'Deposit', 900.30, '2025-04-11'),
(1029, 129, 'Withdrawal', 1500.45, '2025-04-12'),
(1030, 130, 'Deposit', 0.00, '2025-04-13'); 

-- View All Customers
SELECT * FROM customers;
-- View All Accounts
SELECT * FROM accounts;

-- View All Transactions
SELECT * FROM transactions;


--1. Write a SQL query to retrieve the name, account type and email of all customers.  
select first_name,account_type,email from customers c
join accounts a on a.customer_id=c.customer_id;

--2. Write a SQL query to list all transaction corresponding customer.
select first_name,t.* from customers c
join accounts a on c.customer_id=a.customer_id
join transactions t on a.account_id=a.account_id;

--3. Write a SQL query to increase the balance of a specific account by a certain amount.
update accounts set balance=balance+10000 where account_id=101;

--4. Write a SQL query to Combine first and last names of customers as a full_name.
select concat(first_name,' ',last_name) as full_name from customers;

--5. Write a SQL query to remove accounts with a balance of zero where the account type is savings.
delete from accounts where balance=0 and account_type='savings';
insert into accounts values(112,9,'savings',0);
insert into accounts values(113,8,'savings',0);
select * from accounts;

--6. Write a SQL query to Find customers living in a specific city.
select * from customers where address like('%pondy%');

--7. Write a SQL query to Get the account balance for a specific account.
select balance from accounts where account_id=109;

--8. Write a SQL query to List all current accounts with a balance greater than $1,000.
select * from accounts where balance>1000 and account_type='current';

--9. Write a SQL query to Retrieve all transactions for a specific account.
insert into transactions values(1011,106,'Transfer',800.67,'2025-12-09');
select * from transactions where account_id=106;

--10. Write a SQL query to Calculate the interest accrued on savings accounts based on a given interest rate.
select account_id,account_type,(balance*4*3)/100 as interest from accounts where account_type='savings';

--11. Write a SQL query to Identify accounts where the balance is less than a specified overdraft limit.
select * from accounts where balance<1000;

--12. Write a SQL query to Find customers not living in a specific city. 
select * from customers where address not like('%chennai%');
insert into customers values(11,'julia','gomez','2003-09-19','julia@gmail.com','8976543210','56 tnagar chennai');

--Tasks 3: Aggregate functions, Having, Order By, GroupBy and Joins:
--1. Write a SQL query to Find the average account balance for all customers.  
select avg(balance) as average_balance from accounts;


--2. Write a SQL query to Retrieve the top 10 highest account balances.  
select top 10 balance,account_id from accounts order by balance desc;

--3. Write a SQL query to Calculate Total Deposits for All Customers in specific date.
select sum(amount) from transactions where transaction_date='2025-03-20' and transaction_type='Deposit' ;

--4. Write a SQL query to Find the Oldest and Newest Customers.
select min(DOB) as oldest_customer, max(DOB) as newest_customer from customers;

--5. Write a SQL query to Retrieve transaction details along with the account type.
select t.*,a.account_type from transactions t 
join accounts a on t.account_id=a.account_id;

--6. Write a SQL query to Get a list of customers along with their account details.
select first_name,a.* from accounts a 
join customers c on c.customer_id=a.customer_id;

--7. Write a SQL query to Retrieve transaction details along with customer information for a specific account.
select t.*,first_name from customers c 
join accounts a on a.customer_id=c.customer_id
join transactions t on t.account_id=a.account_id
where a.account_id=101;

--8. Write a SQL query to Identify customers who have more than one account.
select c.customer_id, c.first_name, c.last_name, count(a.account_id) as account_count
from customers c
join accounts a on c.customer_id = a.customer_id
group by c.customer_id, c.first_name, c.last_name
having count(a.account_id) > 1;

--9. Write a SQL query to Calculate the difference in transaction amounts between deposits and withdrawals.
select sum(case when transaction_type='deposit' then amount else 0 end) from transactions;
select sum(case when transaction_type='withdrawal' then amount else 0 end) from transactions;
select sum(case when transaction_type='deposit' then amount else 0 end)-sum(case when transaction_type='withdrawal' then amount else 0 end)
as difference from transactions;

--10. Write a SQL query to Calculate the average daily balance for each account over a specified period.
select account_id,AVG(amount) as average_daily_balance
from Transactions
where transaction_date BETWEEN '2025-03-23' AND '2025-03-25' 
group by account_id;
select * from Transactions;

--11. Calculate the total balance for each account type.
select sum(balance) total_balance,account_type  from accounts group by account_type;

--12. Identify accounts with the highest number of transactions order by descending order.
select count(transaction_id) no_of_transactions,account_id from transactions 
group by account_id order by no_of_transactions desc;

--13. List customers with high aggregate account balances, along with their account types.
select c.customer_id,c.first_name, c.last_name,a.account_type,
sum(a.balance) as total_balance
from customers c
join accounts a on c.customer_id = a.customer_id
group by c.customer_id, c.first_name, c.last_name, a.account_type
having sum(a.balance) > 10000 
order by total_balance desc;

--14. Identify and list duplicate transactions based on transaction amount, date, and account.
select amount,transaction_date,account_id,count(account_id) from transactions group by amount,transaction_date,account_id having count(account_id)>1 ;
insert into transactions (transaction_id, account_id, transaction_type, amount, transaction_date) values
(1031, 111, 'Deposit', 5000.00, '2025-03-25');

--Tasks 4: Subquery and its type:
--1. Retrieve the customer(s) with the highest account balance.
select top 1 balance ,first_name from customers c
join accounts a on a.customer_id=c.customer_id
order by balance desc;

--2. Calculate the average account balance for customers who have more than one account.
select avg(balance) as average_balance,c.first_name ,a.customer_id from customers c
join accounts a on a.customer_id=c.customer_id
group by a.customer_id,first_name;
select * from accounts;

--3. Retrieve accounts with transactions whose amounts exceed the average transaction amount.
select account_id,amount from transactions where amount>(select avg(amount) from transactions);
select avg(amount) from transactions;

--4. Identify customers who have no recorded transactions.
select a.account_id,first_name from customers c 
join accounts a on a.customer_id=c.customer_id
where not exists
(select 1 from transactions t where t.account_id=a.account_id);
insert into customers values(21,'jeniffer','brown','1997-09-18','browm@gmail.com','7865432190','897 nehru street,pondy');
select* from accounts;
insert into accounts values(131,21,'current',8900);

--5. Calculate the total balance of accounts with 
--no recorded transactions.
select sum(a.balance),a.account_id,first_name from customers c
join accounts a on a.customer_id=c.customer_id
where not exists
(select 1 from transactions t where t.account_id=a.account_id)
group by c.customer_id,a.account_id,c.first_name;

--6. Retrieve transactions for accounts with the lowest balance.
select * from transactions t
join accounts a on a.account_id=t.account_id
where balance=(select min(balance) from accounts);

--7. Identify customers who have accounts of multiple types.
select first_name from customers c
join accounts a on a.customer_id=c.customer_id
 group by a.customer_id,first_name
 having count(account_id)>1;

 select * from customers;
 select * from accounts;

--8. Calculate the percentage of each account type out of the total number of accounts.
select(count(account_id)*100.0/(select count(account_id) from accounts)),account_type from accounts
group by account_type;

--9. Retrieve all transactions for a customer with a given customer_id.
select t.*,c.customer_id from customers c
join accounts a on a.customer_id=c.customer_id
join transactions t on t.account_id=a.account_id
where c.customer_id=1;

--10. Calculate the total balance for each account type, including a subquery within the SELECT clause.
select sum(balance),account_type from accounts 
group by account_type;
