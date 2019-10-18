using System;
using QuizManager.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizManager.Entities
{
    public class Answer : BaseEntity
    {
        [Required]
        public string Value { get; set; }

        [Required]
        public bool Correct { get; set; }

        public AnswerType Type { get; set; }

        [ForeignKey("QuestionId")]
        public Guid QuestionId { get; set; }
    }
}
