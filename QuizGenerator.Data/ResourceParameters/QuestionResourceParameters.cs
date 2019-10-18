using System;
using QuizManager.Entities;

namespace QuizGenerator.Data.ResourceParameters
{
    public class QuestionResourceParameters
    {
        public string SearchQuery { get; set; }
        public Guid Category { get; set; }
    }
}
