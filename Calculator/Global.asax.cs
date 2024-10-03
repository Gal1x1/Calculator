using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Calculator
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents(); // Register Unity Dependency Injection
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes); // Ensure route registration is here
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
