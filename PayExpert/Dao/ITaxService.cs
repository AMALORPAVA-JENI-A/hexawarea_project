using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayExpert.Model;

namespace PayExpert.Dao
{
    public interface ITaxService
    {
        int Calculatetax(int employeeID, int taxYear);
        Tax GetTaxById(int taxID);
        Tax GetTaxesForEmployee(int employeeID);
        List<Tax> GetTaxesForYear(int taxYear);

    }
}
