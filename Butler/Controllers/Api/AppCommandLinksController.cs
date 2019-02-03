using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Butler.Repository;
using Threax.AspNetCore.Halcyon.Ext;
using Butler.ViewModels;
using Butler.InputModels;
using Butler.Models;
using Microsoft.AspNetCore.Authorization;

namespace Butler.Controllers.Api
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer)]
    public partial class AppCommandLinksController : Controller
    {
        private IAppCommandLinkRepository repo;

        public AppCommandLinksController(IAppCommandLinkRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<AppCommandLinkCollection> List([FromQuery] AppCommandLinkQuery query)
        {
            return await repo.List(query);
        }

        [HttpGet("{AppCommandLinkId}")]
        [HalRel(CrudRels.Get)]
        public async Task<AppCommandLink> Get(Guid appCommandLinkId)
        {
            return await repo.Get(appCommandLinkId);
        }

        [HttpPost]
        [HalRel(CrudRels.Add)]
        [AutoValidate("Cannot add new appCommandLink")]
        public async Task<AppCommandLink> Add([FromBody]AppCommandLinkInput appCommandLink)
        {
            return await repo.Add(appCommandLink);
        }

        [HttpPut("{AppCommandLinkId}")]
        [HalRel(CrudRels.Update)]
        [AutoValidate("Cannot update appCommandLink")]
        public async Task<AppCommandLink> Update(Guid appCommandLinkId, [FromBody]AppCommandLinkInput appCommandLink)
        {
            return await repo.Update(appCommandLinkId, appCommandLink);
        }

        [HttpDelete("{AppCommandLinkId}")]
        [HalRel(CrudRels.Delete)]
        public async Task Delete(Guid appCommandLinkId)
        {
            await repo.Delete(appCommandLinkId);
        }
    }
}