using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCQLKS.Models
{
    public class RegisterError
    {
        public string ErrorUserName { get; set; }

        public string ErrorPassword { get; set; }

        public string ErrorConfirmPassword { get; set; }

        public string ErrorName { get; set; }

        public string ErrorCaptcha { get; set; }
    }
}