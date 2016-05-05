using System;
using System.Data.Entity;

namespace QuizPlatform.Models
{
  public class QuizPlatformInitializer : DropCreateDatabaseIfModelChanges<QuizContext>
  {
    protected override void Seed(QuizContext context)
    {
      AddCategories(context);
      AddSets(context);

      context.SaveChanges();
    }
    
    private void AddSets(QuizContext context)
    {
      Set set1 = new Set();
      set1.Name = Enum.GetName(typeof (Sets), 1);

      context.Sets.Add(set1);
    }

    private void AddCategories(QuizContext context)
    {     
      Category category1 = new Category();
      category1.Name = Enum.GetName(typeof (Categories), 1);
      
      Category category2 = new Category();
      category2.Name = Enum.GetName(typeof (Categories), 2);

      context.Categories.Add(category1);
      context.Categories.Add(category2);
    }
  }
}