using Abby.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<FoodType>? FoodTypes { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public void OnGet()
        {
            FoodTypes = _db.FoodTypes;
        }
    }
}
