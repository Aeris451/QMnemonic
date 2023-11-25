using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMnemonic.Domain.Entities
{


    public class Quiz
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public Course Course {get; set;}
        public List<Question> Questions {get; set;} 
        public List<Answer> Answers {get; set;}
        
    }
}