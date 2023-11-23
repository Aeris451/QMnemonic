using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMnemonic.Domain.Entities
{


    public class InteractiveText
    {   
        public int Id {get; set;}
        public Course Course {get; set;}
        public List<Text> Texts {get; set;}


    }
}