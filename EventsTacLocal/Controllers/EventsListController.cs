﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventsTacLocal.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.Mvc.Presentation;

namespace EventsTacLocal.Controllers
{
    public class EventsListController : Controller
    {
        private const int PageSize = 4;
        
        // GET: EventsList
        public ActionResult Index(int page = 1)
        {
            var contextItem = RenderingContext.Current.ContextItem;

            var model = new EventsList();

            var databaseName = contextItem.Database.Name.ToLower();

            var index = ContentSearchManager.GetIndex($"events_{databaseName}_index");

            using (var context = index.CreateSearchContext())
            {
                var results = context.GetQueryable<EventsDetails>()
                    .Where(i => i.Paths.Contains(contextItem.ID)
                                && i.Language == contextItem.Language.Name)
                    .Page(page - 1, PageSize)
                    .GetResults();

                model.Events = results.Hits.Select(h => h.Document).ToList();
                model.TotalResultCount = results.TotalSearchResults;
                model.PageSize = PageSize;
            }

            return View(model);
        }
    }
}