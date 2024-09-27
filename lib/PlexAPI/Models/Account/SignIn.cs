using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexAPI.Models.Account
{
    internal class SignIn
    {
        public string login { get; set; }
        public string password { get; set; }
        public bool rememberMe { get; set; } = true;
        public string verificationCode { get; set; } = null;
    }
}
