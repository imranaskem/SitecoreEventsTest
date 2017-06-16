using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsTacLocal.Models
{
    public class OverviewList : List<OverviewItem>
    {
        public string ReadMore { get; set; }
    }
}