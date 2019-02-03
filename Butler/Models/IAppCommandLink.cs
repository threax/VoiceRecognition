using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;

namespace Butler.Models 
{
    public partial interface IAppCommandLink 
    {
        Guid AppCommandId { get; set; }

    }

    public partial interface IAppCommandLink_Json
    {
        String Json { get; set; }

    }

    public partial interface IAppCommandLinkId
    {
        Guid AppCommandLinkId { get; set; }
    }    

    public partial interface IAppCommandLinkQuery
    {
        Guid? AppCommandLinkId { get; set; }

    }
}