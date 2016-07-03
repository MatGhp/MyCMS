using System;

namespace MyCMS.DomainClasses
{
    public class Comment : BaseEntity
    {
        public virtual DateTime AddedDate { get; set; }
        public virtual string AuthorEmail { get; set; }
        public virtual string AuthorIp { get; set; }
        public virtual string AuthorName { get; set; }
        public virtual string AuthorUrl { get; set; }
        public virtual string Body { get; set; }

        public virtual int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}