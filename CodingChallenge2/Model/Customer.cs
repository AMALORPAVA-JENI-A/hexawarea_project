using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge2.Model
{
    public class Customer
    {
        public  int customerID
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string emailAddress
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
        public decimal creditScore
        {
            get; set;
        }
        public Customer()
        {

        }
        public Customer(int customerID, string name, string emailAddress, string phoneNumber, string address, decimal creditScore)
        {
            this.customerID = customerID;
            this.name = name;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.creditScore = creditScore;
        }
        public override string ToString()
        {
            return $"customer id={customerID} , name={name} , emailAddress={emailAddress} , phone number={phoneNumber} , address={address} , creditScore={creditScore}";
        }
    }
}
