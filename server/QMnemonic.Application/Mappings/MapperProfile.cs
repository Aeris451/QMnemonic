using AutoMapper;
using QMnemonic.Application.Queries.Courses;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Application.Mappings;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Course, CourseListDTO>()
            .ForMember(dest => dest.LanguageCode, opt => opt.MapFrom(src => src.Language.LanguageCode))
            .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId.ToString()));
    }


}
