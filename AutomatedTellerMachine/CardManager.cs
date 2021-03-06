using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Entities;
using DAL;

namespace AutomatedTellerMachine
{
	public class CardManager
	{
		IRepository repository;
		public CardManager(IRepository repository)
		{
			this.repository = repository;
		}

		public void BlockCard(Card cards)
		{
			Card card = repository.GetById(cards.AccountNumber);
			card.Blocked = true;
			repository.UpdateCard(card);
		}
	}
}
