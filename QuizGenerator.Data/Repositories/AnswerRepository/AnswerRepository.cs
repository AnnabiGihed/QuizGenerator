using System;
using System.Linq;
using QuizManager.Entities;
using System.Collections.Generic;
using QuizGenerator.Data.DbContexts;

namespace QuizGenerator.Data.Repositories.AnswerRepository
{
    public class AnswerRepository : IAnswerRepository, IDisposable
    {
        private readonly QuizGeneratorContext _context;

        public AnswerRepository(QuizGeneratorContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddAnswer(Guid questionId, Answer answer)
        {
            if (questionId == Guid.Empty)
                throw new ArgumentNullException(nameof(questionId));

            if (answer == null)
                throw new ArgumentNullException(nameof(answer));

            answer.Created = DateTime.Now;
            answer.Modified = DateTime.Now;

            answer.QuestionId = questionId;
            _context.Answers.Add(answer);
        }
        public void DeleteAnswer(Answer answer)
        {
            _context.Answers.Remove(answer);
        }
        public Answer GetAnswer(Guid QuestionId, Guid AnswerId)
        {
            if (QuestionId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(QuestionId));
            }

            if (AnswerId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(AnswerId));
            }

            return _context.Answers
              .Where(c => c.QuestionId == QuestionId && c.Id == AnswerId).FirstOrDefault();
        }
        public IEnumerable<Answer> GetAnswers(Guid questionId)
        {
            if (questionId == Guid.Empty)
                throw new ArgumentNullException(nameof(questionId));

            return _context.Answers.Where(c => (c.QuestionId == questionId)).ToList();
        }
        public void UpdateAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }
        public bool QuestionExist(Guid questionId)
        {
            if (questionId == Guid.Empty)
                throw new ArgumentNullException(nameof(questionId));

            return _context.Questions.Any(Qs => Qs.Id == questionId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
