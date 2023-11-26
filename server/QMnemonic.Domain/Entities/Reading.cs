using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QMnemonic.Domain.Entities
{


    public class Reading
    {   
        public int Id {get; set;}
        public int CourseId {get; set;}
        public string Name {get; set;}
        public Course Course {get; set;}
        public List<Text> Texts {get; set;} = new List<Text>();

    }
}