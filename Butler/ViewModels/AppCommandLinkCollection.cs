using Halcyon.HAL.Attributes;
using Butler.Controllers.Api;
using Butler.Models;
using Butler.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;

namespace Butler.ViewModels
{
    [HalModel]
    [HalSelfActionLink(typeof(AppCommandLinksController), nameof(AppCommandLinksController.List))]
    [HalActionLink(typeof(AppCommandLinksController), nameof(AppCommandLinksController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(AppCommandLinksController), nameof(AppCommandLinksController.List), DocsOnly = true)] //This provides docs for searching the list
    [HalActionLink(typeof(AppCommandLinksController), nameof(AppCommandLinksController.Update), DocsOnly = true)] //This provides access to docs for updating items if the ui has different modes
    [HalActionLink(typeof(AppCommandLinksController), nameof(AppCommandLinksController.Add))]
    [DeclareHalLink(typeof(AppCommandLinksController), nameof(AppCommandLinksController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(AppCommandLinksController), nameof(AppCommandLinksController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(AppCommandLinksController), nameof(AppCommandLinksController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(AppCommandLinksController), nameof(AppCommandLinksController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class AppCommandLinkCollection : PagedCollectionViewWithQuery<AppCommandLink, AppCommandLinkQuery>
    {
        public AppCommandLinkCollection(AppCommandLinkQuery query, int total, IEnumerable<AppCommandLink> items) : base(query, total, items)
        {
            
        }
    }
}