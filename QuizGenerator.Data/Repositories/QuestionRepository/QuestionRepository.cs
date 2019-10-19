using System;
using System.Linq;
using QuizManager.Entities;
using System.Collections.Generic;
using QuizManager.Entities.Enums;
using QuizGenerator.Data.DbContexts;
using QuizGenerator.Data.ResourceParameters;
using Microsoft.EntityFrameworkCore;

namespace QuizGenerator.Data.Repositories.QuestionRepository
{
    public class QuestionRepository : IQuestionRepository, IDisposable
    {
        private readonly QuestionContext _context;

        public QuestionRepository(QuestionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        #region Question Data Handling
        public void AddQuestion(Question question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            if(question.QuestionCategoryId == Guid.Empty)
            {
                if(question.Category != null)
                {
                    question.Category.Id = Guid.NewGuid();
                    question.Category.Created = DateTime.Now;
                    question.Category.Modified = DateTime.Now;
                }
            }
            // the repository fills the id (instead of using identity columns)
            question.Id = Guid.NewGuid();
            question.Created = DateTime.Now;
            question.Modified = DateTime.Now;

            foreach (var Answers in question.Answers)
            {
                Answers.Id = Guid.NewGuid();
                Answers.Created = DateTime.Now;
                Answers.Modified = DateTime.Now;
            }

            _context.Questions.Add(question);
        }
        public bool QuestionExist(Guid questionId)
        {
            if (questionId == Guid.Empty)
                throw new ArgumentNullException(nameof(questionId));

            return _context.Questions.Any(Qs => Qs.Id == questionId);
        }
        public void DeleteQuestion(Question question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            _context.Questions.Remove(question);
        }

        #region Question Data Retrivers functions
        public Question GetQuestion(Guid questionId)
        {
            if (questionId == Guid.Empty)
                throw new ArgumentNullException(nameof(questionId));

            return _context.Questions
                .Include(Qs => Qs.Category)
                .Include(Qs => Qs.Answers)
                .FirstOrDefault(Qs => Qs.Id == questionId);
        }
        public IEnumerable<Question> GetQuestions()
        {
            return _context.Questions.Include(Qs => Qs.Category).Include(Qs => Qs.Answers).ToList<Question>();
        }
        public IEnumerable<Question> GetQuestions(IEnumerable<Guid> questionId)
        {
            if (questionId == null)
                throw new ArgumentNullException(nameof(questionId));

            return _context.Questions.Where(Qs => questionId.Contains(Qs.Id))
                .OrderBy(Qs => Qs.Title)
                .Include(Qs => Qs.Category)
                .Include(Qs => Qs.Answers)
                .ToList();
        }
        public IEnumerable<Question> GetQuestions(QuestionResourceParameters questionResourceParameters)
        {
            if (questionResourceParameters == null)
                throw new ArgumentNullException(nameof(questionResourceParameters));

            if ((string.IsNullOrWhiteSpace(questionResourceParameters.SearchQuery)) && (questionResourceParameters.Category == Guid.Empty))
                return GetQuestions();

            var collection = _context.Questions as IQueryable<Question>;

            if (questionResourceParameters.Category != Guid.Empty)
            {
                return _context.Questions.Where(qs => (qs.Category.Id == questionResourceParameters.Category))
                    .Include(Qs => Qs.Category)
                    .Include(Qs => Qs.Answers)
                    .ToList();
            }

            if ((!string.IsNullOrWhiteSpace(questionResourceParameters.SearchQuery)))
            {
                var searchQuery = questionResourceParameters.SearchQuery.Trim();
                collection = collection.Where(Qs => Qs.Title.Contains(searchQuery));
            }
            return collection.Include(Qs => Qs.Category).Include(Qs => Qs.Answers).ToList();
        }
        #endregion Question Data Retrivers functions

        public void UpdateQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        #endregion QuestionHandling

        #region Question's Answwer Data Handling
        public void AddAnswer(Guid questionId, Answer answer)
        {
            if (questionId == Guid.Empty)
                throw new ArgumentNullException(nameof(questionId));

            if (answer == null)
                throw new ArgumentNullException(nameof(answer));

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
        #endregion Question's Answwer Data Handling

        #region Disposal
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
        #endregion Disposal
    }
}
