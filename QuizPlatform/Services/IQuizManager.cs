using System.Collections.Generic;
using QuizPlatform.Models;

namespace QuizPlatform.Services
{
  public interface IQuizManager
  {
    List<Question> Shuffle(List<Question> questions);
  }
}