using Abby.Data;
using Abby.Data.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType? FoodType { get; set; }

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(x => x.Id == id);
        }

        public IActionResult OnPost()
        {
            if (FoodType == null)
            {
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();

            }

            _unitOfWork.FoodType.Update(FoodType);
            _unitOfWork.Save();
            TempData["success"] = "Food type updated successfully";

            return RedirectToPage("Index");
        }
    }
}
