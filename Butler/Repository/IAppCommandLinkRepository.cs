using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Butler.InputModels;
using Butler.ViewModels;
using Butler.Models;
using Threax.AspNetCore.Halcyon.Ext;

namespace Butler.Repository
{
    public partial interface IAppCommandLinkRepository
    {
        Task<AppCommandLink> Add(AppCommandLinkInput value);
        Task AddRange(IEnumerable<AppCommandLinkInput> values);
        Task Delete(Guid id);
        Task<AppCommandLink> Get(Guid appCommandLinkId);
        Task<bool> HasAppCommandLinks();
        Task<AppCommandLinkCollection> List(AppCommandLinkQuery query);
        Task<AppCommandLink> Update(Guid appCommandLinkId, AppCommandLinkInput value);
    }
}