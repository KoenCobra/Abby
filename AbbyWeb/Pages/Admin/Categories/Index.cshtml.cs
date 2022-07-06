using Abby.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Category>? Categories { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public void OnGet()
        {
            Categories = _db.Categories;
        }
    }
}
