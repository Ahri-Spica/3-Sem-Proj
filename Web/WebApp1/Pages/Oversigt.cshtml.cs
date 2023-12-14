using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp1.Models;

namespace WebApp1.Pages
{
    public class OversigtModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public OversigtModel(UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }

        public IList<UserRolesViewModel> Users { get; set; } = new List<UserRolesViewModel>();

        public async Task<IActionResult> OnUserGetAsync()
        {
            var managerUsers = await userManager.GetUsersInRoleAsync("Bestyrelse");
            //Users = (IList<UserRolesViewModel>)managerUsers.Select(async user => new UserRolesViewModel()
            //{
            //    UserId = user.Id,
            //    UserName = user.UserName,
            //    Email = user.Email,
            //    Roles = await userManager.GetRolesAsync(user)
            //}).ToList();

            foreach (IdentityUser manager in managerUsers)
            {
                var roles = await userManager.GetRolesAsync(manager);
                Users.Add(new UserRolesViewModel { UserId = manager.Id, UserName = manager.UserName, Email = manager.Email, Roles = roles });
            }
            return Page();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await OnUserGetAsync();
            return Page();
        }
    }
}
