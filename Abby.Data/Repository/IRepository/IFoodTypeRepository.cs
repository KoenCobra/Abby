using Abby.Models;

namespace Abby.Data.Repository.IRepository
{
    public interface IFoodTypeRepository : IRepository<FoodType>
    {
        void Update(FoodType foodType);

    }
}
