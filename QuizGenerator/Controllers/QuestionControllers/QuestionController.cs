using System;
using AutoMapper;
using System.Linq;
using QuizManager.Entities;
using Microsoft.AspNetCore.Mvc;
using QuizGenerator.Api.Helpers;
using System.Collections.Generic;
using QuizGenerator.Data.ResourceParameters;
using QuizGenerator.Api.Models.QuestionModels;
using QuizGenerator.Data.Repositories.QuestionRepository;

namespace QuizGenerator.Api.Controllers.QuestionControllers
{
    [ApiController]
    [Route("api/questions")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _QuestionRepository;
        private readonly IMapper _mapper;
        public QuestionController(IQuestionRepository courseLibraryRepository, IMapper mapper)
        {
            _QuestionRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<QuestionDto>> GetQuestions([FromQuery]QuestionResourceParameters QuestionsResouceParameters)
        {
            var QuestionFromRepo = _QuestionRepository.GetQuestions(QuestionsResouceParameters);
            return Ok(_mapper.Map<IEnumerable<QuestionDto>>(QuestionFromRepo));
        }

        [HttpGet("{questionId:guid}", Name = "GetQuestion")]
        public IActionResult GetQuestion(Guid questionId)
        {
            var questionFromRepo = _QuestionRepository.GetQuestion(questionId);

            if (questionFromRepo == null)
                return NotFound();
            else
                return Ok(_mapper.Map<QuestionDto>(questionFromRepo));
        }

        [HttpPost]
        public ActionResult<QuestionDto> CreateQuestion(QuestionForCreationDto question)
        {
            if (question == null)
                return BadRequest();

            var questionEntity = _mapper.Map<Question>(question);
            _QuestionRepository.AddQuestion(questionEntity);
            _QuestionRepository.Save();

            var questionToReturn = _mapper.Map<QuestionDto>(questionEntity);

            return CreatedAtRoute("GetQuestion", new { questionId = questionToReturn.Id }, questionToReturn);
        }
    }
}
