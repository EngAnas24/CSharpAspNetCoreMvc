using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Test_T.Areas.Identity.Pages.Account.Manage
{
    public class DashboardModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IdentityUser User { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve the current ClaimsPrincipal representing the user
            var userPrincipal = HttpContext.User;

            // Retrieve the IdentityUser based on the current user's claims
            User = await _userManager.GetUserAsync(userPrincipal);

            if (User == null)
            {
                return NotFound($"User not found.");
            }

            return Page();
        }
    }
}
