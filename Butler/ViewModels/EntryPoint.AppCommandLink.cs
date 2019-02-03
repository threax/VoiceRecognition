using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Butler.Controllers.Api;

namespace Butler.ViewModels
{
    [HalActionLink(typeof(AppCommandLinksController), nameof(AppCommandLinksController.List), "ListAppCommandLinks")]
    [HalActionLink(typeof(AppCommandLinksController), nameof(AppCommandLinksController.Add), "AddAppCommandLink")]
    public partial class EntryPoint
    {
        
    }
}