using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Entities;

namespace AutomatedTellerMachine
{
	public class CheckEventArgs : EventArgs
	{
		public Card card { get; set; }

		public CheckEventArgs(Card card)
		{
			this.card = card;
		}
	}
}
