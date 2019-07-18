﻿using MadPay724.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Services.Site.Admin.User.Interface
{
    public interface IUserService
    {
        Task<Data.Models.User> GetUserForPassChange(string id, string password);
        Task<bool> UpdateUserPass(Data.Models.User user, string newPassword);
    }
}