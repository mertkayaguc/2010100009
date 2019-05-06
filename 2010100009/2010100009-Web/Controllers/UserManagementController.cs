using _2010100009_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2010100009_Web.Controllers
{
    [Authorize]
    public class UserManagementController : Controller
    {
        private readonly StudentDBContext _context;
        private readonly UserManager<WebUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string DepartmentAdminRole = "department admin";


        public UserManagementController(StudentDBContext context, UserManager<WebUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ActionResult> Index()
        {
            var userList = _context
                .Users
                .ToList();

            List<UserModel> userModelList = new List<UserModel>();

            foreach (var item in userList)
            {
                bool isadmin = await _userManager.IsInRoleAsync(item, "admin");
                bool isdepadmin = await _userManager.IsInRoleAsync(item, DepartmentAdminRole);
                var user = new UserModel
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    FullName = item.FirstName + " " + item.LastName,
                    IsAdmin = isadmin,
                    IsDepartmentAdmin = isdepadmin
                };
                userModelList.Add(user);
            }
            return View(userModelList);
        }

        public async Task<ActionResult> MakeAdmin(string id)
        {
            if (!(await _roleManager.RoleExistsAsync("admin")))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "admin" });
            }
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(user, "admin");
            return RedirectToAction("index");
        }

        public async Task<ActionResult> RemoveAdmin(string id)
        {

            var user = await _userManager.FindByIdAsync(id);
            await _userManager.RemoveFromRoleAsync(user, "admin");
            return RedirectToAction("index");
        }

        public async Task<ActionResult> MakeDepartmentAdmin(string id)
        {
            if (!(await _roleManager.RoleExistsAsync(DepartmentAdminRole)))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = DepartmentAdminRole });
            }
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(user, DepartmentAdminRole);
            return RedirectToAction("index");
        }

        public async Task<ActionResult> RemoveDepartmentAdmin(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.RemoveFromRoleAsync(user, DepartmentAdminRole);
            return RedirectToAction("index");
        }
    }
}