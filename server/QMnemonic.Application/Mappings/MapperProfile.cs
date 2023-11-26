using AutoMapper;
using QMnemonic.Application.Queries.Courses;
using QMnemonic.Domain.Entities;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
CreateMap<Course, CourseListDTO>()
    .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language.LanguageName));


    }
}
