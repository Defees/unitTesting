using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;
using unittesting.Entities;
using unittesting.Interfaces.Repos;

namespace unittesting.Repos
{
    public class OrderDapperRepository : IGenericRepository<Order>, IOrderRepository
    {
        private readonly string _connectionString;
        public OrderDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Find(Expression<Func<Order, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Order>("SELECT * FROM Orders").ToList();
            }
        }

        public IEnumerable<Order> GetAllInclude<TEntity>(Expression<Func<Order, TEntity>> expression)
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Order entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }
    }
}
