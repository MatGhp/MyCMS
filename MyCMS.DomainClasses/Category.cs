using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace MyCMS.DomainClasses
{
    public class Category : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual ICollection<Post> Posts { set; get; }
    }
}
