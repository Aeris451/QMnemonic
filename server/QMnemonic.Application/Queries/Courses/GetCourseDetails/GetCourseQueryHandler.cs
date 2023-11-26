using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using MediatR;
using QMnemonic.Application.Queries.Courses;



namespace QMnemonic.Application.Queries.Courses;

  
public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, Course>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


    public async Task<Course> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id);
            return course;
        }

    }
