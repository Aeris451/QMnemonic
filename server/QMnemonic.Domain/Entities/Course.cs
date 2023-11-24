using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMnemonic.Domain.Entities
{


    public class Course
    {
        public int Id {get; set;}
        public List<Quiz> Quizzes {get; set;} 
        public List<InteractiveText> InteractiveTexts {get; set;}
        public string Language {get; set;}
        public string Name {get; set;}
    }
}