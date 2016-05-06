using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;
using QuizPlatform.Factories;
using QuizPlatform.Helpers;

namespace QuizPlatform
{
  public static class WindsorConfig
  {
    public static void BootstrapContainer(IWindsorContainer container)
    {
      Guard.NotNull(container, () => container);

      container.Install(FromAssembly.This());

      var factory = new WindsorControllerFactory(container.Kernel);
      ControllerBuilder.Current.SetControllerFactory(factory);
    }
  }
}