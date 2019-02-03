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
using Butler.Service.AppCommand.Client;

namespace Butler.Controllers.Api
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer)]
    public partial class AppCommandSetsController : Controller
    {
        private IAppCommandSetRepository repo;

        public AppCommandSetsController(IAppCommandSetRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<AppCommandSetCollection> List([FromQuery] AppCommandSetQuery query)
        {
            return await repo.List(query);
        }

        [HttpGet("{AppCommandSetId}")]
        [HalRel(CrudRels.Get)]
        public async Task<AppCommandSet> Get(Guid appCommandSetId)
        {
            return await repo.Get(appCommandSetId);
        }

        [HttpPost("[action]/{AppCommandSetId}")]
        [HalRel(nameof(Execute))]
        public async Task<EntryPoint> Execute(Guid appCommandSetId, [FromServices] IAppCommandHalClientFactory halClientFactory)
        {
            await repo.Execute(appCommandSetId, halClientFactory);
            return new EntryPoint(); //Have to return something, need to fix this bug
        }

        [HttpPost]
        [HalRel(CrudRels.Add)]
        [AutoValidate("Cannot add new appCommandSet")]
        [Authorize(Roles = Roles.EditCommands)]
        public async Task<AppCommandSet> Add([FromBody]AppCommandSetInput appCommandSet)
        {
            return await repo.Add(appCommandSet);
        }

        [HttpPut("{AppCommandSetId}")]
        [HalRel(CrudRels.Update)]
        [AutoValidate("Cannot update appCommandSet")]
        [Authorize(Roles = Roles.EditCommands)]
        public async Task<AppCommandSet> Update(Guid appCommandSetId, [FromBody]AppCommandSetInput appCommandSet)
        {
            return await repo.Update(appCommandSetId, appCommandSet);
        }

        [HttpDelete("{AppCommandSetId}")]
        [HalRel(CrudRels.Delete)]
        [Authorize(Roles = Roles.EditCommands)]
        public async Task Delete(Guid appCommandSetId)
        {
            await repo.Delete(appCommandSetId);
        }
    }
}