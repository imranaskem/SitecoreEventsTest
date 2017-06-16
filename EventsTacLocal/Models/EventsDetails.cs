using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Web.UI.WebControls;

namespace EventsTacLocal.Models
{
    public class EventsDetails : SearchResultItem
    {
        public HtmlString ContentHeading => new HtmlString(FieldRenderer.Render(GetItem(), "ContentHeading"));

        public HtmlString ContentIntro => new HtmlString(FieldRenderer.Render(GetItem(), "ContentIntro"));

        public HtmlString EventStartDate => new HtmlString(FieldRenderer.Render(GetItem(), "Start Date"));

        public HtmlString EventImage => new HtmlString(FieldRenderer.Render(GetItem(), "Event Image", "DisableWebEditing=true&mw=150"));
    }
}