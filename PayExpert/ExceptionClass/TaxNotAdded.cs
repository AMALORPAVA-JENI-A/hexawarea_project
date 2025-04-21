using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayExpert.ExceptionClass
{
    public class TaxNotAdded:Exception
    {
        public TaxNotAdded(string message):base(message) { }
    }
}
