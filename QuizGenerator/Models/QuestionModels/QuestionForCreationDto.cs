using System;
using QuizManager.Entities;
using QuizManager.Entities.Enums;
using System.Collections.Generic;

namespace QuizGenerator.Api.Models.QuestionModels
{
    public class QuestionForCreationDto
    {
        public string Title { get; set; }
        public QuestionType Type { get; set; }
        public string Duration { get; set; }
        public string QuestionContent { get; set; }
        public Guid QuestionCategoryId { get; set; }
        public QuestionCategory Category { get; set; }
        public ICollection<Answer> Answers { get; set; }
            = new List<Answer>();
    }
}
