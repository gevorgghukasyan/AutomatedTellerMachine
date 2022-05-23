using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Bank
{
	public interface IView
	{
		event EventHandler<CreateCardEventArgs> OnCreateCard;
		event EventHandler OnLoad;
		void SuccessTransaction();
		void WarningMessage(string message);
		void ShowRates(IEnumerable<Rate> rates);
	}
}
