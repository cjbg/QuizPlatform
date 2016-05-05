using System.Collections.Generic;
using QuizPlatform.Models;

namespace QuizPlatform.Services.Interfaces
{
  public interface IQuizManager
  {
    void Shuffle(ref List<Question> questions);
  }
}