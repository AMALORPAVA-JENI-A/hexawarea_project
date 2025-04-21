using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayExpert.Model
{
    public class FinancialRecord
    {
        public int recordID
        {
            get; set;
        }
        public int employeeID
        {
            get; set;
        }
        public DateTime recordDate
        {
            get; set;
        }
        public string description
        {
            get; set;
        }
        public decimal amount
        {
            get; set;
        }
        public string recordType
        {
            get; set;
        }
        public FinancialRecord()
        {
        }
        public FinancialRecord(int recordID, int employeeID, DateTime recordDate, string description, decimal amount, string recordType)
        {
            this.recordID = recordID;
            this.employeeID = employeeID;
            this.recordDate = recordDate;
            this.description = description;
            this.amount = amount;
            this.recordType = recordType;
        }
        public override string ToString()
        {
            return $"Record ID={recordID} , Employee ID={employeeID} , Record date={recordDate} , Description={description} , Amount={amount} , Record type={recordType}";
        }
    }
}
