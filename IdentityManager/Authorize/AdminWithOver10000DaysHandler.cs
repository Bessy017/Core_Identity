using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityManager.Authorize
{
    public class AdminWithOver10000DaysHandler : AuthorizationHandler<AdminWithMoreThan10000DaysRequirement>
    {
        private readonly INumberOfDaysForAccount _numberOfDaysForAccount;
        public AdminWithOver10000DaysHandler (INumberOfDaysForAccount numberOfDaysForAccount)
        {
            _numberOfDaysForAccount = numberOfDaysForAccount;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminWithMoreThan10000DaysRequirement requirement)
        {
            if (!context.User.IsInRole("Admin"))
            {
                return Task.CompletedTask;
            }

            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            int numberOfDays = _numberOfDaysForAccount.Get(userId);
            if(numberOfDays >= requirement.Days)
            {
                context.Succeed(requirement);

            }
            return Task.CompletedTask;

        }

    }

    
}
