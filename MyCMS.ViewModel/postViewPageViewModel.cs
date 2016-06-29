using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.ViewModel
{
    public class postViewPageViewModel
    {
        public PostViewModel Post { get; set; }
        public IList<CommentViewModel> Comments { get; set; }
        public CommentViewModel NewComment { set; get; }
    }
}
