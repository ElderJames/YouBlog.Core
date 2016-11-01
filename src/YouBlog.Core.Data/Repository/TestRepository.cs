using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YouBlog.Core.Data;

namespace Mind.OrderPrice.DataSource.Repository
{
    public class TestRepository<T> : IRepository<T> where T : class
    {

        public IDbContext db
        {
            get;set;
        }

        public int pageCount
        {
            get;set;
        }

        public T Add(T entity, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public Task<T> AddAsync(T entity, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public int AddRange(IEnumerable<T> entities, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> All()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<T, bool>> countLamdba = null)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public int DeleteRange(IEnumerable<T> entities, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(Expression<Func<T, bool>> anyLamdba)
        {
            throw new NotImplementedException();
        }

        public T Find(Expression<Func<T, bool>> findLambda)
        {
            throw new NotImplementedException();
        }

        public T Find(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> findLambda)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindList<TKey>(int number, Expression<Func<T, bool>> whereLandba, OrderType orderType, Expression<Func<T, TKey>> orderLandba)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindPageList<TKey>(int pageIndex, int pageNumber, Expression<Func<T, bool>> whereLandba, OrderType orderType, Expression<Func<T, TKey>> orderLandba)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void SetDbContext(IDbContext db)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T entity, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public int UpdateRange(IEnumerable<T> entities, bool isSave)
        {
            throw new NotImplementedException();
        }
    }
}
