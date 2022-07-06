using System.Net.Mime;
using Abby.Data.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AbbyWeb.Pages.Admin.MenuItems
{
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public MenuItem? MenuItem{ get; set; }
        public IEnumerable<SelectListItem>? CategoryList { get; set; }
        public IEnumerable<SelectListItem>? FoodTypeList { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            MenuItem = new ();
        }

        public void OnGet()
        {
            CategoryList = _unitOfWork.Category.GetAll().Select(x=> new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            FoodTypeList = _unitOfWork.FoodType.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }

        public IActionResult OnPost()
        {
            if (MenuItem == null)
            {
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();

            }

            //_unitOfWork.(MenuItem);
            _unitOfWork.Save();
            TempData["success"] = "FoodType created successfully";
            return RedirectToPage("Index");
        }
    }
}
