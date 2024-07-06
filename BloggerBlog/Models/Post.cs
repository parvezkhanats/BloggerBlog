using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        
        public string ApplicationUserId { get; set; }
        public PostStatus StatusOfPost { get; set; }
        public bool PostVisibility { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; } = new HashSet<PostCategory>();
        public ApplicationUser Author { get; set; }
        public ICollection<PostTags> PostTags { get; set; } = new HashSet<PostTags>();


    }
    public enum PostStatus
    {
        Draft=0,
        Published=1,
        Scheduled=2
    }
}
