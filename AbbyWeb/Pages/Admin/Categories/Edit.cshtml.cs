using Abby.Data;
using Abby.Data.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Category? Category { get; set; }

        public EditModel(IUnitOfWork unitOfWork)
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

            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Name cannot be the same as display order");
            }

            if (!ModelState.IsValid)
            {
                return Page();

            }

            _unitOfWork.Category.Update(Category);
             _unitOfWork.Save();
            TempData["success"] = "Category updated successfully";

            return RedirectToPage("Index");
        }
    }
}
