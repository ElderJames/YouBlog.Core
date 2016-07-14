using System.Security.Claims;
using System.Threading.Tasks;

namespace YouBlog.Core.Service
{
    public class UserService
    {
        public async Task Login(string account,string pass)
        {
            await Task.FromResult(0);
        }
    }
}
