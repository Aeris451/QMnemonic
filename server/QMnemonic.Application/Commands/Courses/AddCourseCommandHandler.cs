using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;

namespace QMnemonic.Application.Commands.Courses
{
    public class AddCourseCommandHandler : IRequestHandler<AddCourseCommand, int>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILanguageRepository _languageRepository;
        public AddCourseCommandHandler(ICourseRepository courseRepository, ILanguageRepository languageRepository)
        {
            _courseRepository = courseRepository;
            _languageRepository = languageRepository;
        }

        public async Task<int> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            

            var newCourse = new Course
            {
                Name = request.Name,
                AuthorId = request.AuthorId,
                Description = request.Description,
                ShortDescription = request.ShortDescription,
                Language = await _languageRepository.GetByIdAsync(request.LanguageId),
            };
            

            await _courseRepository.AddAsync(newCourse);

            
            return newCourse.Id;
        }
    }
}