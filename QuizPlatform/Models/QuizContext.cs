using System.Data.Entity;

namespace QuizPlatform.Models
{
  public class QuizContext : DbContext
  {
    public QuizContext()
      : base("QuizPlatform")
    {      
      Database.SetInitializer(new QuizPlatformInitializer());
    }

    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Set> Sets { get; set; }
  }
}