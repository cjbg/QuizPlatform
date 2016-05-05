using Castle.MicroKernel.Registration;
using Castle.Windsor;
using QuizPlatform.Services;

namespace QuizPlatform
{
  public static class WindsorConfig
  {
    public static void Register(IWindsorContainer container)
    {
      container.Register(Component.For<IQuizManager>().ImplementedBy<QuizManager>().LifeStyle.Transient);
    }
  }
}