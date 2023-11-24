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


    public class Language
    {   
        public int Id {get; set;}

        public List<Course> Course {get; set;}
        public string Name {get; set;}


    }
}