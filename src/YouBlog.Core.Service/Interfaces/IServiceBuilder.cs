using YouBlog.Core.Data;

namespace YouBlog.Core.Service
{
    public interface IServiceBuilder 
    {
         IService<T> GetService<T>(IRepository repo) where T:class;
    }
}
