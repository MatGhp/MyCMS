using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCMS.DomainClasses;
using MyCMS.ViewModel;

namespace MyCMS.ServiceLayer.Contracts
{
    public interface ICommentService
    {
        void AddNewComment(CommentViewModel comment);
        IList<CommentViewModel> GetPostComments(int postId);
    }
}
