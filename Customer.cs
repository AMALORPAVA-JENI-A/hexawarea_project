using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace HMBank
{
    public class Customer
    {
        
            public int counter = 100;


            public int customerID
            {
                set;
                get;
            }
            public string firstName
            {
                set;
                get;
            }
            public string lastName
            {
                set;
                get;
            }
            public string emailAdress
            {
                set;
                get;
            }
            public string phoneNo
            {
                set;
                get;
            }
            public string address
            {
                set;
                get;
            }
            public Customer()
            {
            }
            public Customer(string FirstName, string LastName, string EmailAddress, string PhoneNo, string Address)
            {
                if (!Regex.IsMatch(EmailAddress, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    Console.WriteLine("Invalid email");
                }
                if (!Regex.IsMatch(PhoneNo, @"^\d{10}$"))
                {
                    Console.WriteLine("Invalid Phone number");
                }
                customerID = counter++;
                firstName = FirstName;
                lastName = LastName;
                emailAdress = EmailAddress;
                phoneNo = PhoneNo;
                address = Address;


            }
            public override string ToString()
            {
                return $"Customer ID:{customerID} First Name:{firstName} Last Name:{lastName} Email Address:{emailAdress}  Phone Number:{phoneNo} Address:{address}";
            }


        }
    }


