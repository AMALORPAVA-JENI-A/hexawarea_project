using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayExpert.ExceptionClass
{
    public class PayrollNotFound:Exception
    {
        public PayrollNotFound(string message):base (message) { }
    }
}
