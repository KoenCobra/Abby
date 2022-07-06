using Abby.Data.Repository.IRepository;
using Abby.Models;

namespace Abby.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var categoryFromDb = _db.Categories?.FirstOrDefault(x => x.Id == category.Id);

            if (categoryFromDb != null)
            {
                categoryFromDb.Name = category.Name;
                categoryFromDb.DisplayOrder = category.DisplayOrder;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
