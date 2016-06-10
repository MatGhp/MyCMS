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
    public class PostService : IPostService
    {
        private IUnitOfWork _uow;
        private readonly IDbSet<Post> _posts;

        public PostService(IUnitOfWork uow)
        {
            _uow = uow;
            _posts = _uow.Set<Post>();
        }
        public void AddNewPost(Post post)
        {
            _posts.Add(post);
        }

        public IList<Post> GetAllPosts()
        {
            return _posts.ToList();
        }
    }
}
