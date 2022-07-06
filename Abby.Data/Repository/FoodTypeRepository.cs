using Abby.Data.Repository.IRepository;
using Abby.Models;

namespace Abby.Data.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public FoodTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(FoodType foodType)
        {
            var foodTypeFromDb = _db.FoodTypes?.FirstOrDefault(x => x.Id == foodType.Id);

            if (foodTypeFromDb != null)
            {
                foodTypeFromDb.Name = foodType.Name;
            }
        }
    }
}
