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
        public Reading Reading {get; set;}
        public string OrgContent {get; set;}
        public string ConvContent {get; set;}
    }
}