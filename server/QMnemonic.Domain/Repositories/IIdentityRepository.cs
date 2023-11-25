using QMnemonic.Domain.Identity;

namespace QMnemonic.Domain.Repositories
{
    public interface IIdentityRepository
    {
        Task<IApplicationUser> GetUserByEmailAsync(string email);
        Task<IApplicationUser> GetByIdAsync(int Id);
        Task<IEnumerable<IApplicationUser>> GetAllAsync();
        Task AddAsync(IApplicationUser value);
        Task UpdateAsync(IApplicationUser value);
        Task DeleteAsync(IApplicationUser value);
    }
}
