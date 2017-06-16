using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsTacLocal.Models
{
    public class FeaturedEvent
    {
        public HtmlString Heading { get; set; }
        public HtmlString Intro { get; set; }
        public HtmlString EventImage { get; set; }
        public string CssClass { get; set; }
        public string Url { get; set; }

        public FeaturedEvent()
        {
                
        }
    }
}