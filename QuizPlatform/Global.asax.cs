using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Castle.Windsor;

namespace QuizPlatform
{
  public class MvcApplication : HttpApplication
  {
    private static IWindsorContainer _container;    

    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
     
      _container = new WindsorContainer();
      WindsorConfig.BootstrapContainer(_container);
      MapperConfig.BootstrapMapper();
    }    

    protected void Application_End()
    {
      _container.Dispose();
    }
  }
}
