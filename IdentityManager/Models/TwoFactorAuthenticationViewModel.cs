using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.Models
{
    public class TwoFactorAuthenticationViewModel
    {

        //used to login
        public string Code { get; set; }

        //public to register
        public string Token { get; set; }
    }
}
