using System;
using AutoMapper;
using QuizManager.Entities;
using QuizGenerator.Api.Models.QuestionModels;

namespace QuizGenerator.Api.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionDto>();

            CreateMap<QuestionForCreationDto, Question>()
                .ForMember(
                dest => dest.Duration,
                opt => opt.MapFrom(src => TimeSpan.Parse(src.Duration))
                );
        }
    }
}
