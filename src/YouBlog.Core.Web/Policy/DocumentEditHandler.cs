using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace YouBlog.Core.Web.Policy
{
    public class DocumentEditHandler : AuthorizationHandler<EditRequirement, Document>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, EditRequirement requirement, Document resource)
        {
            if (resource.Author == context.User.FindFirst(ClaimTypes.Name).Value)
            {
                context.Succeed(requirement);
            }
            await Task.FromResult(0);
        }
    }

    public class Document
    {
        public int Id { get; set; }
        public string Author { get; set; }
    }
}
