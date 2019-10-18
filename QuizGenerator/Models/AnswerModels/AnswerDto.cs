using QuizManager.Entities;
using QuizManager.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGenerator.Api.Models.AnswerModels
{
    public class AnswerDto
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public bool Correct { get; set; }
        public AnswerType Type { get; set; }
        public Question Question { get; set; }
    }
}
