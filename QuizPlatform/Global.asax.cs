using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using QuizPlatform.Factories;
using QuizPlatform.Installers;

namespace QuizPlatform
{
  public class MvcApplication : HttpApplication
  {
    private static IWindsorContainer _container;

    private static void BootstrapWindsorContainer()
    {
      _container = new WindsorContainer()
        .Install(FromAssembly.This());
      //_container.Install(new ServiceInstaller());
      //_container.Install(new ControllerInstaller());

      var factory = new WindsorControllerFactory(_container.Kernel);
      ControllerBuilder.Current.SetControllerFactory(factory);
    }

    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      BootstrapWindsorContainer();
    }

    protected void Application_End()
    {
      _container.Dispose();
    }
  }
}
