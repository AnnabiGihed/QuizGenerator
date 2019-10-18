using System;
using QuizManager.Entities.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizManager.Entities
{
    public class Question : BaseEntity
    {
        [MaxLength(50)]
        public string Title { get; set; }
        public QuestionType Type { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }
        public string QuestionContent { get; set; }
        [ForeignKey("QuestionCategoryId")]
        public virtual QuestionCategory Category { get; set; }
        public Guid QuestionCategoryId { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
            = new List<Answer>();
    }
}
