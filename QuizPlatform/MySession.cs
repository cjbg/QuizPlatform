using System.Web;
using QuizPlatform.Resources;

namespace QuizPlatform
{
  public class MySession
  {
    private MySession()
    {
      // Add here default values
    }

    public static MySession Current
    {
      get
      {
        MySession session =
          (MySession)HttpContext.Current.Session[Constants.MySession];

        if (session == null)
        {
          session = new MySession();
          HttpContext.Current.Session[Constants.MySession] = session;
        }

        return session;
      }
    }

    public string QuizName { get; set; }
  }
}