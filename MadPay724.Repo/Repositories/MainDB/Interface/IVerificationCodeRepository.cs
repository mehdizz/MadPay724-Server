﻿using MadPay724.Data.Models.MainDB;
using MadPay724.Repo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Repo.Repositories.MainDB.Interface
{
  public  interface IVerificationCodeRepository : IRepository<VerificationCode>
    {
    }
}
