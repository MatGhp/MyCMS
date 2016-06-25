using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.ViewModel
{
    public class CommentViewModel
    {
        public CommentViewModel()
        {
            AddedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorIP { get; set; }
        public string AuthorName { get; set; }
        public string AuthorUrl { get; set; }
        public string Body { get; set; }

        public int PostId { get; set; }
        public PostViewModel Post { get; set; }
    }
}
