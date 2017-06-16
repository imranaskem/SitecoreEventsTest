using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventsTacLocal.Areas.Importer.Models;
using Newtonsoft.Json;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;

namespace EventsTacLocal.Areas.Importer.Controllers
{
    public class EventsController : Controller
    {
        // GET: Importer/Events
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string parentPath)
        {
            IEnumerable<Event> events = null;

            string message = null;

            using (var reader = new StreamReader(file.InputStream))
            {
                var contents = reader.ReadToEnd();

                try
                {
                    events = JsonConvert.DeserializeObject<IEnumerable<Event>>(contents);
                }
                catch (Exception e)
                {
                    
                }
            }

            var masterDb = Factory.GetDatabase("master");

            var parentItem = masterDb.GetItem(parentPath);

            var templateId = new TemplateID(new ID("{2B1E4E6D-EA3E-4DEF-91DD-96C2C48AC0EF}"));

            using (new SecurityDisabler())
            {
                foreach (var ev in events)
                {
                    var name = ItemUtil.ProposeValidItemName(ev.ContentHeading);
                    Item item = parentItem.Add(name, templateId);
                    item.Editing.BeginEdit();
                    item["ContentHeading"] = ev.ContentHeading;
                    item["ContentIntro"] = ev.ContentIntro;
                    item["Highlights"] = ev.Highlights;
                    item["Start Date"] = Sitecore.DateUtil.ToIsoDate(ev.StartDate);
                    item["Duration"] = ev.Duration.ToString();
                    item["Difficulty Level"] = ev.Difficulty.ToString();
                    item.Editing.EndEdit();
                }
            }

            return View();
        }
    }
}