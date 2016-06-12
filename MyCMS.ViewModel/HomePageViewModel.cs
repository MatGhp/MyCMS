using System.Collections.Generic;
using MyCMS.DomainClasses;

namespace MyCMS.ViewModel
{
    public class HomePageViewModel
    {
        public IList<Post> Posts { get; set; }
    }
}