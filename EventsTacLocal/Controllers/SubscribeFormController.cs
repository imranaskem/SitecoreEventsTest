using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Analytics;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.Model.Entities;
using Sitecore.Analytics.Outcome.Extensions;
using Sitecore.Analytics.Outcome.Model;
using Sitecore.Common;
using Sitecore.Data;
using TAC.Utils.Mvc;

namespace EventsTacLocal.Controllers
{
    public class SubscribeFormController : Controller
    {
        // GET: SubscribeForm
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateFormHandler]
        public ActionResult Index(string email)
        {
            Tracker.Current.Session.Identify(email);

            var contact = Tracker.Current.Contact;

            var emails = contact.GetFacet<IContactEmailAddresses>("Emails");

            if (!emails.Entries.Contains("personal"))
            {
                emails.Preferred = "personal";

                var personalEmail = emails.Entries.Create("personal");

                personalEmail.SmtpAddress = email;
            }

            var contactOutcome = new ContactOutcome(
                ID.NewID, 
                new ID("{CA865F1D-4787-427B-AD66-5A183B949A02}"), 
                contact.ContactId.ToID());

            Tracker.Current.RegisterContactOutcome(contactOutcome);

            var pageEventData = new PageEventData("Newsletter Signup");

            Tracker.Current.CurrentPage.Register(pageEventData);

            return View("Confirmation");
        }
    }
}