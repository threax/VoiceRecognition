using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Butler.InputModels;
using Butler.ViewModels;
using Butler.Models;
using Threax.AspNetCore.Halcyon.Ext;
using Butler.Service.AppCommand.Client;

namespace Butler.Repository
{
    public partial interface IAppCommandSetRepository
    {
        Task<AppCommandSet> Add(AppCommandSetInput value);
        Task Delete(Guid id);
        Task<AppCommandSet> Get(Guid appCommandSetId);
        Task Execute(Guid appCommandSetId, IAppCommandHalClientFactory halClientFactory);
        Task<bool> HasAppCommandSets();
        Task<AppCommandSetCollection> List(AppCommandSetQuery query);
        Task<AppCommandSet> Update(Guid appCommandSetId, AppCommandSetInput value);
    }
}