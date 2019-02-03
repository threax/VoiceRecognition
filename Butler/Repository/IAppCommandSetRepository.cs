using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Butler.InputModels;
using Butler.ViewModels;
using Butler.Models;
using Threax.AspNetCore.Halcyon.Ext;

namespace Butler.Repository
{
    public partial interface IAppCommandSetRepository
    {
        Task<AppCommandSet> Add(AppCommandSetInput value);
        Task AddRange(IEnumerable<AppCommandSetInput> values);
        Task Delete(Guid id);
        Task<AppCommandSet> Get(Guid appCommandSetId);
        Task<bool> HasAppCommandSets();
        Task<AppCommandSetCollection> List(AppCommandSetQuery query);
        Task<AppCommandSet> Update(Guid appCommandSetId, AppCommandSetInput value);
    }
}