using Abby.Data;
using Abby.Data.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Category? Category { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
        }

        public IActionResult OnPost()
        {
            if (Category == null)
            {
                return Page();
            }

            _unitOfWork.Category.Remove(Category);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";

            return RedirectToPage("Index");
        }
    }
}
