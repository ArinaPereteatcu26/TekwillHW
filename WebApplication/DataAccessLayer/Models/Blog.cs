using System.Collections.Generic;


namespace DataAccessLayer.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public string Test { get; set; }
        public ICollection<Post> Posts { get; }
    }
}