using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCMS.ViewModel;
namespace MyCMS.ServiceLayer.Contracts
{
    public interface ICategoryService
    {
        IList<CategoryViewModel> GetAll();
        IList<CategoryViewModel> GetUserPostsCategories(string username);
        CategoryViewModel Find(int Id);
        void Add(CategoryViewModel categoryViewModel);
    }
}
