using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YouBlog.Core.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        public ItemState State { get; set; }

        public DateTime CreateTime { get; set; }

        public string Remark { get; set; }
    }
}
