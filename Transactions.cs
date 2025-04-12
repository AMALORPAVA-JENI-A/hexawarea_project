using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMBank
{
    public class Transactions
    {
        public Account account
        {
            get; set;
        }
        public string description
        {
            get; set;
        }
        public DateTime dateTime
        {
            get; set;
        }
        public string transactionType
        {
            get; set;
        }
        public decimal transactionAmount
        {
            get; set;
        }
        public Transactions(Account account, string description, DateTime dateTime, string transactionType, decimal transactionAmount)
        {
            this.account = account;
            this.description = description;
            this.dateTime = dateTime;
            this.transactionType = transactionType;
            this.transactionAmount = transactionAmount;
        }
        public Transactions()
        {
        }
        public override string ToString()
        {
            return $"Account:{account},Description:{description},Date and Time:{dateTime},Transaction Type:{transactionType},Transaction amount:{transactionAmount}";
        }

    }
}
