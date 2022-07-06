using Abby.Data;
using Abby.Data.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType? FoodType { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
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

            _unitOfWork.FoodType.Remove(FoodType);
            _unitOfWork.Save();
            TempData["success"] = "FoodType deleted successfully";

            return RedirectToPage("Index");
        }
    }
}
