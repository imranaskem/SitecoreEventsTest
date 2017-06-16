using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsTacLocal.Models
{
    public class OverviewItem
    {
        public HtmlString Title { get; set; }
        public HtmlString Image { get; set; }
        public string Url { get; set; }
    }
}