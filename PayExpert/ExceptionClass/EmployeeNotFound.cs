using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayExpert.ExceptionClass
{
    public class EmployeeNotFound:Exception
    {
        public EmployeeNotFound(string message) : base(message) { }
    }
}
