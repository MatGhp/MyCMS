using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyCMS.ViewModel
{
    public class EditPostViewModel
    {
        public EditPostViewModel()
        {
            EditedDate = DateTime.Now;
        }

        public int Id { get; set; }


        [DisplayName("Post")]
        [Required(ErrorMessage = "Content is required")]
        [AllowHtml]
        public string Body { get; set; }

        [DisplayName("Summery")]
        [AllowHtml]
        public string ExcerptText { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }


        public int PostedByUserId { get; set; }

        [Bindable(false)]
        public DateTime? EditedDate { get; set; }
        public string Image { get; set; }
    }
}
