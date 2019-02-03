using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Butler.Controllers.Api;

namespace Butler.ViewModels
{
    [HalActionLink(typeof(ValuesController), nameof(ValuesController.List), "ListValues")]
    [HalActionLink(typeof(ValuesController), nameof(ValuesController.Add), "AddValue")]
    public partial class EntryPoint
    {
        
    }
}