using System.Collections.Generic;

namespace YouBlog.Core.Models
{
    public enum AttachmentUsage
    {
        Aritcle,Head,Logo,Icon
    }

    public static class UsageString
    {
        public static Dictionary<AttachmentUsage, string> UsageList
        {
            get
            {
                return new Dictionary<AttachmentUsage, string>() { 
                {AttachmentUsage.Aritcle,"文章"},
                {AttachmentUsage.Head,"头像"},
                {AttachmentUsage.Icon,"图标"},
                {AttachmentUsage.Logo,"LOGO"}
                };
            }
        }
    }
}
