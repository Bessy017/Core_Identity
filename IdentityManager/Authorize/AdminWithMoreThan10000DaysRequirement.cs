using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.Authorize
{
    public class AdminWithMoreThan10000DaysRequirement : IAuthorizationRequirement
    {
        public AdminWithMoreThan10000DaysRequirement (int days)
        {
            Days = days;
        }
        public int Days { get; set; }
    }
}
