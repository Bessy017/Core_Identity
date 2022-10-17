using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDBContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(ApplicationDBContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles = _db.Roles.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Upsert(String id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return View();

            }
            else
            {   //update
                var objfromDb = _db.Roles.ToList();
                return View(objfromDb);
            }

        }
        [HttpPost]
        [Authorize(Policy = "OnlySuperAdminChecker")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(IdentityRole roleObj)
        {
            if (await _roleManager.RoleExistsAsync(roleObj.Name))
            {
              
            }
            if (string.IsNullOrEmpty(roleObj.Id))
            {
                //create
                await _roleManager.CreateAsync(new IdentityRole() { Name = roleObj.Name });
            }
            else
            {
                //update
                var objRoleFromDb = _db.Roles.FirstOrDefault(u => u.Id == roleObj.Id);
                objRoleFromDb.Name = roleObj.Name;
                objRoleFromDb.NormalizedName = roleObj.Name.ToUpper();
                var result = await _roleManager.UpdateAsync(objRoleFromDb);
                //TempData[SD.success] = "Role updated successfully";

            }
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string userid)
        {
            var objFromDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == userid);
            if (objFromDb == null)
            {

                return NotFound();
            }

            _db.ApplicationUser.Remove(objFromDb);
            _db.SaveChanges();
            //TempData[SD.success] = "User deleted successfully";

            return RedirectToAction(nameof(Index));

        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var objFromDb = _db.Roles.FirstOrDefault(u => u.Id == id);
        //    if (objFromDb == null)
        //    {
        //        TempData[SD.Error] = " Role bot found.";
        //        return RedirectToAction(nameof(Index));
        //    }

        //    var userRolesForThisRole = _db.UserRoles.Where(u => u.RoleId == id).Count();
        //    if (userRolesForThisRole > 0)
        //    {
        //        TempData[SD.Error] = " Cannon delete this role, since there are users assigned to this role.";
        //        return RedirectToAction(nameof(Index));
        //    }

        //    await _roleManager.DeleteAsync(objFromDb);

        //    return RedirectToAction(nameof(Index));

        //}
    }

}


    