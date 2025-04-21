using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayExpert.ExceptionClass
{
    public class PayrollNotAdded:Exception
    {
        public PayrollNotAdded(string message) : base(message) { }
    }
}
