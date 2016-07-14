using System;
using System.ComponentModel.DataAnnotations;

namespace YouBlog.Core.Models
{
    /// <summary>
    /// 主题模版
    /// </summary>
    public class Theme
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "主题名称")]
        public string Name { get; set; }

        [Display(Name = "路径名")]
        public string Directory { get; set; }

        [Display(Name = "样式")]
        public string Style { get; set; }

        [Display(Name = "用户")]
        public int UserID { get; set; }
        public User User { get; set; }

        [Display(Name = "修改时间")]
        public DateTime SetTime { get; set; }
    }
}
