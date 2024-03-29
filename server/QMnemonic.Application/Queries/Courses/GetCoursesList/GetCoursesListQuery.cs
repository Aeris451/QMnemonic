using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using MediatR;
using AutoMapper;


namespace QMnemonic.Application.Queries.Courses
{



    public class GetCoursesListQuery : IRequest<List<CourseListDTO>>
    {
        public string LanguageCode {get; set;}
        public int Page {get; set;}
    }





}