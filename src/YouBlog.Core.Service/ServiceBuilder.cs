using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using YouBlog.Core.Data;

namespace YouBlog.Core.Service
{
    public class ServiceBuilder
    {
        //获取当前程序集中的所有类的类型
        static Type[] ts = Assembly.GetExecutingAssembly().GetTypes();

        /// <summary>
        /// 动态映射创建实现了IService<T>接口的实例
        /// <para>如果字符集中已有继承了BaseService<T>的类，则返回该类的实例,
        /// 否则返回BaseService<T> 的实例</para>
        /// </summary>
        /// <typeparam name="T">数据模型</typeparam>
        /// <param name="repo">仓储实例</param>
        /// <returns>实现IService<T>接口的实例对象</returns>
        public static IService<T> GetService<T>(IRepository repo) where T : class
        {
            //获取传入类型的 System.Type 对象
            Type TType = typeof(T);
            //取当前线程内存块中可能已存储的Service对象
           
            
            var _service = CallContext.GetData($"BaseService<{TType.Name}>") as IService<T>;

            if (_service != null) return _service;
            //查询扩展业务类是否存在于程序集中
            Type _class = ts.FirstOrDefault(o => o.Name.Equals(TType.Name + "Service"));
            try
            {
                if (_class != null)
                {
                    _service = Activator.CreateInstance(_class) as IService<T>;
                }
                else
                {
                    _service = Activator.CreateInstance(typeof(BaseService<T>)) as IService<T>;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"无法实例化{typeof(BaseService<T>).Name}:{ex.Message}");
            }

            //获取泛型类定义的type类型
            var _repoType = repo.GetType().GetGenericTypeDefinition();
            //传入泛型类型参数
            _repoType = _repoType.MakeGenericType(typeof(T));
            //实例化仓储类
            var _repo = Activator.CreateInstance(_repoType) as IRepository<T>;
            //注入DbContext
            _repo.SetDbContext(repo.db);
            //注入仓储类
            _service.SetRespository(_repo);

            //将对象保存到当前线程的内存块中
            CallContext.SetData($"BaseService<{TType.Name}>", _service);
            return _service;
        }
    
    }
}
