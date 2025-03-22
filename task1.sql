use sisdb;
create table students(student_id int constraint Pk_studenyt_id primary key ,first_name varchar(30),last_name varchar(30),date_of_birth date,email varchar(30) CHECK (email LIKE '%_@_%._%'),phone_number int);
create table teacher(teacher_id int constraint pk_teacher_id primary key,first_name varchar(30),last_name varchar(30),email varchar(30) CHECK (email LIKE '%_@_%._%'));
create table courses(course_id int constraint pk_course_id primary key,course_name varchar(20),credits int,teacher_id int constraint fk_teacher_id foreign key references teacher(teacher_id) on delete set null);
create table enrollments(enrollment_id int constraint pk_enrollment_id primary key,student_id int constraint fk_student_id foreign key references students(student_id) on delete  no action,course_id int constraint fk_course_id foreign key references courses(course_id) on delete no action,enrollment_date date);
create table payments(payment_id int constraint pk_payment_id  primary key,student_id int constraint fk_student_pid foreign key references students(student_id) on delete no action,amount int ,payment_dtae date);
insert into students values(1,'amalorpava','jeni','2003-09-19','amalorpavajeni@gmail.com','8610007872');
insert into students values(2,'arokya','jesy','2003-09-19','arokyajesy@gmail.com','8610036682');
insert into students values(3,'jansi','a','2005-09-19','jansi@gmail.com','8015361030');
insert into students values(4,'steffy','anitha','2006-08-15','anitha@gmail.com','9012785489');
insert into students values(5,'Patrick','praveen','2001-10-03','patrickpraveen@gmail.com','8784562890');
insert into students values(6,'Simeon peter','armel','2007-11-10','simeonpeter@gmail.com','7980654321');
insert into students values(7,'juda','moses','2009-01-12','judamoses@gmail.com','8905467231');
insert into students values(8,'armel','sam','2004-08-17','samarmel@gmail.com','8690764532');
insert into students values(9,'ambross','armel','2004-05-21','ambross@gmail.com','8619087341');
insert into students values(10,'steven','armel','2008-04-03','steven@gmail.com','8619023172');
select* from teacher;
insert into teacher values(1,'armel','matharasi','matharasi@gmail.com');
insert into teacher values(2,'andoni','lawrence','lawrence@gmail.com');
insert into teacher values(3,'tata','birla','birla@gmail.com');
insert into teacher values(4,'anbu juliet','mala','mala@gmail.com');
insert into teacher values(5,'joseph','papu','joseph@gmail.com');
insert into teacher values(6,'arputha','sivarajan','siva@gmail.com');
insert into teacher values(7,'susai','raja','raja@gmail.com');
insert into teacher values(8,'anand','guber','anand@gmail.com');
insert into teacher values(9,'maria','theresa','theresa@gmail.com');
insert into teacher values(11,'jansi','claudine','jansia@gmail.com');
delete from teacher where teacher_id=1;
insert into payments values(1,2,9000,'2024-01-16');
insert into payments values(2,8,7000,'2023-03-01');
insert into payments values(3,1,2000,'2024-12-18');
insert into payments values(4,9,5000,'2000-09-17');
insert into payments values(5,3,4000,'2000-11-22');
insert into payments values(6,6,8000,'2000-07-24');
insert into payments values(7,4,7000,'2000-03-30');
insert into payments values(8,7,1000,'2000-02-31');
insert into payments values(9,10,8000,'2000-01-10');
insert into payments values(10,3,3000,'2000-08-17');
select * from courses;
insert into courses values(1,'java',10,5);
insert into courses values(2,'sql',9,4);
insert into courses values(3,'python',8,3);
insert into courses values(4,'c',5,2);
insert into courses values(5,'c++',9,1);
insert into courses values(6,'.net',6,10);
insert into courses values(7,'javascript',7,7);
insert into courses values(8,'html',10,6);
insert into courses values(9,'css',10,9);
insert into courses values(10,'mongoDB',9,8);
insert into enrollments values(1,10,9,'2023-09-19'),(1, 10, 9, '2023-09-19'),
(2, 8, 6, '2023-08-15'),
(3, 6, 12, '2023-07-10'),
(4, 9, 10, '2023-06-05'),
(5, 7, 8, '2023-05-20'),
(6, 5, 15, '2023-04-30'),
(7, 10, 7, '2023-03-25'),
(8, 4, 5, '2023-02-14'),
(9, 3, 11, '2023-01-01');
