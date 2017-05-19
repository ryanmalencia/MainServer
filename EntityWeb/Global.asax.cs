using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EntityWeb.DAL;
using System.Data.Entity;
using EntityWeb.StatusClasses;

namespace EntityWeb
{
    public class MvcApplication : HttpApplication
    {
        public void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DbContext db = new DataContext();
            Database.SetInitializer(new DataInitializer());
            DataContext c = new DataContext();
            c.Database.Initialize(true);
            GetStatus stat = new GetStatus();
            stat.Start();
        }
    }
}
