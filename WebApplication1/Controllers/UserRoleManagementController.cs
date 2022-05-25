using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers
{
    public class UserRoleManagementController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserRoleManagementController(UserManager<IdentityUser> userManager,
                                            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            ViewBag.UserName = user.UserName;

            var userRoles = await userManager.GetRolesAsync(user);

            return View(userRoles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return RedirectToAction(nameof(DisplayRoles));
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string role)
        {
            await roleManager.CreateAsync(new IdentityRole(role));
            return RedirectToAction(nameof(DisplayRoles));
        }

        [HttpGet]
        public IActionResult DisplayRoles()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddUserToRole()
        {
            var roles = roleManager.Roles.ToList();
            var users = userManager.Users.ToList();

            ViewBag.Users = new SelectList(users, "Id" , "UserName");
            ViewBag.Roles = new SelectList(roles, "Name", "Name");
            return View();
        }
    }
}
