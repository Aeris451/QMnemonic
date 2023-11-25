using Microsoft.EntityFrameworkCore;
using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using QMnemonic.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QMnemonic.Infrastructure.Repositories
{
    public class QuizRepository : IAsyncRepository<Quiz>
    {
        private readonly ApplicationDbContext _context;

        public QuizRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Quiz value)
        {
            await _context.Quizzes.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Quiz value)
        {
            _context.Quizzes.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return await _context.Quizzes.ToListAsync();
        }

        public async Task<Quiz> GetByIdAsync(int Id)
        {
            return await _context.Quizzes.FindAsync(Id);
        }

        public async Task UpdateAsync(Quiz value)
        {
            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
