using System.Linq.Expressions;

namespace unittesting.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        public void Add(T entity);
        public void AddRange(IEnumerable<T> entities);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entities);
    }
}
