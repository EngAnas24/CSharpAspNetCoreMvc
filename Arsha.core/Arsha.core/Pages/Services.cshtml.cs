using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Arsha.core.Pages
{
    [Authorize("AdminClm")]

    public class ServicesModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
