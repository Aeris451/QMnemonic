using QMnemonic.Domain.Identity;
using QMnemonic.Domain.Repositories;
using QMnemonic.Infrastructure.Data;

namespace QMnemonic.Infrastructure.Identity
{

    public class IdentityRepository 
    {
        private readonly ApplicationDbContext _context;

        public IdentityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(ApplicationUser value)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ApplicationUser value)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetByIdAsync(int Id)
        {
            return await _context.ApplicationUsers.FindAsync(Id);
        }

        public async Task<ApplicationUser> GetByUserName(string UserName)
        {
            return await _context.ApplicationUsers.FindAsync(UserName);
        }

        public Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApplicationUser value)
        {
            throw new NotImplementedException();
        }
    }
}
