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

        PostViewModel Add(AddPostViewModel viewModel);

        PostViewModel FindPost(int id);

        IEnumerable<PostViewModel> GetAllPosts();

        void RemovePostById(int id);

        EditPostViewModel GetPostForEdit(int id);

        IList<PostViewModel> GetPostList(int page, int count);

        int Count { get; }

        void IncrementVisitedNumber(int id);

        Post Find(int id);

        IList<PostViewModel> GetUserPosts(string userName, int page, int count);

        int GetUserPostsCount(string userName);

        Post GetPostById(int id);
    }
}
