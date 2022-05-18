using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Core;
using DAL;

namespace Bank
{
    enum WrongDataType
    {
        FirstName,
        LastName,
        BirthDay,
        Email,
        PassportSerial
    }

    class BuisnessLogic
    {
        private readonly IView _view;
        private readonly IRepository _bankRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotificationService _notificationService;
        private readonly IAccountManager _manager;

        RateProvider provider = new RateProvider();

        public BuisnessLogic(IView _view,IRepository _bankRepository,IUserRepository _userRepository,INotificationService _notificationService,IAccountManager _manager)
        {
            this._view = _view;
            this._bankRepository = _bankRepository;
            this._userRepository = _userRepository;
            this._notificationService = _notificationService;
            this._manager = _manager;
            InitializationEvent();
        }

        public void InitializationEvent()
        {
            _view.OnCreateCard += View_OnCreateCard;
            _view.OnLoad += _view_OnLoad;
        }

        private void _view_OnLoad(object sender, EventArgs e)
        {
            var rates = provider.GetValueMoney();
            _view.ShowRates(rates);
        }

        private void View_OnCreateCard(object sender, CreateCardEventArgs e)
        {
            try
            {
                ValidateUser(e.user);
                var newUser = _manager.AddNewUser(e.user);
                var newCard= _manager.CreateNewCard(e.card);
                _view.SuccessTransaction();
                _notificationService.SendMessage(e.user, $"Congratulations dear {newUser.Name} your card is created․Your CardID is: {newCard.Id}, your password is: {newCard.Pin}");
            }

            catch (Exception ex)
            {
                _view.WarningMessage(ex.Message);
            }
        }

        private void ValidateUser(User user)
        {
            if (!user.FirstName.IsMatch(@"^([A-Za-z]+)$"))
            {
                throw new Exception("Wrong FirstName...Try again!");
            }

            if (!user.LastName.IsMatch(@"^([A-Za-z]+)$"))
            {
                throw new Exception("Wrong LastName...Try again!");
            }

            if ((DateTime.Now.AddYears(-18)<user.BirthDay))
            {
                throw new Exception("The transaction is only for adults");
            }

            if (!user.Email.IsMatch(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                throw new Exception("Wrong Email...Try again!");
            }

            if (!user.PassportSerial.IsMatch(@"^([A-Z,a-z]{2})([0-9]{7})$"))
            {
                throw new Exception("Wrong PassportSerial...Try again!");
            }
        }
        
    }
}
