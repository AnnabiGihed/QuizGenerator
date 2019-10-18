﻿using System;
using QuizManager.Entities;
using System.Collections.Generic;
using QuizGenerator.Data.ResourceParameters;

namespace QuizGenerator.Data.Repositories.QuestionRepository
{
    public interface IQuestionRepository
    {
        #region Question Data Handling
        void AddQuestion(Question question);
        IEnumerable<Question> GetQuestions();
        Question GetQuestion(Guid questionId);
        IEnumerable<Question> GetQuestions(IEnumerable<Guid> questionId);
        IEnumerable<Question> GetQuestions(QuestionResourceParameters questionResourceParameters);
        void DeleteQuestion(Question question);
        void UpdateQuestion(Question question);
        bool QuestionExist(Guid questionId);
        #endregion Question Data Handling


        #region Question's Answers Data Handling
        void AddChoosenAnswer(Guid QuestionId, Answer ChoosenAnswer);
        void AddPossibleAnswer(Guid QuestionId, Answer PossibleAnswer);
        void DeleteAnswer(Answer answer);
        Answer GetAnswer(Guid QuestionId, Guid AnswerId);
        IEnumerable<Answer> GetChoosenAnswers(Guid QuestionId);
        IEnumerable<Answer> GetPossibleAnswers(Guid QuestionId);
        void UpdateAnswer(Answer answer);
        #endregion Question's Answers Data Handling

        bool Save();
    }
}
