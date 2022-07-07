using Abby.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AbbyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;


        public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var menuItemList = _unitOfWork.MenuItem.GetAll();
            return Json(new { data = menuItemList });
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            var menuItemFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(x => x.Id == id);

            var oldImgPath = Path.Combine(_hostEnvironment.WebRootPath, menuItemFromDb.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImgPath))
            {
                System.IO.File.Delete(oldImgPath);
            }
            _unitOfWork.MenuItem.Remove(menuItemFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
