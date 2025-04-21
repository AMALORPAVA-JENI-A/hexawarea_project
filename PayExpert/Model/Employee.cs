using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PayExpert.Model
{
    public class Employee
    {
        public int employeeID
        {
            get; set;
        }
        public string firstName
        {
            get; set;
        }
        public string lastName
        {
            get; set;
        }
        public DateTime dateOfBirth
        {
            get; set;
        }
        public string gender
        {
            get; set;
        }
        public string email
        {
            get; set;
        }
        public string phoneNumber
        {
            get; set;
        }
        public string address
        {
            get; set;
        }
        public string position
        {
            get; set;
        }
        public DateTime joiningDate
        {
            get; set;
        }
        public DateTime? terminationDate
        {
            get; set;
        }
        public int CalculateAge()
        {
            DateTime today = (DateTime.Now);
            int age=today.Year-dateOfBirth.Year;
            return age;
        }
        public Employee()
        {

        }
        public Employee(int employeeID, string firstName, string lastName, DateTime dateOfBirth, string gender, string email, string phoneNumber, string address, string position, DateTime joiningDate, DateTime? terminationDate)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.position = position;
            this.joiningDate = joiningDate;
            this.terminationDate = terminationDate;
        }
        public override string ToString()
        {
            return $"Employee ID={employeeID} , First Name={firstName} , Last Name={lastName} , Date of Birth={dateOfBirth} , Gender={gender} , Email={email} , Conatact number={phoneNumber} , Address={address} , Position={position} , Joining date={joiningDate} ,  Termination date={terminationDate}";
            
        }
    }
}
