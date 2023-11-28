using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using QMnemonic.Infrastructure.Data;

namespace QMnemonic.Infrastructure.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {

        private readonly ApplicationDbContext _context;

        public LanguageRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public Task AddAsync(Language value)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Language value)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Language>> GetAllAsync()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task<Language> GetByIdAsync(int Id)
        {
            return await _context.Languages.FindAsync(Id);
        }


        public Task UpdateAsync(Language value)
        {
            throw new NotImplementedException();
        }

    }
}