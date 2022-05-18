using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Common;
namespace Core
{
    public class CardManager : IAccountManager
    {
        private readonly IRepository _repository;
        private readonly IUserRepository _userRepository;

        public CardManager(IRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        private string GenerateCardID()
        {
            Random random = new Random();
            string cardId = "";
            for (int i = 0; i <= 15; i++)
            {
                cardId += random.Next(10);
            }
            CardID = cardId;
            return cardId;
        }

        private string GeneratePassword()
        {
            Random random = new Random();
            string password = "";
            for (int i = 0; i < 4; i++)
            {
                password += random.Next(1, 10);
            }
            return password;
        }


        private string CardID = "";

        public string GenerateGuid()
        {
            return System.Guid.NewGuid().ToString();
        }

        private string SHA1(string password, string salt)
        {
            var passSalt = password + salt;

            using (var algorithm = System.Security.Cryptography.SHA1.Create())
            {
                var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(passSalt));
                var HashedPassword = Convert.ToBase64String(hash);

                return HashedPassword;
            }
        }

        public NewCardInfo CreateNewCard(Card card)
        {
            card.Validation = DateTime.Now.AddYears(5);
            string password = GeneratePassword();
            card.Guid = GenerateGuid();
            card.AccountNumber = GenerateCardID();
            card.Password = SHA1(password, card.Guid);
            card.Blocked = false;
            _repository.AddCard(card);


            var cardInfo = new NewCardInfo(card.AccountNumber, password);

            return cardInfo;
        }

        public bool CheckCredentials(string cardId, string password)
        {
            var cardData = _repository?.GetById(cardId);
            if (password.Length == 4 && int.TryParse(password, out _))
            {
                var checkPassword = SHA1(password, cardData.Guid);
                if (checkPassword == cardData.Password)
                {
                    return true;
                }
            }
            return false;
        }

        public NewUserInfo AddNewUser(User user)
        {
            CustomerInfo info = new CustomerInfo();
            info.FirstName = user.FirstName;
            info.LastName = user.LastName;
            info.BirthDay = user.BirthDay;
            info.Email = user.Email;
            info.PassportSerial = user.PassportSerial;
            NewUserInfo userInfo = new NewUserInfo()
            {
                Name = user.FirstName
            };
            _userRepository.AddUser(user);
            return userInfo;
        }
    }
}