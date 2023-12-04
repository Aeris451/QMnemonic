using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;

namespace QMnemonic.Application.Commands.Courses
{
    public class AddReadingToCourseCommandHandler : IRequestHandler<AddReadingToCourseCommand>
    {
    private readonly ICourseRepository _courseRepository;

    public AddReadingToCourseCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

        public async Task Handle(AddReadingToCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.CourseId);



            var newReading = new Reading
            {
                Name = request.Name,
                Course = course,
                CourseId = request.CourseId,
                Description = request.Description,
                Order = course.Readings.Last().Order + 1
            };

            course.Readings.Add(newReading);

            await _courseRepository.UpdateAsync(course);

        }
    }
}