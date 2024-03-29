using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Domain.Repositories
{
    public interface IReadingRepository : IAsyncRepository<Reading>
    {
        Task<List<string>> GetQuestionContents(List<int> QuizIds);
    }
}