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
    public class PostService : IPostService
    {
        private IUnitOfWork _uow;
        private readonly IDbSet<Post> _posts;
        private IMappingEngine _mappingEngine;
        private IApplicationUserManager _userManager;
        public PostService(IUnitOfWork uow, IApplicationUserManager userManager, IMappingEngine mappingEngine)
        {
            _mappingEngine = mappingEngine;
            _userManager = userManager;
            _uow = uow;
            _posts = _uow.Set<Post>();


        }
        public PostViewModel Add(AddPostViewModel viewModel)
        {

            var post = _mappingEngine.Map<Post>(viewModel);
            post.ViewNumber = 0;
            _posts.Add(post);
            _uow.SaveAllChanges();

            return Find(post.Id);
        }

        public PostViewModel Find(int id)
        {
            var post = _posts.FirstOrDefault(i => i.Id == id);
            return _mappingEngine.Map<PostViewModel>(post);
        }

        public IEnumerable<PostViewModel> GetAllPosts()
        {
            return _mappingEngine.Map<IEnumerable<PostViewModel>>(_posts.OrderByDescending(p => p.PublishedDate).ToList());
        }

        public void RemovePostById(int id)
        {
            _posts.Remove(_posts.Find(id));
            _uow.SaveAllChanges();
        }

        public EditPostViewModel GetPostForEdit(int id)
        {
            var p = _posts.FirstOrDefault(post => post.Id == id);
            return _mappingEngine.Map<EditPostViewModel>(p);
        }

        public IList<PostViewModel> GetPostList(int page, int count)
        {
            var posts = _posts.AsNoTracking().OrderByDescending(post => post.PublishedDate).Skip(page * count).Take(count).ToList();
            return _mappingEngine.Map<IList<PostViewModel>>(posts);
        }

        public int Count
        {
            get { return _posts.Count(); }
        }

        public void IncrementVisitedNumber(int id)
        {
            _posts.Find(id).ViewNumber += 1;
        }

       

        public IList<PostViewModel> GetUserPosts(string userName, int page, int count)
        {
            var posts = _posts.AsNoTracking().Where(post => post.PostedByUser.UserName == userName).OrderByDescending(post => post.PublishedDate).Skip(page * count).Take(count).ToList();
            return _mappingEngine.Map<IList<PostViewModel>>(posts);
        }

        public int GetUserPostsCount(string username)
        {
            return _posts.Count(post => post.PostedByUser.UserName == username);
        }

        public IList<PostViewModel> GetUserPosts(string username)
        {
            var userPosts = _posts.Where(post => post.PostedByUser.UserName == username).ToList();
            if (userPosts.Count() > 0)
                userPosts = userPosts.OrderByDescending(p => p.PublishedDate).ToList();
            return null;
        }

        //public Post GetPostDataById(int id)
        //{
        //    return _posts.Where(x => x.Id == id).Include(x => x.Comments)
        //        .Include(x => x.ApplicationUser).FirstOrDefault();
        //}

        public int GetPostsCount()
        {
            return _posts.Count();
        }

    }
}
