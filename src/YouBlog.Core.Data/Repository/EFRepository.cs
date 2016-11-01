using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YouBlog.Core.Common.Exception;
using YouBlog.Core.Models;

namespace YouBlog.Core.Data
{
    /// <summary>
    /// EF仓储
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public class EFRepository<T> : IRepository<T> where T : BaseModel
    {
        private DbContext _baseDbContext;

        public int pageCount { get; set; }

        public IDbContext db
        {
            get { return _baseDbContext as IDbContext; }
            private set { _baseDbContext = value as DbContext; }
        }

        public EFRepository() { }

        public EFRepository(IDbContext db)
        {
            SetDbContext(db);
        }

        public void SetDbContext(IDbContext db)
        {
            _baseDbContext = db as DbContext;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否立即保存</param>
        /// <returns></returns>
        public T Add(T entity, bool isSave = true)
        {
            _baseDbContext.Set<T>().Add(entity);
            if (isSave) Save();
            return entity;
        }

        public async Task<T> AddAsync(T entity, bool isSave = true)
        {
            Add(entity, false);
            if (isSave) await SaveAsync();
            return entity;
        }

        /// <summary>
        /// 批量添加【立即执行】
        /// </summary>
        /// <param name="entities">数据列表</param>
        /// <returns>添加的记录数</returns>
        public int AddRange(IEnumerable<T> entities, bool isSave = true)
        {
            _baseDbContext.Set<T>().AddRange(entities);
            return isSave ? Save() : 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否立即保存</param>
        /// <returns></returns>
        public bool Update(T entity, bool isSave = true)
        {
            _baseDbContext.Set<T>().Attach(entity);
            _baseDbContext.Entry<T>(entity).State = EntityState.Modified;
            return isSave ? Save() > 0 : true;
        }

        public async Task<bool> UpdateAsync(T entity, bool isSave = true)
        {
            Update(entity, false);
            return isSave ? await SaveAsync() > 0 : true;
        }

        public int UpdateRange(IEnumerable<T> entities, bool isSave = true)
        {
            entities.ToList().ForEach(entity =>
            {
                _baseDbContext.Set<T>().Attach(entity);
                _baseDbContext.Entry<T>(entity).State = EntityState.Modified;
            });
            return isSave ? Save() : 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否立即保存</param>
        /// <returns></returns>
        public bool Delete(T entity, bool isSave = true)
        {
            _baseDbContext.Set<T>().Attach(entity);
            _baseDbContext.Entry<T>(entity).State = EntityState.Deleted;
            return isSave ? Save() > 0 : true;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities">数据列表</param>
        /// <param name="isSave">是否立即保存</param>
        /// <returns>删除的记录数</returns>
        public int DeleteRange(IEnumerable<T> entities, bool isSave = true)
        {
            _baseDbContext.Set<T>().RemoveRange(entities);
            return isSave ? Save() : 0;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>受影响的记录数</returns>
        public int Save()
        {
            try
            {
                return _baseDbContext.SaveChanges();
            }
            //catch (DbEntityValidationException dbEx)//验证错误
            //{
            //    var sb = new StringBuilder();
            //    dbEx.EntityValidationErrors.First().ValidationErrors.ToList().ForEach(i =>
            //    {
            //        sb.AppendFormat("字段：{0}，错误：{1}\n\r", i.PropertyName, i.ErrorMessage);
            //    });
            //    throw new BaseException(ExceptionLevel.Normal,(int)DataBaseExceptionCode.字段验证不通过, sb.ToString());
            //}
            //catch (OptimisticConcurrencyException ex)//并发错误
            //{
            //    throw new BaseException(ExceptionLevel.Normal, (int)DataBaseExceptionCode.并发错误, ex.Message);
            // }
            catch (Exception ex)//其他错误
            {
                throw new BaseException(ExceptionLevel.Normal, (int)DataBaseExceptionCode.数据操作执行时出错, ex.Message);
            }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await _baseDbContext.SaveChangesAsync();
            }
            //catch (DbEntityValidationException dbEx)//验证错误
            //{
            //    var sb = new StringBuilder();
            //    dbEx.EntityValidationErrors.First().ValidationErrors.ToList().ForEach(i =>
            //    {
            //        sb.AppendFormat("字段：{0}，错误：{1}\n\r", i.PropertyName, i.ErrorMessage);
            //    });
            //    throw new BaseException(ExceptionLevel.Normal, (int)DataBaseExceptionCode.字段验证不通过, sb.ToString());
            //}
            //catch (OptimisticConcurrencyException ex)//并发错误
            //{
            //    throw new BaseException(ExceptionLevel.Normal, (int)DataBaseExceptionCode.并发错误, ex.Message);
            //}
            catch (Exception ex)//其他错误
            {
                throw new BaseException(ExceptionLevel.Normal, (int)DataBaseExceptionCode.数据操作执行时出错, ex.Message);
            }
        }

        /// <summary>
        /// 是否有满足条件的记录
        /// </summary>
        /// <param name="anyLamdba">条件表达式</param>
        /// <returns></returns>
        public bool Exist(Expression<Func<T, bool>> anyLamdba)
        {
            return _baseDbContext.Set<T>().Any(anyLamdba);
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> anyLamdba)
        {
            return await _baseDbContext.Set<T>().AnyAsync(anyLamdba);
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="countLamdba">查询表达式</param>
        /// <returns>记录数</returns>
        public int Count(Expression<Func<T, bool>> countLamdba)
        {
            return _baseDbContext.Set<T>().Count(countLamdba);
        }


        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="ID">实体ID</param>
        /// <returns></returns>
        public T Find(int ID)
        {
            return _baseDbContext.Set<T>().FirstOrDefault(x => x.Id == ID);
        }

        public async Task<T> FindAsync(int ID)
        {
            return await _baseDbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == ID);
        }

        /// <summary>
        /// 查找实体 
        /// </summary>
        /// <param name="findLambda">Lambda表达式</param>
        /// <returns></returns>
        public T Find(Expression<Func<T, bool>> findLambda)
        {
            return _baseDbContext.Set<T>().FirstOrDefault(findLambda);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> findLambda)
        {
            return await _baseDbContext.Set<T>().FirstOrDefaultAsync(findLambda);
        }

        /// <summary>
        /// 查找所有列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> All()
        {
            return _baseDbContext.Set<T>();
        }

        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <param name="number">返回的记录数【0-返回所有】</param>
        /// <param name="whereLandba">查询条件</param>
        /// <param name="orderType">排序方式</param>
        /// <param name="orderLandba">排序条件</param>
        /// <returns></returns>
        public IQueryable<T> FindList<TKey>(int number, Expression<Func<T, bool>> whereLandba, OrderType orderType, Expression<Func<T, TKey>> orderLandba)
        {
            IQueryable<T> _tIQueryable = _baseDbContext.Set<T>().Where(whereLandba);
            switch (orderType)
            {
                case OrderType.Asc:
                    _tIQueryable = _tIQueryable.OrderBy(orderLandba);
                    break;
                case OrderType.Desc:
                    _tIQueryable = _tIQueryable.OrderByDescending(orderLandba);
                    break;
            }
            if (number > 0) _tIQueryable = _tIQueryable.Take(number);
            return _tIQueryable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey">排序字段类型</typeparam>
        /// <param name="pageIndex">页码【从1开始】</param>
        /// <param name="pageNumber">每页记录数</param>
        /// <param name="totalNumber">总记录数</param>
        /// <param name="whereLandba">查询表达式</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="orderLandba">排序表达式</param>
        /// <returns></returns>
        public IQueryable<T> FindPageList<TKey>(int pageIndex, int pageNumber, Expression<Func<T, bool>> whereLandba, OrderType orderType, Expression<Func<T, TKey>> orderLandba)
        {
            IQueryable<T> _tIQueryable = _baseDbContext.Set<T>().Where(whereLandba);
            pageCount = _tIQueryable.Count();
            switch (orderType)
            {
                case OrderType.Asc:
                    _tIQueryable = _tIQueryable.OrderBy(orderLandba);
                    break;
                case OrderType.Desc:
                    _tIQueryable = _tIQueryable.OrderByDescending(orderLandba);
                    break;
                default: _tIQueryable = _tIQueryable.OrderBy(p => true); break;
            }
            _tIQueryable = _tIQueryable.Skip((pageIndex - 1) * pageNumber).Take(pageNumber);
            return _tIQueryable;
        }
    }

    public class EFRepository : IRepository
    {
        private DbContext _baseDbContext;
        public IDbContext db
        {
            get { return _baseDbContext as IDbContext; }
            private set { _baseDbContext = value as DbContext; }
        }
    }
}
