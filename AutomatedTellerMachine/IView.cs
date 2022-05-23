using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Entities;

namespace AutomatedTellerMachine
{
	public interface IView
	{
		event EventHandler<Card> OnSubmitIdPass;
		void SuccessLogin();
		void FailLogin(LoginResultType message);
		void WarningMessage(string message);
		void InfoMessage(string message);
		event EventHandler<CheckEventArgs> OnBalanceRequest;
		event EventHandler<CashEventArgs> OnCashOut;
		event EventHandler<CashEventArgs> OnCashIn;
		event EventHandler OnTaxRequest;
	}
}
