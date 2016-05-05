using System;
using System.Collections.Generic;
using System.Linq;
using QuizPlatform.Models;
using QuizPlatform.Services.Interfaces;

namespace QuizPlatform.Services
{
  public class QuizManager : IQuizManager, IService
  {
    public void Shuffle(ref List<Question> questions)
    {
      Random random = new Random();
      questions = questions.OrderBy(x => random.Next()).ToList();
    }
  }
}
