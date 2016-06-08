using System.Collections.Generic;

namespace MyCMS.DomainClasses
{
    public class Tag : BaseEntity
    {
        public string Description { get; set; }
        public virtual ICollection<Post> Posts { set; get; }
    }
}