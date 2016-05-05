using System;
using System.Collections.Generic;
using System.Linq;
using QuizPlatform.Models;

namespace QuizPlatform.Services
{
  public class QuizManager : IQuizManager
  {
    public List<Question> Shuffle(List<Question> questions)
    {
      Random random = new Random();
      return questions.OrderBy(x => random.Next()).ToList();
    }
  }
}