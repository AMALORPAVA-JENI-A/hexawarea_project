CREATE TABLE Doctor (
    doctor_id VARCHAR(6) PRIMARY KEY,
    dr_first_name VARCHAR(15),
    dr_middle_name VARCHAR(15),
    dr_last_name VARCHAR(15)
);

-- Create Patient table (parent table for Appointment)
CREATE TABLE Patient (
    patient_id VARCHAR(6) PRIMARY KEY,
    p_first_name VARCHAR(15),
    p_middle_name VARCHAR(15),
    p_last_name VARCHAR(15),
    address VARCHAR(20),
    city VARCHAR(15),
    contact_number VARCHAR(10),
    p_app INT
);

-- Create Appointment table (references Doctor and Patient)
CREATE TABLE Appointment (
    app_number VARCHAR(6) PRIMARY KEY,
    app_date DATE,
    app_time VARCHAR(8),
    app_reason VARCHAR(20),
    doctor_id VARCHAR(6),
    patient_id VARCHAR(6),
    FOREIGN KEY (doctor_id) REFERENCES Doctor(doctor_id),
    FOREIGN KEY (patient_id) REFERENCES Patient(patient_id)
);

-- Create BIII table (references Appointment)
CREATE TABLE BIII (
    bil_number VARCHAR(6) PRIMARY KEY,
    bil_date DATE,
    bil_status VARCHAR(8),
    bil_amount DECIMAL(7, 2),
    app_number VARCHAR(6),
    FOREIGN KEY (app_number) REFERENCES Appointment(app_number)
);

-- Create Payment table (references BIII)
CREATE TABLE Payment (
    payment_id VARCHAR(6) PRIMARY KEY,
    pay_date DATE,
    Pay_node VARCHAR(10),
    pay_amount DECIMAL(7, 2),
    bil_number VARCHAR(6),
    FOREIGN KEY (bil_number) REFERENCES BIII(bil_number)
);

-- Insert sample data into Doctor table
INSERT INTO Doctor (doctor_id, dr_first_name, dr_middle_name, dr_last_name) VALUES
('DOC001', 'John', 'A.', 'Smith'),
('DOC002', 'Sarah', 'M.', 'Johnson'),
('DOC003', 'Michael', NULL, 'Williams'),
('DOC004', 'Emily', 'R.', 'Brown'),
('DOC005', 'David', 'K.', 'Jones'),
('DOC006', 'Jennifer', NULL, 'Garcia'),
('DOC007', 'Robert', 'T.', 'Miller'),
('DOC008', 'Lisa', 'P.', 'Davis'),
('DOC009', 'Thomas', 'E.', 'Rodriguez'),
('DOC010', 'Nancy', NULL, 'Martinez');

-- Insert sample data into Patient table
INSERT INTO Patient (patient_id, p_first_name, p_middle_name, p_last_name, address, city, contact_number, p_app) VALUES
('PAT001', 'James', 'B.', 'Wilson', '123 Main St', 'Boston', '6175550101', 3),
('PAT002', 'Mary', 'L.', 'Taylor', '456 Oak Ave', 'New York', '2125550202', 5),
('PAT003', 'William', NULL, 'Anderson', '789 Pine Rd', 'Chicago', '3125550303', 2),
('PAT004', 'Patricia', 'S.', 'Thomas', '321 Elm St', 'Houston', '7135550404', 1),
('PAT005', 'Richard', 'D.', 'Jackson', '654 Maple Dr', 'Phoenix', '6025550505', 4),
('PAT006', 'Jennifer', NULL, 'White', '987 Cedar Ln', 'Philadelphia', '2155550606', 3),
('PAT007', 'Charles', 'F.', 'Harris', '147 Birch Ct', 'San Antonio', '2105550707', 2),
('PAT008', 'Linda', 'G.', 'Martin', '258 Walnut Way', 'San Diego', '6195550808', 5),
('PAT009', 'Joseph', NULL, 'Thompson', '369 Spruce Pl', 'Dallas', '2145550909', 1),
('PAT010', 'Susan', 'H.', 'Robinson', '741 Aspen Blvd', 'San Jose', '4085551010', 4);

-- Insert sample data into Appointment table
INSERT INTO Appointment (app_number, app_date, app_time, app_reason, doctor_id, patient_id) VALUES
('APP001', '2023-01-10', '09:00 AM', 'Annual Checkup', 'DOC001', 'PAT001'),
('APP002', '2023-01-11', '10:30 AM', 'Flu Symptoms', 'DOC002', 'PAT002'),
('APP003', '2023-01-12', '02:15 PM', 'Back Pain', 'DOC003', 'PAT003'),
('APP004', '2023-01-13', '11:00 AM', 'Vaccination', 'DOC004', 'PAT004'),
('APP005', '2023-01-14', '03:45 PM', 'Allergy Consult', 'DOC005', 'PAT005'),
('APP006', '2023-01-15', '08:30 AM', 'Follow-up', 'DOC006', 'PAT006'),
('APP007', '2023-01-16', '01:00 PM', 'Skin Rash', 'DOC007', 'PAT007'),
('APP008', '2023-01-17', '04:30 PM', 'Blood Test', 'DOC008', 'PAT008'),
('APP009', '2023-01-18', '09:45 AM', 'Physical Exam', 'DOC009', 'PAT009'),
('APP010', '2023-01-19', '10:15 AM', 'Headache', 'DOC010', 'PAT010');

-- Insert sample data into BIII table
INSERT INTO BIII (bil_number, bil_date, bil_status, bil_amount, app_number) VALUES
('BIL001', '2023-01-10', 'Paid', 150.00, 'APP001'),
('BIL002', '2023-01-11', 'Pending', 200.00, 'APP002'),
('BIL003', '2023-01-12', 'Paid', 175.50, 'APP003'),
('BIL004', '2023-01-13', 'Pending', 120.00, 'APP004'),
('BIL005', '2023-01-14', 'Paid', 90.75, 'APP005'),
('BIL006', '2023-01-15', 'Pending', 250.00, 'APP006'),
('BIL007', '2023-01-16', 'Paid', 180.25, 'APP007'),
('BIL008', '2023-01-17', 'Pending', 300.00, 'APP008'),
('BIL009', '2023-01-18', 'Paid', 150.00, 'APP009'),
('BIL010', '2023-01-19', 'Pending', 125.50, 'APP010');

-- Insert sample data into Payment table
INSERT INTO Payment (payment_id, pay_date, Pay_node, pay_amount, bil_number) VALUES
('PAY001', '2023-01-10', 'CreditCard', 150.00, 'BIL001'),
('PAY002', '2023-01-12', 'Cash', 175.50, 'BIL003'),
('PAY003', '2023-01-14', 'Insurance', 90.75, 'BIL005'),
('PAY004', '2023-01-16', 'CreditCard', 180.25, 'BIL007'),
('PAY005', '2023-01-18', 'Check', 150.00, 'BIL009'),
('PAY006', '2023-01-20', 'CreditCard', 100.00, 'BIL002'),
('PAY007', '2023-01-21', 'Cash', 120.00, 'BIL004'),
('PAY008', '2023-01-22', 'Insurance', 125.00, 'BIL006'),
('PAY009', '2023-01-23', 'CreditCard', 200.00, 'BIL008'),
('PAY010', '2023-01-24', 'Check', 125.50, 'BIL010');

select* from doctor;
select * from appointment;
--1.  Find all patients who live in either 'Boston', 'New York', or 'Chicago'.
select p_first_name,city from Patient 
where city in('Chicago','New York','Boston');

--2. List all doctors who are NOT assigned to any appointments (their doctor_id doesn't appear in the Appointment table).
 select dr_first_name from Doctor d
 where not exists(
select 1 from appointment a where a.doctor_id=d.doctor_id)

--3.  Find all patients who don't have a middle name (where p_middle_name is NULL).
 select p_first_name from patient where p_middle_name is NULL;
 select * from patient;

--4.  Display all bills that have a status assigned (bil_status is not NULL).
 select * from bIII where bil_status is not NULL;

--5.  Show all appointments and replace NULL doctor_id with 'UNASSIGNED'.
 select * ,
 case 
 when doctor_id is null then 'unassigned'
 else doctor_id
 end as doctor_id
 from appointment;

--6. Find all payments made between January 12, 2023 and January 18, 2023.
select * from Payment
where pay_date between '2023-01-12' and '2023-01-18';
 
--7.  List all unique cities where patients live (without duplicates).
select distinct city from patient;
 
--8.  Combine the list of all doctor last names with all patient last names into a single result.
 select p_last_name from patient
 union 
 select dr_last_name from doctor;
 

--9.  (using INNER JOIN): Find patients who have both appointments and bills
-- (patient_id exists in both Patient and BIII tables via Appointment).
 select patient_id,a.app_number,bil_number from appointment a
 join biii b on b.app_number=a.app_number;
 select patient_id,a.app_number,bil_number from appointment a
 inner join biii b on b.app_number=a.app_number;

--10.  List doctors who have no appointments (doctors that exist in Doctor table but not in Appointment table).
select dr_first_name,doctor_id from doctor d
where   not exists(select 1 from appointment a
where a.doctor_id=d.doctor_id);

insert into doctor values('DOC011','armel','arputha','sivarajan');

 --1.  Display all appointments with the full names of both the 
 --doctor and patient (combine first, middle, and last names).
 select concat(dr_first_name,' ',dr_middle_name,' ',dr_last_name)as doc_name,
 concat(p_first_name,' ',p_last_name,' ',p_middle_name) as patient,
 a.* from appointment a
 join doctor d on d.doctor_id=a.doctor_id
 join patient p on p.patient_id=a.patient_id;

--2. List all bills with their corresponding payment details(if any),
--showing bil_number, bil_amount, payment_id, and pay_amount.
 select b.bil_number,bil_amount,payment_id,pay_amount
 from payment p
 join biii b on b.bil_number=p.bil_number;
 select * from payment;

--3. Show all patients and their appointments (if any), 
--including patients who haven't had any appointments.
 select p_first_name,app_number from patient p
 left join appointment a on a.patient_id=p.patient_id;
 insert into patient values('PAT011', 'Jenelis', 'B.', 'William', '123 Main St', 'Boston', '6175550101', 3);

--4.  Find pairs of doctors who share the same last name 
--(excluding pairs where doctor_id is the same).
select dr_first_name from doctor


--5. * Display the total amount paid by each patient (sum of 
--all payments through their bills), along with patient names.
select sum(pay_amount) amount,p_first_name from patient p1
join appointment a on a.patient_id=p1.patient_id
join biii b on b.app_number=a.app_number
join payment p on p.bil_number=b.bil_number
group by p_first_name;

 
--6. Find all doctors who have more than 3 appointments.
select d.dr_first_name,d.doctor_id from doctor  d
join appointment a on a.doctor_id=d.doctor_id
group by d.doctor_id,d.dr_first_name
having count(a.doctor_id)>3;
insert into appointment values('APP011', '2023-01-10', '09:00 AM', 'Annual Checkup', 'DOC001', 'PAT001'),
('APP012', '2023-01-10', '09:00 AM', 'Annual Checkup', 'DOC001', 'PAT001'),
 ('APP013', '2023-01-10', '09:00 AM', 'Annual Checkup', 'DOC001', 'PAT001');

--7.  List patients who have at least one bill with an amount 
--greater than the average bill amount.
select p_first_name from patient p
join appointment a on a.patient_id=p.patient_id
join biii b on b.app_number=a.app_number
where bil_amount>(select avg(bil_amount)from biii)
group by p.p_first_name;

select avg(bil_amount) from biii;

--8.  Display all bills that don't have any associated payments.
select * from biii b
where not exists(select 1 from payment p where 
b.bil_number=p.bil_number);

--9.  Find all appointments for patients who live in cities 
--where more than one patient resides.
 select a.patient_id,a.app_number 
 from appointment a
 join patient p on p.patient_id=a.patient_id
 where p.city in(
 select city from patient group by city
 having count(patient_id)>1);

 select * from appointment;
 select * from patient;

--10. Show the doctor(s) with the highest number of appointments.
select doctor_id from appointment
group by doctor_id
having count(doctor_id)=
(select max(doc_count) from (
select count(doctor_id) doc_count from  appointment
group by doctor_id)as sub);

 
 
