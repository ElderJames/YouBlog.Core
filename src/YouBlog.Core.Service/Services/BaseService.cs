using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YouBlog.Core.Data;

namespace YouBlog.Core.Service
{
    /// <summary>
    /// <para>业务基类，提供基本的业务操作，特殊操作可派生子类扩展</para>
    /// <para>子类命名约定：数据模型类名+Service</para>
    /// <para>子类继承此类时需传入对应的数据模型类作为类型参数</para>
    /// </summary>
    /// <typeparam name="T">必须为数据模型</typeparam>
    public class BaseService<T>:IService<T> where T:class 
    {
        public int pageCount { get; set; }

        public IRepository<T> _repo { get; private set; }

        /// <summary>
        /// 设置数据仓储
        /// </summary>
        /// <param name="repo"></param>
        public void SetRespository(IRepository<T> repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        public T Add(T entity, bool isSave = true)
        {
            return _repo.Add(entity, isSave);
        }

        public async Task<T> AddAsync(T entity, bool isSave = true)
        {
            return await _repo.AddAsync(entity, isSave);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">数据列表</param>
        /// <param name="isSave">是否立即保存</param>
        /// <returns></returns>
        public int AddRange(IEnumerable<T> entities, bool isSave = true)
        {
            return _repo.AddRange(entities, isSave);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否立即保存</param>
        /// <returns></returns>
        public bool Update(T entity, bool isSave = true)
        {
            return _repo.Update(entity, isSave);
        }

        public async Task<bool> UpdateAsync(T entity, bool isSave = true)
        {
            return await _repo.UpdateAsync(entity, isSave);
        }

        public int UpdateRange(IEnumerable<T> entities, bool isSave = true)
        {
            return _repo.UpdateRange(entities, isSave);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否立即保存</param>
        /// <returns></returns>
        public bool Delete(T entity, bool isSave = true)
        {
            return _repo.Delete(entity, isSave);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities">数据列表</param>
        /// <param name="isSave">是否立即保存</param>
        /// <returns>删除的记录数</returns>
        public int DeleteRange(IEnumerable<T> entities, bool isSave = true)
        {
            return _repo.DeleteRange(entities, isSave);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>受影响的记录数</returns>
        public int Save()
        {
            return _repo.Save();
        }

        public async Task<int> SaveAsync()
        {
            return await _repo.SaveAsync();
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="countLamdba">查询表达式</param>
        /// <returns>记录数</returns>
        public int Count(Expression<Func<T, bool>> countLamdba = null)
        {
            return _repo.Count(countLamdba);
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return _repo.Exist(anyLambda);
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> anyLambda)
        {
            return await _repo.ExistAsync(anyLambda);
        }
        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="ID">实体ID</param>
        /// <returns></returns>
        public T Find(int ID)
        {
            return _repo.Find(ID);
        }

        public async Task<T> FindAsync(int ID)
        {
            return await _repo.FindAsync(ID);
        }
        /// <summary>
        /// 查找实体 
        /// </summary>
        /// <param name="findLambda">Lambda表达式</param>
        /// <returns></returns>
        public T Find(Expression<Func<T, bool>> findLambda)
        {
            return _repo.Find(findLambda);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> findLambda)
        {
            return await _repo.FindAsync(findLambda);
        }

        /// <summary>
        /// 查找所有列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _repo.All().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> whereLandba)
        {
            return await _repo.All().Where(whereLandba).ToListAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> whereLandba)
        {
            return _repo.All().Where(whereLandba);
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
            return _repo.FindList(number, whereLandba, orderType, orderLandba);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TKey">排序字段类型</typeparam>
        /// <param name="pageIndex">页码【从1开始】</param>
        /// <param name="pageNumber">每页记录数</param>
        /// <param name="totalNumber">总记录数</param>
        /// <param name="whereLandba">查询表达式</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="orderLandba">排序表达式</param>
        /// <returns></returns>
        public IQueryable<T> FindPageList<TKey>(int pageIndex, int pageNumber, out int totalNumber, Expression<Func<T, bool>> whereLandba, OrderType orderType, Expression<Func<T, TKey>> orderLandba)
        {
            var data = _repo.FindPageList(pageIndex, pageNumber, whereLandba, orderType, orderLandba);
            totalNumber = _repo.pageCount;
            return data;
        }
    }
}
