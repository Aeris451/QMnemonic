using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using MediatR;

namespace QMnemonic.Application.Queries.Courses
{
    public class GetCourseQuery : IRequest<Course>
    {
        public int Id {get; set;}
    }


 

}