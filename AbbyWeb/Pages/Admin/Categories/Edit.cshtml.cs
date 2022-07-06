using Abby.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category? Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (_db.Categories == null || Category == null)
            {
                return Page();
            }

            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Name cannot be the same as display order");
            }

            if (!ModelState.IsValid)
            {
                return Page();

            }

            _db.Categories.Update(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category updated successfully";

            return RedirectToPage("Index");
        }
    }
}
