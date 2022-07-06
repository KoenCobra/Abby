using Abby.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public FoodType? FoodType { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (_db.FoodTypes == null || FoodType == null)
            {
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();

            }

            await _db.FoodTypes.AddAsync(FoodType);
            await _db.SaveChangesAsync();
            TempData["success"] = "FoodType created successfully";
            return RedirectToPage("Index");
        }
    }
}
