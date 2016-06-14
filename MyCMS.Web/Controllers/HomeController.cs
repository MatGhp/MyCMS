using System.Web.Mvc;
using MyCMS.DataLayer;
//using MyCMS.DomainClasses;
using MyCMS.ServiceLayer.Contracts;
using MyCMS.ViewModel;
using System;
namespace MyCMS.Web.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IApplicationUserManager _userManager;
        private IPostService _postService;
        private ICommentService _commentService;
        private IUnitOfWork _uow;
        public HomeController(IApplicationUserManager userManager, IPostService postService,
            ICommentService commentService, IUnitOfWork uow)
        {
            _userManager = userManager;
            _postService = postService;
            _commentService = commentService;
            _uow = uow;

            

        }
        public virtual ActionResult Index()
        {
            var model = new HomePageViewModel
            {
                Posts = _postService.GetAllPosts()
            };
            return View(model);
        }

        [Authorize]
        public virtual ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public virtual ActionResult GetData()
        {
            var applicationUser = _userManager.GetCurrentUser();
            return Content(applicationUser.UserName);
        }
    }
}
