using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QMnemonic.Domain.Repositories;
using QMnemonic.Domain.Entities;
using QMnemonic.Infrastructure.Data;

namespace QMnemonic.Infrastructure.Repositories
{
    public class LanguageRepository : IAsyncRepository<Language>
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

        public Task<IEnumerable<Language>> GetAllAsync()
        {
            throw new NotImplementedException();
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