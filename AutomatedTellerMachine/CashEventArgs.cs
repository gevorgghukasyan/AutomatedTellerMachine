using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Entities;

namespace AutomatedTellerMachine
{
	public class CashEventArgs : EventArgs
	{
		public CashEventArgs(Card card, decimal money)
		{
			Card = card;
			Money = money;
		}

		public Card Card { get; set; }
		public decimal Money { get; set; }
	}
}
