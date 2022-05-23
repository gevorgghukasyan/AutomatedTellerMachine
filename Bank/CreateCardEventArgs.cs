using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Entities;

namespace Bank
{
	public class CreateCardEventArgs : EventArgs
	{
		public Card card { get; set; }
		public User user { get; set; }

		public CreateCardEventArgs(Card card, User user)
		{
			this.card = card;
			this.user = user;
		}
	}
}
