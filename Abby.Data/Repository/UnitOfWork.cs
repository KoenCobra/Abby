using Abby.Data.Repository.IRepository;

namespace Abby.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; }
        public IFoodTypeRepository FoodType{ get; }
        public IMenuItemRepository MenuItem{ get; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            FoodType = new FoodTypeRepository(_db);
            MenuItem = new MenuItemRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
