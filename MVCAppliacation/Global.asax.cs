using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCAppliacation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //retrouver la derniere erreur
            var exception = Server.GetLastError();
            //Supp. les erreurs serveur
            Server.ClearError();

            //Solution 1
            //appel de l'action en passant le message d'erreur en param
            var urlWebSite = @"http://localhost:60274";
            Response.Redirect($"{urlWebSite}/Home/CustomErrors?message={exception.Message}");

            //Solution 2
            //var routeData = new RouteData();
            //routeData.Values["controller"] = "Home";
            //routeData.Values["action"] = "CustomErrors";
            //routeData.Values["message"]=message
            //IController homeController = new HomeController();
            //var wrapper = new HttpContextWrapper(Context);
            //var reqContext = new RequestContext(wrapper, routeData);
            //homeController.Execute(reqContext);
        }
    }
}
