using QuizGenerator.Api.Models.BaseEntityModel;
using QuizManager.Entities;
using QuizManager.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGenerator.Api.Models.AnswerModels
{
    public class AnswerDto : BaseEntityDto
    {
        public string Value { get; set; }
        public bool Correct { get; set; }
    }
}
