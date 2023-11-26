using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using QMnemonic.Infrastructure.Data;

namespace QMnemonic.Infrastructure.Repositories
{
    public class QuizRepository : IQuizRepository
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

        public Task DeleteAsync(Quiz value)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Quiz>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Quiz>> GetByCourse(int courseId)
        {
            return await _context.Quizzes
            .Where(quiz => quiz.Course.Id == courseId)
            .ToListAsync();
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