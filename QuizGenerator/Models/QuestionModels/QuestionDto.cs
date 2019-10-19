using System;
using QuizManager.Entities;
using QuizManager.Entities.Enums;
using System.Collections.Generic;
using QuizGenerator.Api.Models.BaseEntityModel;

namespace QuizGenerator.Api.Models.QuestionModels
{
    public class QuestionDto : BaseEntityDto
    {
        public string Title { get; set; }
        public QuestionType Type { get; set; }
        public TimeSpan Duration { get; set; }
        public string QuestionContent { get; set; }
        public QuestionCategory Category { get; set; }
        public ICollection<Answer> Answers { get; set; }
            = new List<Answer>();
    }
}
