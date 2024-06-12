using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstate.Core;
using RealEstate.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Test_T.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDataHelper<RealEstateProperty> data;

        public IndexModel(IDataHelper<RealEstateProperty> data)
        {
            this.data = data;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostSearch(RealEstateProperty searchParameters)
        {
            if (searchParameters == null)
            {
                // Handle null search parameters
                return BadRequest("Search parameters cannot be null.");
            }

            var allProperties = data.GetData();

            if (allProperties == null)
            {
                // Handle null property collection
                return BadRequest("Property data is not available.");
            }

            var searchResults = allProperties
                .Where(p => p.OffertypeLiist == searchParameters.OffertypeLiist
                         && p.PropertytypeList == searchParameters.PropertytypeList
                         && p.propertyaddress.Contains(searchParameters.propertyaddress))
                .ToList();

            TempData["SearchResults"] = JsonSerializer.Serialize(searchResults);

            return RedirectToPage("/SearchResult");
        }

    }
}
