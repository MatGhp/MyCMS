using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace MyCMS.DomainClasses
{
    public class Post : BaseEntity
    {
        public Post()
        {
            PublishedDate = DateTime.Now;
        }

        public string AddedBy { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
        public virtual string ExcerptText { get; set; }
        public virtual string PostSlug { get; set; }
        public virtual string Body { get; set; }
        public virtual string Title { get; set; }

        public virtual DateTime PublishedDate { get; set; }
        public virtual DateTime? EditedDate { get; set; }

        public virtual int PostedByUserId { get; set; }
        public virtual ApplicationUser PostedByUser { get; set; }

        public virtual int ViewNumber { get; set; }
        public virtual string MetaDescription { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual string Image { get; set; }

        //public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
