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
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _uow;
        private readonly IDbSet<Category> _categories;
        private IMappingEngine _mappingEngine;
        private IApplicationUserManager _userManager;
        public CategoryService(IUnitOfWork uow, IApplicationUserManager userManager, IMappingEngine mappingEngine)
        {
            _mappingEngine = mappingEngine;
            _userManager = userManager;
            _uow = uow;
            _categories = _uow.Set<Category>();


        }
        public CategoryViewModel Find(int Id)
        {
            return _mappingEngine.Map<CategoryViewModel>(_categories.Find(Id));
        }

        public IList<CategoryViewModel> GetAll()
        {
            return _mappingEngine.Map<IList<CategoryViewModel>>(_categories.ToList());
        }

        public IList<CategoryViewModel> GetUserPostsCategories(string username)
        {
            var cats = _categories.Where(category => category.Posts.Count(p => p.PostedByUser.UserName == username) > 0).ToList();
            return _mappingEngine.Map<IList<CategoryViewModel>>(cats);
        }


        public void Add(CategoryViewModel categoryViewModel)
        {
            var category = _mappingEngine.Map<Category>(categoryViewModel);
            _categories.Add(category);
            _uow.SaveAllChanges();
        }
    }
}
