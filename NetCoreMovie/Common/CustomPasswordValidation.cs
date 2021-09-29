using Microsoft.AspNetCore.Identity;
using System;

namespace Common
{
    public class CustomPasswordValidation : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            IdentityError error = new IdentityError();
            error.Code = "PasswordTooShort";
            error.Description = $"şifreniz en az {length} karakter olmalı! ";
            return error;
        }

        public override IdentityError DuplicateEmail(string email)
        {
            IdentityError error = new IdentityError();
            error.Code = "DuplicateEmail";
            error.Description = $"{email} daha önce kaydedilmiş! ";
            return error;
        }
    }
}
