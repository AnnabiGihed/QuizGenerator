using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGenerator.Api.Models.BaseEntityModel
{
    public class BaseEntityDto
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Description { get; set; }
    }
}
