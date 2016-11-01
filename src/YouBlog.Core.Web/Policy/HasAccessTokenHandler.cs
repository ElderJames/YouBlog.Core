using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;

namespace YouBlog.Core.Web.Policy
{
    public class HasAccessTokenHandler : AuthorizationHandler<LoginRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, LoginRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "AccessToken" && c.Issuer == "http://youblog.com"))
                context.Fail();

            var toeknExpiryIn = Convert.ToDateTime(context.User.FindFirst(c => c.Type == "AccessToken" && c.Issuer == "http://youblog.com").Value);

            if (toeknExpiryIn > DateTime.Now)
            {
                context.Succeed(requirement);
            }

            await Task.FromResult(0);
        }
    }
}
