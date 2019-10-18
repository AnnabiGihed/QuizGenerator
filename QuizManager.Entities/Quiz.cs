using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizManager.Entities
{
    public class Quiz : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }
        public QuizCategory Category { get; set; }
        [DataType(DataType.DateTime)]
        public DateTimeOffset EndDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTimeOffset StartDate { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
