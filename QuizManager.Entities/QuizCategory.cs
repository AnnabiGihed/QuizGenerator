using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizManager.Entities
{
    public class QuizCategory : BaseEntity
    {
        [MaxLength(50)]
        public string Title { get; set; }
        public ICollection<Quiz> Quizs { get; set; }
            = new List<Quiz>();
    }
}
