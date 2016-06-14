using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCMS.DomainClasses;
using MyCMS.ViewModel;

namespace MyCMS.ServiceLayer.Contracts
{
    public interface IPostService
    {
        //Task<PostViewModel> Create(PostViewModel viewModel);
        void Create(PostViewModel viewModel);
        PostViewModel FindPost(int id);
        IEnumerable<PostViewModel> GetAllPosts();
    }
}
