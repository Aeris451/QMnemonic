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
    public class ReadingRepository : IReadingRepository
    {

        private readonly ApplicationDbContext _context;

        public ReadingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Reading value)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Reading value)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reading>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Reading> GetByIdAsync(int Id)
        {
            return await _context.Readings
            .Include(r => r.Texts)
            .FirstOrDefaultAsync(r => r.Id == Id);
        }

        public async Task<List<string>> GetQuestionContents(List<int> QuizIds)
        {
            List<string> questionContent = new List<string>();

            var quizzes = await _context.Quizzes
                .Where(q => QuizIds.Contains(q.Id))
                .Include(q => q.Questions)
                .ToListAsync();

            foreach (var quiz in quizzes)
            {
                questionContent.AddRange(quiz.Questions.Select(q => q.Content));
            }

            return questionContent;
        }


        public async Task UpdateAsync(Reading value)
        {
            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}