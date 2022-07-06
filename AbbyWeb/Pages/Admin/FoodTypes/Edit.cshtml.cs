using Abby.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public FoodType? FoodType { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            FoodType = _db.FoodTypes.Find(id);
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

            _db.FoodTypes.Update(FoodType);
            await _db.SaveChangesAsync();
            TempData["success"] = "Food type updated successfully";

            return RedirectToPage("Index");
        }
    }
}
