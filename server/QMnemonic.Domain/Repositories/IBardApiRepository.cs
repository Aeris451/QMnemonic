using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QMnemonic.Domain.Repositories
{
    public interface IBardApiRepository
    {
        Task<string> Generator(string prompt, string content, string key);
    }
}