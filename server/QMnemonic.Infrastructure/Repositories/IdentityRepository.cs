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
    }
}
