using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.Models
{
    public class VerifyAuthenticatorViewModel
    {
        [Required]

        public string Code { get; set; }
        public String ReturnUrl { get; set; }
        [Display(Name = "Remember me?")]
        public bool RemenberMe { get; set; }
    }
}
