using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Domain.Repositories
{
    public interface IQuizRepository :IAsyncRepository<Quiz>
    {
        public Task<IEnumerable<Quiz>> GetQuizList(int courseId);
        public Task<Quiz> GetQuizFromCourse(int courseId, int quizId);

    }
}