create database challenge1;
use challenge1;
create table companies(company_id int constraint pk_company_id primary key ,
companyName varchar(20),location varchar(30));

create table jobs(jobid int constraint pk_job_id primary key,
company_id int constraint fk_company_id foreign key references companies(company_id),
jobTitle varchar(20),jobDescription text,jobLocation varchar(30),
salary decimal(15,2),jobType varchar(20),postedDate datetime);

create table applicants(applicant_id int constraint pk_applicant_id primary key,
firstName varchar(20),lastName varchar(20),email varchar(20),
phone varchar(10),resume text);

create table applications(application_id int constraint pk_application_id primary key,
jobid int constraint fk_job_id foreign key references jobs(jobid),
applicant_id int constraint fk_applicant_id foreign key references applicants(applicant_id),
application_date datetime,coverletter text);

insert into companies (company_id, companyName, location) values
(1, 'TCS', 'Mumbai'),
(2, 'Infosys', 'Bengaluru'),
(3, 'Wipro', 'Hyderabad'),
(4, 'HCL Tech', 'Noida'),
(5, 'Tech Mahindra', 'Pune'),
(6, 'L&T Infotech', 'Chennai'),
(7, 'Mindtree', 'Kolkata'),
(8, 'Capgemini', 'Ahmedabad'),
(9, 'Cognizant', 'Gurgaon'),
(10, 'Accenture', 'Delhi');
 
 insert into jobs (jobid, company_id, jobTitle, jobDescription, jobLocation, salary, jobType, postedDate) values
(1, 1, 'Software Developer', 'Develop scalable applications.', 'Mumbai', 800000.00, 'Full-Time', '2025-03-01 10:00:00'),
(2, 2, 'Data Analyst', 'Analyze large datasets.', 'Bengaluru', 900000.00, 'Full-Time', '2025-03-02 11:30:00'),
(3, 3, 'Web Developer', 'Build responsive websites.', 'Hyderabad', 750000.00, 'Full-Time', '2025-03-03 09:45:00'),
(4, 4, 'DevOps Engineer', 'Maintain cloud infrastructure.', 'Noida', 950000.00, 'Full-Time', '2025-03-04 14:20:00'),
(5, 5, 'Cybersecurity', 'Ensure data security.', 'Pune', 1000000.00, 'Full-Time', '2025-03-05 12:00:00'),
(6, 6, 'AI Engineer', 'Develop AI models.', 'Chennai', 1200000.00, 'Full-Time', '2025-03-06 16:10:00'),
(7, 7, 'Cloud Engineer', 'Deploy cloud solutions.', 'Kolkata', 1100000.00, 'Full-Time', '2025-03-07 13:00:00'),
(8, 8, 'Product Manager', 'Manage product development.', 'Ahmedabad', 950000.00, 'Full-Time', '2025-03-08 10:40:00'),
(9, 9, 'Network Engineer', 'Monitor IT infrastructure.', 'Gurgaon', 850000.00, 'Full-Time', '2025-03-09 15:30:00'),
(10, 10, 'Business Analyst', 'Optimize business processes.', 'Delhi', 920000.00, 'Full-Time', '2025-03-10 11:55:00');

insert into applicants (applicant_id, firstName, lastName, email, phone, resume) values
(1, 'Amit', 'Sharma', 'sharma@gmail.com', '9876543210', 'B.Tech in CSE, 2 years exp. in Java, React, SQL, worked at Infosys.'),
(2, 'Priya', 'Verma', 'verma@gmail.com', '8765432109', 'MCA, Data Analyst at TCS, skilled in Python, R, Tableau.'),
(3, 'Rahul', 'Patel', 'patel@gmail.com', '7654321098', 'B.Sc in IT, Frontend Developer, expertise in HTML, CSS, JavaScript, React.'),
(4, 'Sneha', 'Nair', 'nair@gmail.com', '6543210987', 'B.Tech in ECE, DevOps Engineer, AWS Certified, worked at Wipro.'),
(5, 'Vikas', 'Reddy', 'vikas@gmail.com', '5432109876', 'M.Tech in Cybersecurity, 3 years exp. at HCL, expertise in Ethical Hacking, Linux.'),
(6, 'Anjali', 'Gupta', 'anjali@gmail.com', '4321098765', 'BCA, AI/ML Engineer, expertise in TensorFlow, Python, OpenCV, 2 years at Capgemini.'),
(7, 'Karthik', 'Iyer', 'karthik@gmail.com', '3210987654', 'M.Tech in Cloud Computing, 4 years at L&T, expert in AWS, Azure, Kubernetes.'),
(8, 'Megha', 'Singh', 'megha@gmail.com', '2109876543', 'MBA in Product Management, Product Lead at Tech Mahindra, Agile & Scrum Certified.'),
(9, 'Suresh', 'Yadav', 'suresh@gmail.com', '1098765432', 'B.Tech in IT, Network Engineer at Cognizant, CCNA Certified, Firewall expert.'),
(10, 'Pooja', 'Joshi', 'pooja@gmail.com', '9988776655', 'BBA, Business Analyst at Accenture, expertise in Power BI, SQL, Agile methodologies.');

insert into applications (application_id, jobid, applicant_id, application_date, coverletter) values
(1, 1, 1, '2025-03-11 09:00:00', 'Cover letter text here'),
(2, 2, 2, '2025-03-12 10:15:00', 'Cover letter text here'),
(3, 3, 3, '2025-03-13 11:30:00', 'Cover letter text here'),
(4, 4, 4, '2025-03-14 12:45:00', 'Cover letter text here'),
(5, 5, 5, '2025-03-15 14:00:00', 'Cover letter text here'),
(6, 6, 6, '2025-03-16 15:15:00', 'Cover letter text here'),
(7, 7, 7, '2025-03-17 16:30:00', 'Cover letter text here'),
(8, 8, 8, '2025-03-18 17:45:00', 'Cover letter text here'),
(9, 9, 9, '2025-03-19 18:00:00', 'Cover letter text here'),
(10, 10, 10, '2025-03-20 19:15:00', 'Cover letter text here');

alter table applicants add city varchar(20);
alter table applicants add states varchar(20);
alter table applicants add experience int;
select* from applicants;
update applicants set city='TamilNadu', states='Chennai',experience=1 where applicant_id=1;
update applicants set city='West Bengal', states='Jaipur',experience=4 where applicant_id=2;
update applicants set city='Uttar Pradesh', states='Lucknow',experience=4 where applicant_id=3;
update applicants set city='kerala', states='varkala',experience=3 where applicant_id=4;
update applicants set city='Kerala', states='Trivandram',experience=8 where applicant_id=5;
update applicants set city='TamilNadu', states='Ooty',experience=5 where applicant_id=6;
update applicants set city='TamilNadu', states='Coimbatore',experience=2 where applicant_id=7;
update applicants set city='TamilNadu', states='Vellore',experience=0 where applicant_id=8;
update applicants set city='Delhi', states='Ahmedabad',experience=9 where applicant_id=9;
update applicants set city='TamilNadu', states='Chennai',experience=6 where applicant_id=10;

--5. Write an SQL query to count the number of applications received for
--each job listing in the
--"Jobs" table. Display the job title and the corresponding application count. Ensure that it lists all
--jobs, even if they have no applications.
select count(application_id) as count,jobTitle from applications a
right join jobs j on j.jobid=a.jobid
group by a.jobid,jobTitle;

select * from jobs;

--6. Develop an SQL query that retrieves job listings from the "Jobs" table within a specified salary
--range. Allow parameters for the minimum and maximum salary values. Display the job title,
--company name, location, and salary for each matching job.
select j.jobTitle,c.companyName,c.location,salary from companies c
join jobs j on j.company_id=c.company_id
where j.salary between 1000000.00 and 1200000.00;

--7. Write an SQL query that retrieves the job application history for a specific applicant. Allow a
--parameter for the ApplicantID, and return a result set with the job titles, company names, and
--application dates for all the jobs the applicant has applied to.
select  a.Applicant_id,jobTitle,companyName,application_date from jobs j
join applications a on a.jobid=j.jobid
join companies c on c.company_id=j.company_id
join applicants ap on ap.applicant_id=a.applicant_id
where a.applicant_id=1

insert into applications values(11,9,1,'2025-03-11 09:00:00.000','cover letter text');

--8. Create an SQL query that calculates and displays the average salary offered by all companies for
--job listings in the "Jobs" table. Ensure that the query filters out jobs with a salary of zero.
select avg(salary),jobTitle from jobs
where salary>0
group by jobTitle;

insert into jobs values(13,4,'Database engineer','manage databases','Chennai',0,'Part-Time','2025-03-11 09:00:00.000');

--9. Write an SQL query to identify the company that has posted the most job listings. Display the
--company name along with the count of job listings they have posted. Handle ties if multiple
--companies have the same maximum count.
select companyName,count(j.jobid) as job_count from companies c
join jobs j on j.company_id=c.company_id
group by companyName 
having count(j.jobid)=(select max(job_count) from
(select company_id,count(jobid) as job_count from jobs group by company_id)as job_counts);

--10. Find the applicants who have applied for positions in companies located in 'CityX' and have at
--least 3 years of experience.
select a.firstName,a.lastName,location from applicants a
join applications ap on ap.applicant_id=a.applicant_id
join jobs j on j.jobid=ap.jobid
join companies c on j.company_id=c.company_id
where c.location='Mumbai' and experience=1;


--11. Retrieve a list of distinct job titles with salaries between $60,000 and $80,000.
select jobTitle,salary from jobs
where salary between 340000 and 900000;

--12. Find the jobs that have not received any applications.
select jobTitle from jobs j
where not exists
(select jobid from applications a where j.jobid=a.jobid);
 insert into jobs values(11,9,'Developer','develop websites','Mumbai',900000,'FUll-time','2025-03-03 09:45:00');

--13. Retrieve a list of job applicants along with the companies they have applied to and the positions
--they have applied for.
select a.firstName,a.lastName,c.companyName,j.jobTitle from applicants a
join applications ap on ap.applicant_id=a.applicant_id
join jobs j on ap.jobid=j.jobid
join companies c on c.company_id=j.company_id;

--14. Retrieve a list of companies along with the count of jobs they have posted, even if they have not
--received any applications.
select companyName,count(jobid) as  no_of_jobs from jobs j
join companies c on c.company_id=j.company_id
group by companyName,j.company_id;

--15. List all applicants along with the companies and positions they have applied for, including those
--who have not applied.
select a.*,companyName,jobTitle from companies c
join jobs j on j.company_id=c.company_id
join applications ap on j.jobid=ap.jobid
right join applicants a on a.applicant_id=ap.applicant_id;

insert into applicants values(11,'Shreya','nair','shreya@gmail.com','9087654321','BBA, Business Analyst at Accenture, expertise in Power BI, SQL, Agile methodologies');
select * from applicants;

--16. Find companies that have posted jobs with a salary higher than the average salary of all jobs.
select companyName from companies c
join jobs j on j.company_id=c.company_id
where salary>(select avg(salary) from jobs);

--17. Display a list of applicants with their names and a concatenated string of their city and state.
select  concat(firstName,' ',lastName) as name,concat(city,',',states) as location from applicants;

--18. Retrieve a list of jobs with titles containing either 'Developer' or 'Engineer'.
select jobid,jobTitle from jobs
where jobTitle like '%Developer%' or jobTitle like'%Engineer';

--19. Retrieve a list of applicants and the jobs they have applied for, including those who have not
--applied and jobs without applicants.
select firstName,lastName,jobTitle from applicants a
join applications ap on ap.applicant_id=a.applicant_id
right join jobs j on j.jobid=ap.jobid;


--20. List all combinations of applicants and companies where the company is in a specific city and the
--applicant has more than 2 years of experience. For exam
select firstName,lastName,c.location,c.companyName from companies c
join jobs j on j.company_id=c.company_id
join applications ap on j.jobid=ap.jobid
join applicants a on a.applicant_id=ap.applicant_id
where location='Mumbai' and experience between 1 and 8;
