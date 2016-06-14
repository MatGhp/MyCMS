using System;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MyCMS.DataLayer;
using MyCMS.DataLayer.Migrations;
using MyCMS.Web.IocConfig;
using StructureMap.Web.Pipeline;
using StructureMap;

namespace MyCMS.Web.IocConfig
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                throw new InvalidOperationException(string.Format("Page not found: {0}", requestContext.HttpContext.Request.RawUrl));
            return SmObjectFactory.Container.GetInstance(controllerType) as Controller;
        }
    }
}