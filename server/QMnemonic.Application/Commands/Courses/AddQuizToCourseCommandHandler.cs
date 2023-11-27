using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MediatR;
using QMnemonic.Application.Commands.Quizzes;
using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;

namespace QMnemonic.Application.Commands.Courses
{
    public class AddQuizToCourseCommandHandler : IRequestHandler<AddQuizToCourseCommand, int>
    {
    private readonly ICourseRepository _courseRepository;

    public AddQuizToCourseCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

        public async Task<int> Handle(AddQuizToCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.CourseId);



            var newQuiz = new Quiz
            {
                Name = request.Name,
                Description = request.Description,
                CourseId = request.CourseId
            };

            course.Quizzes.Add(newQuiz);


            await _courseRepository.UpdateAsync(course);

            
            return newQuiz.Id;
        }
    }
}