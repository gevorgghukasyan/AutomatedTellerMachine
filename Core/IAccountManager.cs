using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Entities;

namespace Core
{
	public interface IAccountManager
	{
		NewCardInfo CreateNewCard(Card card);

		bool CheckCredentials(string cardId, string password);

		NewUserInfo AddNewUser(User user);
	}


	public class NewCardInfo
	{
		public NewCardInfo(string id, string pin)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			if (pin == null)
			{
				throw new ArgumentNullException(nameof(pin));
			}

			Id = id;
			Pin = pin;
		}

		public string Id { get; set; }
		public string Pin { get; set; }
	}

	public class NewUserInfo
	{
		public string Name { get; set; }
	}
}
