﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MadPay724.Data.Models;
using MadPay724.Repo.Infrastructure;

namespace MadPay724.Repo.Repositories.Interface
{
    public interface IBankCardRepository : IRepository<BankCard>
    {
        Task<int> BankCardCountAsync(string userId);
    }
}