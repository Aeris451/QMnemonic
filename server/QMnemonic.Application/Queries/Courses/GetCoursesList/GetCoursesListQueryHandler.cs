using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;

namespace QMnemonic.Application.Queries.Courses
{
    public class GetCoursesListQueryHandler : IRequestHandler<GetCoursesListQuery, List<CourseListDTO>>
    {
        private readonly IAsyncRepository<Course> _courseRepository;
        private readonly IMapper _mapper; 


        public GetCoursesListQueryHandler(IAsyncRepository<Course> courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }


        public async Task<List<CourseListDTO>> Handle(GetCoursesListQuery request, CancellationToken cancellationToken)
        {


            var courses = await _courseRepository.GetAllAsync();
            var coursesDTO = _mapper.Map<List<CourseListDTO>>(courses); 
            

            return coursesDTO;
        }

    }
}