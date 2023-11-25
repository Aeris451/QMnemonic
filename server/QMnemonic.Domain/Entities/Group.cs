using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QMnemonic.Domain.Identity;
using QMnemonic.Domain.VO;


namespace QMnemonic.Domain.Entities
{


    public class Group : Statistics
    {   
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;} = String.Empty;
        public List<Course> Courses {get; set;} 
        public int AuthorId {get; set;}
        public List<int> MembersId {get; set;}

    }
}