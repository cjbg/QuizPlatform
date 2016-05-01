using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuizPlatform.Models.Domain;

namespace QuizPlatform.Models
{
  public class Quiz
  {
    public Quiz()
    {      
    }

    public int Id { get; set; }
    
    [DisplayName("Nazwa")]
    [Required(ErrorMessage = "Podaj nazwę dla quizu")]
    [StringLength(50, ErrorMessage = "Pole może zawierać maksymalnie 50 znaków")]
    public string Name { get; set; }    

    [DisplayName("Kategoria")]
    [Required(ErrorMessage = "Podaj kategorię")]    
    public virtual Categories Category { get; set; }

    [DisplayName("Zestaw")]
    [Required(ErrorMessage = "Podaj zestaw")]
    public virtual Sets Set { get; set; }

    public virtual ICollection<Question> Questions { get; set; }
  }
}