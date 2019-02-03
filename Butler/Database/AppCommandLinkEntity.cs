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

namespace Butler.Database 
{
    public partial class AppCommandLinkEntity : IAppCommandLink, IAppCommandLinkId, IAppCommandLink_Json, ICreatedModified
    {
        [Key]
        public Guid AppCommandLinkId { get; set; }

        public String Json { get; set; }

        public Guid AppCommandSetId { get; set; }

        public AppCommandSetEntity AppCommandSet { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
