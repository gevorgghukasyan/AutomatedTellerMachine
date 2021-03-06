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
			return new Regex(pattern)
				.IsMatch(stringToValidate);
		}
	}
}
