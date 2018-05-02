using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCQLKS.Models
{
    public class UserRegisting
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Name { get; set; }

        public string CaptchaCode { get; set; }
    }
}