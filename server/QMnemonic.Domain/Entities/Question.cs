using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QMnemonic.Domain.Entities
{


    public class Question
    {
        public int Id {get; set;}
        public int AnswerId {get; set;}
        public int QuizId {get; set;}
        public Answer Answer {get; set;}
        public string SContent {get; set;}
        public string Content {get; set;}
        public string Annotations {get; set;}
        
    }
}