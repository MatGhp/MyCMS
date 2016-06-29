using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using AutoMapper.QueryableExtensions;


using EntityFramework.Extensions;
using MyCMS.DataLayer;
using MyCMS.DomainClasses;
using MyCMS.ServiceLayer.Contracts;
using MyCMS.ViewModel;

namespace MyCMS.ServiceLayer
{
    public class CommentService : ICommentService
    {
        private IUnitOfWork _uow;
        private IDbSet<Comment> _comments;
        private IMappingEngine _mappingEngine;

        public CommentService(IUnitOfWork uow, IMappingEngine mappingEngine)
        {
            _uow = uow;
            _comments = _uow.Set<Comment>();
            _mappingEngine = mappingEngine;
        }
        public void AddNewComment(CommentViewModel commentVM)
        {
            var comment = _mappingEngine.Map<Comment>(commentVM);
            _comments.Add(comment);
            _uow.SaveAllChanges();
        }

        //public IList<CommentViewModel> GetAllComments()
        //{
        //    return _comments.ToList();
        //}

        public IList<CommentViewModel> GetPostComments(int postId)
        {
            var comments = _comments.Where(c => c.PostId == postId).AsNoTracking().ToList();
            return _mappingEngine.Map<IList<CommentViewModel>>(comments);
        }
    }
}
