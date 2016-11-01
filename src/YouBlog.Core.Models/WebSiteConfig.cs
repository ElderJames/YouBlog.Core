namespace YouBlog.Core.Models
{
    public class WebSiteConfig
    {
        public int id { get; set; }
        public int UserID { get; set; }
        public Theme DefaultTheme { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
