
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizGenerator.Api.Models.AnswerModels;
using QuizGenerator.Data.Repositories.AnswerRepository;
using QuizManager.Entities;
using System;
using System.Collections.Generic;

namespace QuizGenerator.Api.Controllers.AnswerControllers
{
    [ApiController]
    [Route("api/questions/{questionId}/answers")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;
        public AnswerController(IAnswerRepository AnswerRepository, IMapper mapper)
        {
            _answerRepository = AnswerRepository ??
                throw new ArgumentNullException(nameof(AnswerRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnswerDto>> GetAnswersForQuestion(Guid questionId)
        {
            if (!_answerRepository.QuestionExist(questionId))
                return NotFound();

            var AnswersForQuestionsFromRepo = _answerRepository.GetAnswers(questionId);
            return Ok(_mapper.Map<IEnumerable<AnswerDto>>(AnswersForQuestionsFromRepo));
        }

        [HttpGet("{answerId}", Name = "GetAnswerForQuestion")]
        public ActionResult<IEnumerable<AnswerDto>> GetAnswersForQuestion(Guid questionId, Guid answerId)
        {
            if (!_answerRepository.QuestionExist(questionId))
                return NotFound();

            var answerForQuestionFromRepo = _answerRepository.GetAnswer(questionId, answerId);

            if (answerForQuestionFromRepo == null)
                return NotFound();

            return Ok(_mapper.Map<AnswerDto>(answerForQuestionFromRepo));
        }

        [HttpPost]
        public ActionResult<AnswerDto> CreateAnswerForQuestion(Guid questionId, AnswerForCreationDto answer)
        {
            if (!_answerRepository.QuestionExist(questionId))
                return NotFound();

            var answerEntity = _mapper.Map<Answer>(answer);
            _answerRepository.AddAnswer(questionId, answerEntity);
            _answerRepository.Save();

            var answerToReturn = _mapper.Map<AnswerDto>(answerEntity);
            return CreatedAtRoute("GetAnswerForQuestion", new { questionId = questionId, answerId = answerToReturn.Id }, answerToReturn);
        }
    }
}