using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QMnemonic.Domain.VO
{
    public abstract class Statistics
    {

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public int UsersNumber {get; set;} = 0;


    }
}