using System.Web;

namespace QuizPlatform.Models.Domain
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
          (MySession) HttpContext.Current.Session["MySession"];

        if (session == null)
        {
          session = new MySession();
          HttpContext.Current.Session["MySession"] = session;
        }

        return session;
      }
    }

    public string QuizName { get; set; }
  }
}