using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCMS.DomainClasses;

namespace MyCMS.ViewModel
{
    public class CommentViewModel
    {
        //public CommentViewModel()
        //{
        //    AddedDate = DateTime.Now;
        //}
        public virtual int Id { get; set; }
        public virtual DateTime AddedDate { get; set; }
        public virtual string AuthorEmail { get; set; }
        public virtual string AuthorIp { get; set; }
        public virtual string AuthorName { get; set; }
        public virtual string AuthorUrl { get; set; }
        public virtual string Body { get; set; }

        public virtual int PostId { get; set; }
    }
}
