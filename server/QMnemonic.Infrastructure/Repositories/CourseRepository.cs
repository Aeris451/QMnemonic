using Microsoft.EntityFrameworkCore;
using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using QMnemonic.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QMnemonic.Infrastructure.Repositories
{
    public class CourseRepository : IAsyncRepository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Course value)
        {
            await _context.Courses.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Course value)
        {
            _context.Courses.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int Id)
        {
            return await _context.Courses.FindAsync(Id);
        }

        public async Task UpdateAsync(Course value)
        {
            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Course>> GetByLanguageAsync(int id)
        {
            return await _context.Courses
            .Where(course => course.Language.Id == id)
            .ToListAsync();
        }
    }
}
