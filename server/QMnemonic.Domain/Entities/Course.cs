using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QMnemonic.Domain.Identity;
using QMnemonic.Domain.VO;

namespace QMnemonic.Domain.Entities
{


    public class Course : Statistics
    {
        public int Id {get; set;}
        public List<Quiz> Quizzes {get; set;} = new List<Quiz>();
        public List<Reading> Readings {get; set;} = new List<Reading>();
        public Language Language {get; set;}
        public string Name {get; set;} 
        public string Description {get; set;} 
        public string ShortDescription {get; set;}
        public int AuthorId {get; set;}
    }
}