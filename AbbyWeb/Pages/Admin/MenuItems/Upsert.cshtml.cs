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
        private readonly IWebHostEnvironment _hostEnvironment;
        public MenuItem? MenuItem { get; set; }
        public IEnumerable<SelectListItem>? CategoryList { get; set; }
        public IEnumerable<SelectListItem>? FoodTypeList { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            MenuItem = new();
        }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(x => x.Id == id);
            }
            CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem()
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

            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (MenuItem.Id == 0)
            {
                string fileName_new = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\menuItems");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                MenuItem.ImageUrl = @"\images\menuItems\" + fileName_new + extension;
                _unitOfWork.MenuItem.Add(MenuItem);
                _unitOfWork.Save();
            }
            else
            {
                var menuItemFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(x => x.Id == MenuItem.Id);
                if (files.Count > 0)
                {
                    string fileName_new = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\menuItems");
                    var extension = Path.GetExtension(files[0].FileName);

                    var oldImgPath = Path.Combine(webRootPath, menuItemFromDb.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImgPath))
                    {
                        System.IO.File.Delete(oldImgPath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    MenuItem.ImageUrl = @"\images\menuItems\" + fileName_new + extension;
                }

                _unitOfWork.MenuItem.Update(MenuItem);
                _unitOfWork.Save();
            }

            TempData["success"] = "FoodType created successfully";
            return RedirectToPage("Index");
        }
    }
}
