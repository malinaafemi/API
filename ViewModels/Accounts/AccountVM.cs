﻿using API.Utility;

namespace API.ViewModels.Accounts
{
    public class AccountVM
    {
        public Guid? Guid { get; set; }

        [PasswordValidation]
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public int OTP { get; set; }

        public bool IsUsed { get; set; }

        DateTime ExpiredTime { get; set; }


    }
}
