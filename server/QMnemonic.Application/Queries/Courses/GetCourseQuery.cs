using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using MediatR;
using QMnemonic.Infrastructure.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QMnemonic.Application.Queries.Courses
{
    public class GetCourseQuery : IRequest<Course>
    {
        public int Id {get; set;}
    }


    public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, Course>
    {
        private readonly IAsyncRepository<Course> _courseRepository;

        public GetCourseQueryHandler(IAsyncRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }


    public async Task<Course> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id);
            return course;
        }

    }


}