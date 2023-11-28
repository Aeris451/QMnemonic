using AutoMapper;
using QMnemonic.Application.Queries.Courses;
using QMnemonic.Application.Queries.Quizzes;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Application.Mappings;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Course, CourseListDTO>()
            .ForMember(dest => dest.LanguageCode, opt => opt.MapFrom(src => src.Language.LanguageName))
            .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId.ToString()));

        CreateMap<Quiz, QuizListDTO>()
            .ForMember(dest => dest.Elements, opt => opt.MapFrom(src => src.Questions.Count))
            .ForMember(dest => dest.QuizId, opt => opt.MapFrom(src => src.Id));

        CreateMap<Reading, ReadingListDTO>()
            .ForMember(dest => dest.Elements, opt => opt.MapFrom(src => src.Texts.Count))
            .ForMember(dest => dest.ReadingId, opt => opt.MapFrom(src => src.Id));


        CreateMap<Course, CourseDetailsDTO>()
            .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.Language.LanguageName))
            .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId.ToString()));
    }


}
