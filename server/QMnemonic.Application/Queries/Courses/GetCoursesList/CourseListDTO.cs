using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Application.Queries.Courses
{
    public class CourseListDTO
    {
        public int CourseId {get; set;}
        public string LanguageCode {get; set;}
        public string Name {get; set;}
        public string ShortDescription {get; set;} 
        public string AuthorId {get; set;}
        public string imageUrl {get; set;} = "https://static.memrise.com/img/400sqf/from/uploads/immersion/shutterstock_686826304.jpg.jpg";
    }
}