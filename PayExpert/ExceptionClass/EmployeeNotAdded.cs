using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayExpert.ExceptionClass
{
    public class EmployeeNotAdded:Exception
    {
       
            public EmployeeNotAdded(string message) : base(message) { }
        

    }
}
