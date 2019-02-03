using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Butler.Models;
using Butler.Controllers.Api;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Butler.ViewModels 
{
    [HalModel]
    [HalSelfActionLink(typeof(AppCommandSetsController), nameof(AppCommandSetsController.Get))]
    [HalActionLink(typeof(AppCommandSetsController), nameof(AppCommandSetsController.Update))]
    [HalActionLink(typeof(AppCommandSetsController), nameof(AppCommandSetsController.Delete))]
    public partial class AppCommandSet : IAppCommandSet, IAppCommandSetId, ICreatedModified
    {
        public Guid AppCommandSetId { get; set; }

        public String Name { get; set; }

        public String VoicePrompt { get; set; }

        public String Response { get; set; }

        public String Key { get; set; }

        public KeyModifier MyProperty { get; set; }

        public List<Guid> AppCommandLinkIds { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

    }
}
