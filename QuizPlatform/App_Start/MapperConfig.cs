using AutoMapper;
using QuizPlatform.Models;

namespace QuizPlatform
{
  public static class MapperConfig
  {
    public static IMapper Mapper;

    public static void BootstrapMapper()
    {
      var config = new MapperConfiguration(
        cfg => cfg.CreateMap<Question, Models.Domain.Question>()
          .AfterMap((src, dest) => dest.Repetitions = 2));      

      Mapper = config.CreateMapper();
    }
  }
}