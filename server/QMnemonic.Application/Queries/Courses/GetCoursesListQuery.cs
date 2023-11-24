using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using MediatR;
using QMnemonic.Infrastructure.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QMnemonic.Application.Queries.Courses
{
    public class GetCoursesListQuery : IRequest<List<Course>>
    {

    }


    public class GetCoursesListQueryHandler : IRequestHandler<GetCoursesListQuery, List<Course>>
    {
        private readonly IAsyncRepository<Course> _courseRepository;

        public GetCoursesListQueryHandler(IAsyncRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }


public async Task<List<Course>> Handle(GetCoursesListQuery request, CancellationToken cancellationToken)
{
    var courses = await _courseRepository.GetAllAsync();
    return courses.ToList();
}

    }


}