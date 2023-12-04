using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMnemonic.Domain.Entities
{


    public class Quiz
    {
        public int Id {get; set;}
        public int CourseId {get; set;}
        public int Order {get; set;} = 0;
        public string Name {get; set;}
        public string Description {get; set;}
        public List<string> SelectableContent {get; set;} = new List<string>();
        public List<Question> Questions {get; set;}  = new List<Question>();
        public List<Answer> Answers {get; set;} = new List<Answer>();
        
    }
}