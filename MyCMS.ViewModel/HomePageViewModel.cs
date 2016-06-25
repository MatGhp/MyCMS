using System.Collections.Generic;
using MyCMS.DomainClasses;

namespace MyCMS.ViewModel
{
    public class HomePageViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}