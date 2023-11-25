using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;

namespace QMnemonic.Application.Commands.Courses
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
    {
        private readonly IAsyncRepository<Course> _courseRepository;
        private readonly IAsyncRepository<Language> _languageRepository;
        public CreateCourseCommandHandler(IAsyncRepository<Course> courseRepository, IAsyncRepository<Language> languageRepository)
        {
            _courseRepository = courseRepository;
            _languageRepository = languageRepository;
        }

        public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            

            var newCourse = new Course
            {
                Name = request.Name,
                AuthorName = request.Author,
                Quizzes = new List<Quiz>(),
                InteractiveTexts = new List<InteractiveText>(),
                Language = await _languageRepository.GetByIdAsync(request.LanguageId)
            };
            

            await _courseRepository.AddAsync(newCourse);

            
            return newCourse.Id;
        }
    }
}