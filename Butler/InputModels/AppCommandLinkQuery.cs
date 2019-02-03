using Halcyon.HAL.Attributes;
using Butler.Controllers;
using Butler.Models;
using Butler.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;
using Threax.AspNetCore.Models;
using System.ComponentModel.DataAnnotations;

namespace Butler.InputModels
{
    [HalModel]
    public partial class AppCommandLinkQuery : PagedCollectionQuery, IAppCommandLinkQuery
    {
        /// <summary>
        /// Lookup a appCommandLink by id.
        /// </summary>
        public Guid? AppCommandLinkId { get; set; }

        /// <summary>
        /// Populate an IQueryable. Does not apply the skip or limit.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>The query passed in populated with additional conditions.</returns>
        public Task<IQueryable<AppCommandLinkEntity>> Create(IQueryable<AppCommandLinkEntity> query)
        {
            if (AppCommandLinkId != null)
            {
                query = query.Where(i => i.AppCommandLinkId == AppCommandLinkId);
            }
            else
            {
                //Customize query further
            }

            return Task.FromResult(query);
        }
    }
}