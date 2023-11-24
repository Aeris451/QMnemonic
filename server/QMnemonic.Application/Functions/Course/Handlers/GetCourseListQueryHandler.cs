using MediatR;
using Microsoft.EntityFrameworkCore; 
using QMnemonic.Application.Courses.Queries;
using QMnemonic.Domain.Entities;
using QMnemonic.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QMnemonic.Application.Courses.Handlers
{
    public class GetCourseListQueryHandler : IRequestHandler<GetCourseListQuery, List<CourseDto>>
    {
        private readonly ApplicationDbContext _dbContext; // Dodaj swojego DbContexta

        public GetCourseListQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CourseDto>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            // Tutaj umieść logikę do pobrania listy kursów z bazy danych
            var courses = await _dbContext.Courses
                .Select(c => new CourseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    // Dodaj inne właściwości, jeśli są potrzebne
                })
                .ToListAsync(cancellationToken);

            return courses;
        }
    }
}
