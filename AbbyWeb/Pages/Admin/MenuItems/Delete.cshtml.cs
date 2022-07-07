using Abby.Data.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.MenuItems
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MenuItem? MenuItem { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public void OnGet(int id)
        {
            MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(x => x.Id == id);
        }

        public IActionResult OnPost()
        {
            if (MenuItem == null)
            {
                return Page();
            }
            _unitOfWork.MenuItem.Remove(MenuItem);
            _unitOfWork.Save();
            TempData["success"] = "MenuItem deleted successfully";

            return RedirectToPage("Index");
        }
    }
}
