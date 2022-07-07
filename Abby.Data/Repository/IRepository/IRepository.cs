using System.Linq.Expressions;

namespace Abby.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string ? includeProperties = null);
    }
}
