using AutoMapper;
using QuizManager.Entities;
using QuizGenerator.Api.Models.AnswerModels;


namespace QuizGenerator.Api.Profiles
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<Answer, AnswerDto>();

            CreateMap<AnswerForCreationDto, Answer>();
        }
    }
}
