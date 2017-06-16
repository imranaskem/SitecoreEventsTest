using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Links;

namespace TAC.Utils.Search
{
    class UrlComputedField : AbstractComputedIndexField
    {
        public override object ComputeFieldValue(IIndexable indexable)
        {
            var sitecoreIndexable = (SitecoreIndexableItem) indexable;

            var item = sitecoreIndexable.Item;

            if (item == null)
            {
                return null;
            }

            var urlOptions = LinkManager.GetDefaultUrlOptions();
            urlOptions.SiteResolving = true;

            var url = LinkManager.GetItemUrl(item, urlOptions);

            return url;
        }
    }
}
