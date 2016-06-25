using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace MyCMS.ViewModel
{
    public class AddPostViewModel
    {

        public AddPostViewModel()
        {
            PublishedDate = DateTime.Now;
            CategoryList = new List<CategoryViewModel>();
        }


        public int Id { get; set; }


        [DisplayName("Post")]
        [Required(ErrorMessage = "Content is required")]
        [AllowHtml]
        public string Body { get; set; }

        [DisplayName("Excert Text")]
        [AllowHtml]
        public string ExcerptText { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [ScaffoldColumn(false)]
        public int PostedByUserId { get; set; }
        [DisplayName("Create new post By")]

        public string AddedBy { get; set; }

        //public string PostedNyUserName { set; get; }

        //[ScaffoldColumn(false)]
        public DateTime PublishedDate { get; private set; }
        public string Image { get; set; }


        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> CategoryList { get; set; }
    }
}
