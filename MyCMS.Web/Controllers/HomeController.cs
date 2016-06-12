using System.Web.Mvc;
using MyCMS.ServiceLayer.Contracts;
using MyCMS.ViewModel;
namespace MyCMS.Web.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IApplicationUserManager _userManager;
        private IPostService _postService;
        private ICommentService _commentService;

        public HomeController(IApplicationUserManager userManager, IPostService postService, ICommentService commentService)
        {
            _userManager = userManager;
            _postService = postService;
            _commentService = commentService;
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
