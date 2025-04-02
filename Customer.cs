using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsAssignment
{
    internal class Customer
    {
        int CustomerID;
        string FirstName;
        string LastName;
        string EmailAdress;
        string PhoneNo;
        string Address;

        public int customerID
        {
            set{CustomerID=value;}
            get{return CustomerID;}
        }
        public string firstName
        {
            set{FirstName=value;}
            get { return FirstName; }
        }
            public string lastName
        {
            set{LastName=value;}
            get { return LastName; }
        }
        public string emailAdress
        {
            set{EmailAdress=value;}
            get { return EmailAdress;}
        }
        public string phoneNo
        {
            set { PhoneNo=value;}
            get { return PhoneNo; }
        }
        public string address
        {
            set { Address=value;}
            get { return Address; }
        }
        public Customer()
        {
        }
        public void Display(int CustomerID,string FirstName,string Lastname,string EmailAddress,string PhoneNo,string Address)
        {
            Console.WriteLine($"Customer ID:{CustomerID} First Name:{FirstName} Last Name:{LastName} Email Address:{EmailAddress}  Phone Number:{PhoneNo} Address:{Address}");
        }

    }
}
