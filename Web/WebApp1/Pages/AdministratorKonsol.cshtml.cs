using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp1.Models;

namespace WebApp1.Pages
{
    [Authorize(policy: "AdminRettigheder")]
    public class AdministratorKonsolModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ILogger<AdministratorKonsolModel> logger;
        public IList<string> AllRoles { get; set; }

        public AdministratorKonsolModel(UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> _roleManager, ILogger<AdministratorKonsolModel> _logger)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            logger = _logger;
        }

        public IList<UserRolesViewModel> Users { get; set; } = new List<UserRolesViewModel>();

        public async Task<IActionResult> OnUserGetAsync()
        {
            var users = userManager.Users.ToList();
            AllRoles = roleManager.Roles.Select(r => r.Name).ToList();

            foreach (IdentityUser user in users) 
            {
                var roles = await userManager.GetRolesAsync(user);
                Users.Add(new UserRolesViewModel { UserId = user.Id, UserName = user.UserName, Email = user.Email, Roles = roles });
            }
            return Page();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await OnUserGetAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string userId, IList<string> roles)
        {
            logger.LogInformation($"Trying to find user with ID: {userId}");

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                logger.LogInformation($"User with ID: {userId} not found");
                return Page();
            }
            var userRoles = await userManager.GetRolesAsync(user);
            var addedRoles = roles.Except(userRoles);
            var removedRoles = userRoles.Except(roles);

            if (addedRoles.Count() > 0)
            {
                foreach (var role in addedRoles)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
            if (removedRoles.Count() > 0)
            {
                foreach (var role in removedRoles)
                {
                    await userManager.RemoveFromRoleAsync(user, role);
                }
            }
            
           
            
            return RedirectToPage();
        }
    }
}
