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
    public partial class AppCommandSetQuery : PagedCollectionQuery, IAppCommandSetQuery
    {
        /// <summary>
        /// Lookup a appCommandSet by id.
        /// </summary>
        public Guid? AppCommandSetId { get; set; }

        /// <summary>
        /// Populate an IQueryable. Does not apply the skip or limit.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>The query passed in populated with additional conditions.</returns>
        public Task<IQueryable<AppCommandSetEntity>> Create(IQueryable<AppCommandSetEntity> query)
        {
            if (AppCommandSetId != null)
            {
                query = query.Where(i => i.AppCommandSetId == AppCommandSetId);
            }
            else
            {
                //Customize query further
            }

            return Task.FromResult(query);
        }
    }
}