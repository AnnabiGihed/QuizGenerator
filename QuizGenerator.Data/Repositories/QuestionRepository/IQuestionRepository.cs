using System;
using QuizManager.Entities;
using System.Collections.Generic;
using QuizGenerator.Data.ResourceParameters;

namespace QuizGenerator.Data.Repositories.QuestionRepository
{
    public interface IQuestionRepository
    {
        void AddQuestion(Question question);
        IEnumerable<Question> GetQuestions();
        Question GetQuestion(Guid questionId);
        IEnumerable<Question> GetQuestions(IEnumerable<Guid> questionId);
        IEnumerable<Question> GetQuestions(QuestionResourceParameters questionResourceParameters);
        void DeleteQuestion(Question question);
        void UpdateQuestion(Question question);
        bool QuestionExist(Guid questionId);

        bool Save();
    }
}
