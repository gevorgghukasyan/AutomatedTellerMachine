using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Entities;
using Core;
using DAL;

namespace AutomatedTellerMachine
{
	public enum LoginResultType
	{
		Success,
		NotFound,
		WrongPaswword,
		Expired,
		Blocked
	}

	class BusinessLogic
	{
		IView view;
		IRepository repository;
		IUserRepository userRepository;
		IAccountManager accountManager;
		INotificationService notificationService;

		public BusinessLogic(IRepository _repository, IView _view, IUserRepository _userRepository, INotificationService _notificationService, IAccountManager _accountManager)
		{
			view = _view;
			repository = _repository;
			userRepository = _userRepository;
			accountManager = _accountManager;
			notificationService = _notificationService;
			InitializationEvent();
		}

		public void InitializationEvent()
		{
			view.OnSubmitIdPass += View_OnSubmitIdPass;
			view.OnCashIn += View_OnCashIn;
			view.OnCashOut += View_OnCashOut;
			view.OnBalanceRequest += View_OnBalanceRequest;
		}

		private void View_OnBalanceRequest(object sender, CheckEventArgs e)
		{
			view.InfoMessage($"Your amount is {GetBalance(e.card)} $");
		}

		private void View_OnCashIn(object sender, CashEventArgs e)
		{
			CashIn(e.Card, e.Money);
			EmailOrganizing(e.Card);
		}

		private void View_OnCashOut(object sender, CashEventArgs e)
		{
			CashOut(e.Card, e.Money);
			EmailOrganizing(e.Card);
		}

		private void View_OnSubmitIdPass(object sender, Card e)
		{
			var result = IsCardAuthorizationTrue(e);
			switch (result)
			{
				case LoginResultType.Success:
					view.SuccessLogin();
					break;
				case LoginResultType.NotFound:
				case LoginResultType.WrongPaswword:
				case LoginResultType.Expired:
				case LoginResultType.Blocked:
					view.FailLogin(result);
					break;
				default:
					view.FailLogin(result);
					break;
			}
		}

		List<string> faildCardsList = new List<string>();
		private LoginResultType IsCardAuthorizationTrue(Card GetCard)
		{
			Card card = repository.GetById(GetCard.AccountNumber);
			if (card != null && card.AccountNumber.Length == 16)
			{
				if (accountManager.CheckCredentials(GetCard.AccountNumber, GetCard.Password))
				{
					if (!card.Blocked)
					{

						if (card.Validation > DateTime.Now)
						{
							return LoginResultType.Success;
						}

						else
						{
							return LoginResultType.Expired;
						}

					}

					else
					{
						return LoginResultType.Blocked;
					}
				}

				else
				{
					try
					{
						AddFailedCard(GetCard);
						return LoginResultType.WrongPaswword;
					}
					catch (WrongPasswordException)
					{
						CardManager manager = new CardManager(repository);
						manager.BlockCard(card);
						return LoginResultType.Blocked;
					}
				}
			}

			else
			{
				return LoginResultType.NotFound;
			}
		}

		void AddFailedCard(Card card)
		{
			if (faildCardsList.LastOrDefault() == card.AccountNumber)
			{
				if (faildCardsList.Count == 2)
				{
					throw new WrongPasswordException();
				}
				else
				{
					faildCardsList.Add(card.AccountNumber);
				}
			}

			else
			{
				faildCardsList.Clear();
				faildCardsList.Add(card.AccountNumber);
			}
		}

		private void EmailOrganizing(Card card)
		{
			Card getCard = repository.GetById(card.AccountNumber);
			User user = new User();
			user.Id = getCard.UserId;
			User getUser = userRepository.GetByPassportSerial(user.Id);
			notificationService.SendMessage(getUser, "Dear customer, 5000 USD was transferred to your account, the transfer was made from 2113324868708825 customer.");// $" Dear {getUser.FirstName} your transaction is done․ Your account is: { getCard.Balance}");
		}

		private decimal GetBalance(Card cardData)
		{
			Card card = repository.GetById(cardData.AccountNumber);
			return card.Balance;
		}

		private void CashOut(Card card, decimal moneySize)
		{
			Card balance = new Card();
			if (GetBalance(card) >= moneySize)
			{
				card.Balance = GetBalance(card) - moneySize;
				repository.UpdateCard(card);
			}

			else
			{
				view.WarningMessage("Insufficient funds");
			}
		}

		private void CashIn(Card card, decimal moneySize)
		{
			Card balance = new Card();
			card.Balance = GetBalance(card) + moneySize;
			repository.UpdateCard(card);
		}

		private void TaxStorage(decimal moneySize)
		{

		}

	}

}
