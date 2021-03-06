﻿using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using MyCMS.DataLayer;
using MyCMS.DomainClasses;
using MyCMS.ServiceLayer;
using MyCMS.ServiceLayer.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using StructureMap;
using StructureMap.Web;
using AutoMapper;
using StructureMap.Graph;

namespace MyCMS.Web.IocConfig
{
    public static class SmObjectFactory
    {
        private static readonly Lazy<Container> _containerBuilder =
            new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        private static Container defaultContainer()
        {
            var container = new Container(ioc =>
           {
               ioc.For<IIdentity>().Use(() => getIdentity());

               ioc.For<IUnitOfWork>()
                   .HybridHttpOrThreadLocalScoped()
                   .Use<ApplicationDbContext>();
               // Remove these 2 lines if you want to use a connection string named connectionString1, defined in the web.config file.
               //.Ctor<string>("connectionString")
               //.Is("Data Source=(local);Initial Catalog=TestDbIdentity;Integrated Security = true");


               ioc.For<ApplicationDbContext>().HybridHttpOrThreadLocalScoped()
                 .Use(context => (ApplicationDbContext)context.GetInstance<IUnitOfWork>());
               ioc.For<DbContext>().HybridHttpOrThreadLocalScoped()
                  .Use(context => (ApplicationDbContext)context.GetInstance<IUnitOfWork>());

               ioc.For<IUserStore<ApplicationUser, int>>()
                   .HybridHttpOrThreadLocalScoped()
                   .Use<CustomUserStore>();

               ioc.For<IRoleStore<CustomRole, int>>()
                   .HybridHttpOrThreadLocalScoped()
                   .Use<RoleStore<CustomRole, int, CustomUserRole>>();

               ioc.For<IAuthenticationManager>()
                     .Use(() => HttpContext.Current.GetOwinContext().Authentication);

               ioc.For<IApplicationSignInManager>()
                     .HybridHttpOrThreadLocalScoped()
                     .Use<ApplicationSignInManager>();

               ioc.For<IApplicationRoleManager>()
                     .HybridHttpOrThreadLocalScoped()
                     .Use<ApplicationRoleManager>();

               // map same interface to different concrete classes
               ioc.For<IIdentityMessageService>().Use<SmsService>();
               ioc.For<IIdentityMessageService>().Use<EmailService>();

               ioc.For<IApplicationUserManager>().HybridHttpOrThreadLocalScoped()
                  .Use<ApplicationUserManager>()
                  .Ctor<IIdentityMessageService>("smsService").Is<SmsService>()
                  .Ctor<IIdentityMessageService>("emailService").Is<EmailService>()
                  .Setter(userManager => userManager.SmsService).Is<SmsService>()
                  .Setter(userManager => userManager.EmailService).Is<EmailService>();

               ioc.For<ApplicationUserManager>().HybridHttpOrThreadLocalScoped()
                  .Use(context => (ApplicationUserManager)context.GetInstance<IApplicationUserManager>());

               ioc.For<ICustomRoleStore>()
                     .HybridHttpOrThreadLocalScoped()
                     .Use<CustomRoleStore>();

               ioc.For<ICustomUserStore>()
                     .HybridHttpOrThreadLocalScoped()
                     .Use<CustomUserStore>();

               //config.For<IDataProtectionProvider>().Use(()=> app.GetDataProtectionProvider()); // In Startup class

               ioc.For<IPostService>().Use<PostService>();
               ioc.For<ICommentService>().Use<CommentService>();
               ioc.For<ICategoryService>().Use<CategoryService>();

               ioc.AddRegistry<AutomapperRegistry>();
               ioc.Scan(scanner => scanner.WithDefaultConventions());
               ioc.Policies.SetAllProperties(y => y.OfType<HttpContextBase>());

               //ioc.Scan(scan =>
               //{
               //    scan.TheCallingAssembly();
               //    scan.WithDefaultConventions();
               //    scan.AddAllTypesOf<Profile>().NameBy(item => item.FullName);
               //});
           });
            configureAutoMapper(container);
            return container;
        }

        private static void configureAutoMapper(IContainer container)
        {
            var configuration = container.TryGetInstance<IConfiguration>();
            if (configuration == null) return;
            //saying AutoMapper how to resolve services
            configuration.ConstructServicesUsing(container.GetInstance);
            foreach (var profile in container.GetAllInstances<Profile>())
            {
                configuration.AddProfile(profile);
            }
        }

        private static IIdentity getIdentity()
        {
            if (HttpContext.Current != null && HttpContext.Current.User != null)
            {
                return HttpContext.Current.User.Identity;
            }

            return ClaimsPrincipal.Current != null ? ClaimsPrincipal.Current.Identity : null;
        }
    }
}