using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using log4net.Config;

namespace QuizPlatform.Installers
{
  [assembly: XmlConfigurator(Watch = true)]
  public class LoggerInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
     log4net.Config.XmlConfigurator.Configure();
      container.AddFacility<LoggingFacility>(x => x.UseLog4Net());
    }
  }
}