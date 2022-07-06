using Abby.Data;
using Abby.Data.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Category? Category { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
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

            _unitOfWork.Category.Add(Category);
            _unitOfWork.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToPage("Index");
        }
    }
}
