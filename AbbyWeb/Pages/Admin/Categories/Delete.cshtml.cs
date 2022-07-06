using Abby.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category? Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            if (_db.Categories != null)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (_db.Categories == null || Category == null)
            {
                return Page();
            }

            _db.Categories.Remove(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category deleted successfully";

            return RedirectToPage("Index");
        }
    }
}
