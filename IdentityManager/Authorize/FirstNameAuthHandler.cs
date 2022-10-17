using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityManager.Authorize
{
    public class FirstNameAuthHandler : AuthorizationHandler<FirstNameAuthRequirement>
    {
        public UserManager<IdentityUser> _UserManager { get; set; }

        public ApplicationDBContext _db { get; set; }

        public FirstNameAuthHandler(UserManager<IdentityUser> userManager, ApplicationDBContext db)
        {
            _UserManager = userManager;
            _db = db;

        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, FirstNameAuthRequirement requirement)
        {
            string userId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _db.ApplicationUser.FirstOrDefault(u => u.Id == userId);
            var claims = Task.Run(async () => await _UserManager.GetClaimsAsync(user)).Result;
            var claim = claims.FirstOrDefault(c => c.Type == "FirstName");
            if (claim != null)
            {
                if (claim.Value.ToLower().Contains(requirement.Name.ToString()))
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
               
            }

            return Task.CompletedTask;

        }

    }

    
}
