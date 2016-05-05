using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizPlatform.Models
{
  public class Answer
  {
    public Answer()
    {      
    }

    public int Id { get; set; }

    [Required]
    public int QuestionId { get; set; }

    [DisplayName("Nazwa")]
    [Required(ErrorMessage = "Podaj nazwę")]
    [MaxLength(50, ErrorMessage = "Pole może zawierać maksymalnie 50 znaków")]
    public string Name { get; set; }

    [DisplayName("Odpowiedź poprawna")]
    [Required(ErrorMessage = "Podaj czy odpowiedź jest poprawna")]
    public bool IsCorrect { get; set; }                   

    public virtual Question Question { get; set; }
  }
}
