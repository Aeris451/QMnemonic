using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QMnemonic.Application.Queries.Quizzes;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Application.Queries.Courses
{
    public class CourseDetailsDTO
    {
        
        public string LanguageName {get; set;}
        public string Name {get; set;}
        public string Description {get; set;} 
        public string AuthorId {get; set;}
        public List<QuizListDTO> Quizzes {get; set;}
        public List<ReadingListDTO> Readings {get; set;}
        
    }
}