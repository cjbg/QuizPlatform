using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizPlatform.Models
{
  public class Question
  {
    public Question()
    {
    }

    public int Id { get; set; }

    [Required]
    public int QuizId { get; set; }

    [DisplayName("Nazwa")]
    [Required(ErrorMessage = "Podaj nazwę")]
    [StringLength(50, ErrorMessage = "Pole może zawierać maksymalnie 50 znaków")]
    public string Name { get; set; }

    public virtual Quiz Quiz { get; set; }

    public virtual ICollection<Answer> Answers { get; set; }
  }
}