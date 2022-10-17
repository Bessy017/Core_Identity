using IdentityManager.Data;
using IdentityManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityManager.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(ApplicationDBContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;

        }

        public IActionResult Index()
        {
            var userList = _db.ApplicationUser.ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in userList)
            {

                var role = userRole.FirstOrDefault(u => u.UserId == user.Id);
                if (role == null)
                {
                    user.RoleId = "Nome";
                }
                else
                {
                    user.RoleId = roles.FirstOrDefault(u => u.Id == role.RoleId).Name;
                }
            }

            return View();
        }

        public IActionResult Edit(string userId)
        {
            var objFromDb = _db.ApplicationUser.FirstOrDefault(u =>u.Id == userId);

            if (objFromDb == null)
            {
                return NotFound();

            }
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            var role = userRole.FirstOrDefault(u => u.UserId == objFromDb.Id);
            if (role != null)
            {
                objFromDb.RoleId = roles.FirstOrDefault(u => u.Id == role.RoleId).Id;
            }

            objFromDb.RoleList = _db.Roles.Select(u => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = u.Name,
                Value = u.Id

            });

            return View(objFromDb);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task <IActionResult> Edit(ApplicationUser user)
        {
            var objFromDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == user.Id);

            if (objFromDb == null)
            {
                return NotFound();

            }
            var userRole = _db.UserRoles.FirstOrDefault(u => u.UserId == objFromDb.Id);
            if(userRole != null)
            {
                var previousRoleName = _db.Roles.Where(u => u.Id == userRole.RoleId).Select(e => e.Name).FirstOrDefault();
                //removing the old role
                await _userManager.RemoveFromRoleAsync(objFromDb, previousRoleName);

                //Add new role
                await _userManager.AddToRoleAsync(objFromDb, _db.Roles.FirstOrDefault(u => u.Id == user.RoleId).Name);
                objFromDb.Name = user.Name;
                _db.SaveChanges();
                TempData[SD.Success] = "User has been edited successfully";
                return RedirectToAction(nameof(Index));

            }

            user.RoleList = _db.Roles.Select(u => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = u.Name,
                Value = u.Id

            });

            return View(objFromDb);
        }

        [HttpPost]


        public IActionResult LockUnlock(string userId)
        {
            var objFromDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == userId);

            if (objFromDb == null)
            {
                return NotFound();

            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //user is locked
                objFromDb.LockoutEnd = DateTime.Now;
                TempData[SD.Success] = "User unlocked successfully.";
            }

            else
            {
                // user is not  locked

                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
                TempData[SD.Success] = "User unlocked successfully.";
            }

            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]

        public IActionResult Delete(string userId)
        {
            var odjFromDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == userId);
            if (odjFromDb == null)
            {
                return NotFound();

            }
            _db.ApplicationUser.Remove(odjFromDb);
            _db.SaveChanges();
            TempData[SD.Success] = "User Deleted successfully.";
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]

            public async Task<IActionResult> ManageUserClaims(string userId)
            {
                IdentityUser user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound();
                }
            var existingUserClaims = await _userManager.GetClaimsAsync(user);
               
                var model = new Models.UserClaimsViewModel()
                {
                    UserId = userId
                };

                foreach (Claim claim in ClaimStore.claimsList)
                {
                    UserClaim userClaim = new UserClaim
                    {
                        ClaimType = claim.Type
                    };
                    if (existingUserClaims.Any(c=>c.Type==claim.Type))
                    {
                    userClaim.IsSelected = true;
                    }
                    model.Claims.Add(userClaim);
                }

                return View(model);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ManageUserClaims(UserClaimsViewModel userClaimsViewModel)
        {
            IdentityUser user = await _userManager.FindByIdAsync(userClaimsViewModel.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var claims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.RemoveClaimsAsync(user,claims);

            if (!result.Succeeded)
            {
                TempData[SD.Error] = "error while removing claims.";
                return View(userClaimsViewModel);
            }

             result = await _userManager.AddClaimsAsync(user,
                userClaimsViewModel.Claims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.IsSelected.ToString()))
                );

            TempData[SD.Success] = "Claims update successfully.";
            return RedirectToAction(nameof(Index));


        }









    }

    
}
