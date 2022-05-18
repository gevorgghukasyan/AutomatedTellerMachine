using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;


namespace AutomatedTellerMachine
{
   public class CashEventArgs:EventArgs
    {
        public CashEventArgs(Card card, decimal Money)
        {
            this.card = card;
            this.Money = Money;
        }


        public Card card { get; set; }
        public decimal Money { get; set; }
    }
}
