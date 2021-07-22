using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexedDb.Data
{

    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? Removed { get; set; }

    }
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
    public class Blog : BaseEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
    public class Post : BaseEntity
    {
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
