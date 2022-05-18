using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public static class ValidationExtensions
    {
        public static bool IsMatch(this string stringToValidate, string pattern)
        {
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(stringToValidate))
            {
                return true;
            }

            return false;
        }
    }
}
