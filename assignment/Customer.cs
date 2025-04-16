using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace assignment
{
    public class Customer
    {
        int counter = 1;
        int CustomerID;
        string FirstName;
        string LastName;
        string EmailAddress;
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
            set{EmailAddress=value;}
            get { return EmailAddress;}
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
        public Customer(string FirstName, string LastName, string EmailAddress, string PhoneNo, string Address)
        {
            
           this.CustomerID=counter++;
           this.FirstName=FirstName;
           this.LastName = LastName;
            this.EmailAddress=EmailAddress;
            this.PhoneNo=PhoneNo;
            this.Address=Address;


        }
        public override string ToString()
        {
            return $"Customer ID:{CustomerID} First Name:{FirstName} Last Name:{LastName} Email Address:{EmailAddress}  Phone Number:{PhoneNo} Address:{Address}";
        } 
        

    }
}
