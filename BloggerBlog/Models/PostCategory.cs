using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerBlog.Models
{
    public class PostCategory
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public Post Post { get; set; }
        public Category Category { get; set; }
    }
}
