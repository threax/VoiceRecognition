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
    [HalSelfActionLink(typeof(AppCommandSetsController), nameof(AppCommandSetsController.List))]
    [HalActionLink(typeof(AppCommandSetsController), nameof(AppCommandSetsController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(AppCommandSetsController), nameof(AppCommandSetsController.List), DocsOnly = true)] //This provides docs for searching the list
    [HalActionLink(typeof(AppCommandSetsController), nameof(AppCommandSetsController.Update), DocsOnly = true)] //This provides access to docs for updating items if the ui has different modes
    [HalActionLink(typeof(AppCommandSetsController), nameof(AppCommandSetsController.Add))]
    [DeclareHalLink(typeof(AppCommandSetsController), nameof(AppCommandSetsController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(AppCommandSetsController), nameof(AppCommandSetsController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(AppCommandSetsController), nameof(AppCommandSetsController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(AppCommandSetsController), nameof(AppCommandSetsController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class AppCommandSetCollection : PagedCollectionViewWithQuery<AppCommandSet, AppCommandSetQuery>
    {
        public AppCommandSetCollection(AppCommandSetQuery query, int total, IEnumerable<AppCommandSet> items) : base(query, total, items)
        {
            
        }
    }
}