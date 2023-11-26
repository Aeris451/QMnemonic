using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using MediatR;
using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;

namespace QMnemonic.Application.Commands.Readings
{
    public class AddTextToReadingCommandHandler : IRequestHandler<AddTextToReadingCommand>
    {
    private readonly ICourseRepository _courseRepository;

    public AddTextToReadingCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

        public async Task Handle(AddTextToReadingCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.CourseId);



            var newText = new Text
            {
                OrgContent = request.Content
            };

            course.Reading.Texts.Add(newText);

            await _courseRepository.UpdateAsync(course);

        }
    }
}