using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Butler.Models;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Butler.InputModels 
{
    [HalModel]
    public partial class AppCommandLinkInput : IAppCommandLink
    {
        [ValueProvider(typeof(Butler.Service.AppCommand.Client.AppCommandValueProvider))]
        public Guid AppCommandId { get; set; }
    }
}
