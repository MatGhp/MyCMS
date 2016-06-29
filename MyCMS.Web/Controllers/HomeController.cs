﻿using System.Web.Mvc;
using MyCMS.DataLayer;
//using MyCMS.DomainClasses;
using MyCMS.ServiceLayer.Contracts;
using MyCMS.ViewModel;
using System;
using MyCMS.Common.HtmlCleaner;
using MyCMS.Common.Controller;
using MyCMS.Common.Filters;

namespace MyCMS.Web.Controllers
{
    public partial class HomeController : BaseController
    {
        private readonly IApplicationUserManager _userManager;
        private IPostService _postService;
        private ICommentService _commentService;
        private ICategoryService _categoryService;
        private IUnitOfWork _uow;
        public HomeController(IApplicationUserManager userManager, IPostService postService,
            ICommentService commentService, ICategoryService categoryService, IUnitOfWork uow)
        {
            _userManager = userManager;
            _postService = postService;
            _commentService = commentService;
            _categoryService = categoryService;
            _uow = uow;
        }

        [AllowAnonymous]
        public virtual ActionResult Index()
        {
            var model = new HomePageViewModel
            {
                Posts = _postService.GetAllPosts(),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }



        [HttpGet]
        public virtual ActionResult Create()
        {
            var viewModel = new AddPostViewModel
            {
                AddedBy = _userManager.GetCurrentUser().UserName,
                CategoryList = _categoryService.GetAll()
            };
            return View(nameof(Create), viewModel);
        }

        [HttpPost]
        //[AjaxOnly]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(AddPostViewModel postVM)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create), postVM);
            }
            postVM.Body = postVM.Body.ToSafeHtml();
            postVM.ExcerptText = postVM.ExcerptText.ToSafeHtml();
            postVM.PostedByUserId = _userManager.GetCurrentUserId();
            _postService.Add(postVM);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public virtual ActionResult CreateCategory()
        {

            return View(new CategoryViewModel());
        }

        [HttpPost]
        public virtual ActionResult CreateCategory(CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(CreateCategory), category);
            }
            _categoryService.Add(category);
            return RedirectToAction(nameof(Index));
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

        [Authorize]
        public virtual ActionResult UserPostList()
        {
            string userName = _userManager.GetCurrentUser().UserName;
            var model = new HomePageViewModel
            {
                Posts = _postService.GetUserPosts(userName),
                Categories = _categoryService.GetUserPostsCategories(userName)
            };
            return View(nameof(Index), model);
        }
        [AllowAnonymous]
        public virtual ActionResult PostView(int postId)
        {
            var postViewPageViewModel = new postViewPageViewModel
            {
                Post = _postService.Find(postId),
                Comments = _commentService.GetPostComments(postId)
            };
            return View(nameof(PostView), postViewPageViewModel);
        }
    }

   
}
