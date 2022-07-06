using Abby.Data;
using Abby.Data.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType? FoodType { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
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

            _unitOfWork.FoodType.Add(FoodType);
            _unitOfWork.Save();
            TempData["success"] = "FoodType created successfully";
            return RedirectToPage("Index");
        }
    }
}
