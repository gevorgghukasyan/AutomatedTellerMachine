﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTellerMachine
{
    class WrongPasswordException : Exception
    {
        public WrongPasswordException() : base("The card blocked")
        {

        }
    }
}
