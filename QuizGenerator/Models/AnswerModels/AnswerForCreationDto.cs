using QuizGenerator.Api.Models.BaseEntityModel;
using QuizManager.Entities;
using QuizManager.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGenerator.Api.Models.AnswerModels
{
    public class AnswerForCreationDto : BaseEntityForCreationDto
    {
        public string Value { get; set; }
        public bool Correct { get; set; }
    }
}
