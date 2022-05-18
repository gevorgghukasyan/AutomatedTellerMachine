using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
   public class Rate
    {
        public string MoneyType { get; set; }
        public string Value { get; set; }

        public Rate(string MoneyType, string Value)
        {
            this.MoneyType = MoneyType;
            this.Value = Value;
        }
    }
}
