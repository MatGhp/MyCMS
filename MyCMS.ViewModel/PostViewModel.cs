﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.ViewModel
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            //Comments = new IEnumerable<CommentViewModel>();
                 
        }
        public int Id { set; get; }

        public string AddedBy { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }
        public string ExcerptText { get; set; }
        public string PostSlug { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }

        public DateTime PublishedDate { get; set; }
        public DateTime? EditedDate { get; set; }

        public int PostedByUserId { get; set; }
        //public ApplicationUser PostedByUser { get; set; }

        public int ViewNumber { get; set; }
        public string MetaDescription { get; set; }
        //public virtual ICollection<Tag> Tags { get; set; }
        public string Image { get; set; }

        
    }
}
