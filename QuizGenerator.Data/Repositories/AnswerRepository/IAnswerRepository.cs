using QuizManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGenerator.Data.Repositories.AnswerRepository
{
    public interface IAnswerRepository
    {
        void AddAnswer(Guid questionId, Answer answer);
        void DeleteAnswer(Answer answer);
        Answer GetAnswer(Guid QuestionId, Guid AnswerId);
        IEnumerable<Answer> GetAnswers(Guid questionId);
        void UpdateAnswer(Answer answer);
        bool QuestionExist(Guid questionId);
        bool Save();
    }
}
