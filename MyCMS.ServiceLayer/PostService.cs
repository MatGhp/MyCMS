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
        public void Create(PostViewModel viewModel)
        {
            
            var post = _mappingEngine.Map<Post>(viewModel);
            _posts.Add(post);
             //_uow.SaveAllChanges();
           // return  GetPostViewModel(post.Id);
        }

        public PostViewModel FindPost(int id)
        {
            var post =_posts.FirstOrDefault(i => i.Id == id);
            return _mappingEngine.Map<PostViewModel>(post);
        }

        public IEnumerable<PostViewModel> GetAllPosts()
        {
            return _mappingEngine.Map<IEnumerable<PostViewModel>>(_posts.ToList());
        }


    }
}
