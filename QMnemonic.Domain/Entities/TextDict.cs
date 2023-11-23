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


    public class Text
    {   
        public int Id {get; set;}
        public InteractiveText InteractiveText {get; set;}

        public string Content {get; set;}


    }
}