using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

using Common.Entities;
namespace DAL
{
	public interface IRepository
	{
		Card GetById(string id);
		List<Card> GetAllCards();
		void UpdateCard(Card card);
		void AddCard(Card card);
	}
}
