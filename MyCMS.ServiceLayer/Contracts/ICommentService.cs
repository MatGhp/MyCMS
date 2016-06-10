using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCMS.DomainClasses;
namespace MyCMS.ServiceLayer.Contracts
{
    public interface ICommentService
    {
        void AddNewComment(Comment comment);
        IList<Comment> GetAllComments();
    }

}
