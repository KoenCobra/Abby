using Abby.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category? Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
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

            await _db.Categories.AddAsync(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category created successfully";
            return RedirectToPage("Index");
        }
    }
}
