using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.Models
{
    public class ForgotPasswordView
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

   
    

}
