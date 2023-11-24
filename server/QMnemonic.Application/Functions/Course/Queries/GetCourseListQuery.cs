using MediatR;
using System.Collections.Generic;

namespace QMnemonic.Application.Courses.Queries
{
    public class GetCourseListQuery : IRequest<List<CourseDto>>
    {
        
    }
}
