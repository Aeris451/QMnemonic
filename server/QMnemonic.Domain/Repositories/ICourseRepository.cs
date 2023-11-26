using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Domain.Repositories
{
    public interface ICourseRepository : IAsyncRepository<Course>
    {
        Task<IEnumerable<Course>> GetByLanguageAsync(string code);
    }
}