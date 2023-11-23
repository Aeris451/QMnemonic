using System.Collections.Generic;
using System.Threading.Tasks;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Domain.Repositories
{
    public interface IAsyncRepository<T>
    {
        Task<T> GetByIdAsync(int Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T value);
        Task UpdateAsync(T value);
        Task DeleteAsync(T value);
    }
}
