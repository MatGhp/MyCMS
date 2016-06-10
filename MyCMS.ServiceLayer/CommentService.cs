using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCMS.DataLayer;
using MyCMS.DomainClasses;
using MyCMS.ServiceLayer.Contracts;

namespace MyCMS.ServiceLayer
{
    public class CommentService : ICommentService
    {
        private IUnitOfWork _uow;
        private IDbSet<Comment> _comments;

        public CommentService(IUnitOfWork uow)
        {
            _uow = uow;
            _comments = _uow.Set<Comment>();
        }
        public void AddNewComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public IList<Comment> GetAllComments()
        {
            return _comments.ToList();
        }
    }
}
