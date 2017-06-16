using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsTacLocal.Models
{
    public class EventsList
    {
        public IEnumerable<EventsDetails> Events { get; set; }
        public int TotalResultCount { get; set; }
        public int PageSize { get; set; }
    }
}