using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QMnemonic.Domain.Entities
{
    public class Language
    {
        public int Id {get; set;}
        public string LanguageName {get; set;}
        public string LanguageCode {get; set;}
    }
}