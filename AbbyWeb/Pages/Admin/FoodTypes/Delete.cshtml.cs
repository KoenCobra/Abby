using Abby.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public FoodType? FoodType { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            if (_db.FoodTypes != null)
            {
                FoodType = _db.FoodTypes.Find(id);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (_db.FoodTypes == null || FoodType == null)
            {
                return Page();
            }

            _db.FoodTypes.Remove(FoodType);
            await _db.SaveChangesAsync();
            TempData["success"] = "FoodType deleted successfully";

            return RedirectToPage("Index");
        }
    }
}
