using Abby.Data.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<MenuItem>? MenuItems { get; set; }
        public IEnumerable<Category>? Categories { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            MenuItems = _unitOfWork.MenuItem.GetAll(includeProperties:"Category,Type");
            Categories = _unitOfWork.Category.GetAll(orderBy:x=>x.OrderBy(c=>c.DisplayOrder));
        }
    }
}
