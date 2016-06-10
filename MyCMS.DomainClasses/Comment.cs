using System;

namespace MyCMS.DomainClasses
{
    public class Comment : BaseEntity
    {
        public DateTime AddedDate { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorIP { get; set; }
        public string AuthorName { get; set; }
        public string AuthorUrl { get; set; }
        public string Body { get; set; }

        public virtual int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}