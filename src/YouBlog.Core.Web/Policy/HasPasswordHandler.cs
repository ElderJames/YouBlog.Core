using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace YouBlog.Core.Web.Policy
{
    public class HasPasswordHandler : AuthorizationHandler<LoginRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, LoginRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "UsernameAndPassword" && c.Issuer == "http://youblog.com"))
                return;
            context.Succeed(requirement);

            await Task.FromResult(0);
        }
    }
}
