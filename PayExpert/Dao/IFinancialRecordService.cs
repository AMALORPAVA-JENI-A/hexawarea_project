using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayExpert.Model;

namespace PayExpert.Dao
{
    public interface IFinancialRecordService
    {
        int AddFinancialRecord(int employeeID,DateTime recordDate, string description, decimal amount, string recordType);
        FinancialRecord GetFinancialRecordsById(int recordID);
        FinancialRecord GetFinancialRecordsForEmployee(int employeeID);
        List<FinancialRecord> GetFinancialRecordsForDate(DateTime recordDate);



    }
}
