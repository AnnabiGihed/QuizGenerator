using System;
using AutoMapper;
using System.Linq;
using QuizManager.Entities;
using Microsoft.AspNetCore.Mvc;
using QuizGenerator.Api.Helpers;
using System.Collections.Generic;
using QuizGenerator.Api.Models.QuestionModels;
using QuizGenerator.Data.Repositories.QuestionRepository;

namespace QuizGenerator.Api.Controllers.QuestionControllers
{
    [ApiController]
    [Route("api/questionCollections")]
    public class QuestionCollectionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;

        public QuestionCollectionController(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository ??
                throw new ArgumentNullException(nameof(questionRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("({ids})", Name = "GetQuestionCollection")]
        public IActionResult GetAuthorCollection([FromRoute] [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
                return BadRequest();

            var questionEntities = _questionRepository.GetQuestions(ids);

            if (ids.Count() != questionEntities.Count())
                return NotFound();

            var questionsToReturn = _mapper.Map<IEnumerable<QuestionDto>>(questionEntities);

            return Ok(questionsToReturn);
        }

        [HttpPost]
        public ActionResult<IEnumerable<QuestionDto>> CreateAuthorCollection(IEnumerable<QuestionForCreationDto> questionCollection)
        {
            var questionEntities = _mapper.Map<IEnumerable<Question>>(questionCollection);

            foreach (var question in questionEntities)
            {
                _questionRepository.AddQuestion(question);
            }

            _questionRepository.Save();

            var questionCollectionToReturn = _mapper.Map<IEnumerable<QuestionDto>>(questionEntities);
            var idsAsString = string.Join(",", questionCollectionToReturn.Select(a => a.Id));
            return CreatedAtRoute("GetQuestionCollection", new { ids = idsAsString }, questionCollectionToReturn);
        }
    }
}
