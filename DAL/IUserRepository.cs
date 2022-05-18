﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DAL
{
   public interface IUserRepository
    {
        User GetByPassportSerial(int userId);
        void AddUser(User user);
    }
}
