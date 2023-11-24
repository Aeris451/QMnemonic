using MediatR;
using QMnemonic.Domain.Repositories;
using QMnemonic.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace QMnemonic.Application.Commands.Courses
{
    public class CreateCourseCommand : IRequest<int>
    {
        public string Name{ get; set; }
        public string Language {get; set;}
    }

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
    {
        private readonly IAsyncRepository<Course> _courseRepository;

        public CreateCourseCommandHandler(IAsyncRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var newCourse = new Course
            {
                Name = request.Name,
                Language = request.Language,
                Quizzes = new List<Quiz>(),
                InteractiveTexts = new List<InteractiveText>()
            };

            await _courseRepository.AddAsync(newCourse);

            
            return newCourse.Id;
        }
    }
}
