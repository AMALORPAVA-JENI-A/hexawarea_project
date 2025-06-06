﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Exceptions
{
    public class InsufficientFundException:Exception
    {
        public InsufficientFundException(string message) : base(message) { }
    }

    public class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) : base(message) { }
    }

    public class OverDraftLimitExceededException : Exception
    {
        public OverDraftLimitExceededException(string message) : base(message) { }
    }
}
