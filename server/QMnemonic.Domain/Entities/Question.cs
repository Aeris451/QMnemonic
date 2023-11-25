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
        public Quiz Quiz {get; set;}
        public string Content {get; set;}
        public List<string> Adnotations {get; set;}
        public List<int> CorrectAnswerIds { get; set; }


    }
}