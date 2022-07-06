using System.Linq.Expressions;

namespace Abby.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null);
        IEnumerable<T> GetAll();
    }
}
