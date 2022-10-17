using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.Controllers
{
    [Authorize]
    public class AccessChekerController : Controller
    {
        [AllowAnonymous]
        public IActionResult AllAccess()
        {
            return View();
        }

        [Authorize]
        // Accessibible logged
        public IActionResult AuthorizedAccess()
        {
            return View();
        }

        [Authorize (Roles ="user")]
        //Accessibible  user role
        public IActionResult UserAccess()
        {
            return View();
        }

        [Authorize(Roles = "user,Admin")]
        //Accessibible  user role
        public IActionResult UserORAdminAcces()
        {
            return View();
        }

        [Authorize(Policy = "userAndAdmin")]
        //Accessibible  user role
        public IActionResult UserANDAdminAccess()
        {
            return View();
        }

        [Authorize(Policy = "Admin")]
        //Accessibible admin role
        public IActionResult AdminAccess()
        {
            return View();
        }
        [Authorize(Policy = "Admin_CreateAccess")]
        // Accessibible by admin
        public IActionResult Admin_CreateAccess()
        {
            return View();
        }

        [Authorize(Policy = "Admin_Create_Edit_DeleteAccess")]
        // Accessibible by admin
        public IActionResult Admin_Create_Edit_DeleteAccess()
        {
            return View();
        }

        // Accessibible by admin (And not or)

        public IActionResult Admin_Create_Edit_DeletedAccess()
        {
            return View();
        }

        [Authorize(Policy = "Admin_Create_Edit_DeletedAccess_OR_SuperAdmin")]
        // Accessibible by admin (And not or) super admin

        public IActionResult Admin_Create_Edit_DeletedAccess_OR_SuperAdmin()
        {
            return View();
        }

        [Authorize(Policy = "AdminWithMoreThan10000Days")]
       public IActionResult OnlyBhrugen()

        {
            return View();
        }

        [Authorize(Policy = "FirstNameAuth")]
        public IActionResult FirstNameAuth()
        {
            return View();
        }

        



    }
}
