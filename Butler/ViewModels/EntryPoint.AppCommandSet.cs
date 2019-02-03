using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Butler.Controllers.Api;

namespace Butler.ViewModels
{
    [HalActionLink(typeof(AppCommandSetsController), nameof(AppCommandSetsController.List), "ListAppCommandSets")]
    [HalActionLink(typeof(AppCommandSetsController), nameof(AppCommandSetsController.Add), "AddAppCommandSet")]
    public partial class EntryPoint
    {
        
    }
}