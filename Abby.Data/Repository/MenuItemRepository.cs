using Abby.Data.Repository.IRepository;
using Abby.Models;

namespace Abby.Data.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext _db;

        public MenuItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MenuItem menuItem)
        {
            var menuItemFromDb = _db.MenuItems?.FirstOrDefault(x => x.Id == menuItem.Id);

            if (menuItemFromDb != null)
            {
                menuItemFromDb.Name = menuItem.Name;
                menuItemFromDb.Description = menuItem.Description;
                menuItemFromDb.Price = menuItem.Price;
                menuItemFromDb.CategoryId = menuItem.CategoryId;
                menuItemFromDb.FoodTypeId = menuItem.FoodTypeId;

                if (menuItemFromDb.ImageUrl != null)
                {
                    menuItemFromDb.ImageUrl = menuItem.ImageUrl;
                }
            }
        }
    }
}
