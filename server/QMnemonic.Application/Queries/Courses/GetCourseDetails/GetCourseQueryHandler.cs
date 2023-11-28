using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using MediatR;
using QMnemonic.Application.Queries.Courses;
using AutoMapper;
using QMnemonic.Application.Queries.Quizzes;



namespace QMnemonic.Application.Queries.Courses;

  
public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, CourseDetailsDTO>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

    public GetCourseQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }


    public async Task<CourseDetailsDTO> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id);

            var courseDTO = _mapper.Map<CourseDetailsDTO>(course);

            courseDTO.Quizzes = _mapper.Map<List<QuizListDTO>>(course.Quizzes);
            courseDTO.Readings = _mapper.Map<List<ReadingListDTO>>(course.Readings);
            


            
            return courseDTO;
        }

    }
