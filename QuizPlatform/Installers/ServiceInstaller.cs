using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using QuizPlatform.Services.Interfaces;

namespace QuizPlatform.Installers
{
  public class ServiceInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(
        Classes.FromThisAssembly()
          .BasedOn(typeof(IService))
          .WithService.AllInterfaces()
          .LifestyleTransient());
    }
  }
}