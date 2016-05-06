using System;
using System.Linq.Expressions;

namespace QuizPlatform.Helpers
{
  public static class Guard
  {
    public static void NotNull<T>(object parameter, Expression<Func<T>> parameterExpression)
    {
      if (parameter == null)
      {
        throw new ArgumentNullException(GetMemberName(parameterExpression));
      }
    }

    private static string GetMemberName<T>(Expression<Func<T>> memberExpression)
    {
      MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
      return expressionBody.Member.Name;
    } 
  }
}