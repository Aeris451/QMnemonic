using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Application.Queries.Courses
{
    public class CourseListDTO
    {
        
        public string Language {get; set;}
        public string Name {get; set;}
        public string Description {get; set;} 
        public string AuthorName {get; set;}
    }
}