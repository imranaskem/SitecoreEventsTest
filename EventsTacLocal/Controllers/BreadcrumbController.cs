using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventsTacLocal.Models;
using Sitecore.Collections;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;

namespace EventsTacLocal.Controllers
{
    public class BreadcrumbController : Controller
    {
        // GET: Breadcrumb
        public ActionResult Index()
        {
            var model = this.CreateModel();

            return View(model);
        }

        public IEnumerable<NavigationItem> CreateModel()
        {
            var currentItem = RenderingContext.Current.ContextItem;
            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            var breadcrumb = RenderingContext.Current.ContextItem.Axes.GetAncestors()
                .Where(i => i.Axes.IsDescendantOf(homeItem))
                .Concat(new Item[] { currentItem })
                .ToList();

            IEnumerable<NavigationItem> navigationList = breadcrumb.Select(s => new NavigationItem
            {
                Title = s.DisplayName,
                Url = LinkManager.GetItemUrl(s),
                Active = (s.ID == currentItem.ID)
            });

            return navigationList;
        }
    }
}