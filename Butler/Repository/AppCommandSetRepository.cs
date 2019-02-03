using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Butler.Database;
using Butler.InputModels;
using Butler.ViewModels;
using Butler.Models;
using Butler.Mappers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Butler.Service.AppCommand.Client;
using Newtonsoft.Json;
using Threax.AspNetCore.Halcyon.Client;
using Microsoft.AspNetCore.Mvc;

namespace Butler.Repository
{
    public partial class AppCommandSetRepository : IAppCommandSetRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;
        private IAppCommandClient commandClient;

        public AppCommandSetRepository(AppDbContext dbContext, AppMapper mapper, IAppCommandClient commandClient)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.commandClient = commandClient;
        }

        public async Task<AppCommandSetCollection> List(AppCommandSetQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var results = await dbQuery.ToListAsync();

            return new AppCommandSetCollection(query, total, results.Select(i => mapper.MapAppCommandSet(i, new AppCommandSet())));
        }

        public async Task<AppCommandSet> Get(Guid appCommandSetId)
        {
            var entity = await this.Entity(appCommandSetId);
            return mapper.MapAppCommandSet(entity, new AppCommandSet());
        }

        public async Task Execute(Guid appCommandSetId, IAppCommandHalClientFactory halClientFactory)
        {
            var entity = await this.Entity(appCommandSetId);
            var link = JsonConvert.DeserializeObject<HalLink>(entity.Json);
            var client = await halClientFactory.Load(link);
        }

        public async Task<AppCommandSet> Add(AppCommandSetInput appCommandSet)
        {
            var entity = mapper.MapAppCommandSet(appCommandSet, new AppCommandSetEntity(), JsonConvert.SerializeObject(await GetLink(appCommandSet)));
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.MapAppCommandSet(entity, new AppCommandSet());
        }

        public async Task<AppCommandSet> Update(Guid appCommandSetId, AppCommandSetInput appCommandSet)
        {
            var entity = await this.Entity(appCommandSetId);
            if (entity != null)
            {
                mapper.MapAppCommandSet(appCommandSet, entity, JsonConvert.SerializeObject(await GetLink(appCommandSet)));
                await SaveChanges();
                return mapper.MapAppCommandSet(entity, new AppCommandSet());
            }
            throw new KeyNotFoundException($"Cannot find appCommandSet {appCommandSetId.ToString()}");
        }

        public async Task Delete(Guid id)
        {
            var entity = await this.Entity(id);
            if (entity != null)
            {
                dbContext.AppCommandSets.Remove(entity);
                await SaveChanges();
            }
        }

        public virtual async Task<bool> HasAppCommandSets()
        {
            return await Entities.CountAsync() > 0;
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private IQueryable<AppCommandSetEntity> Entities
        {
            get
            {
                return dbContext.AppCommandSets;
            }
        }

        private Task<AppCommandSetEntity> Entity(Guid appCommandSetId)
        {
            return Entities.Where(i => i.AppCommandSetId == appCommandSetId).FirstOrDefaultAsync();
        }

        private async Task<Threax.AspNetCore.Halcyon.Client.HalLink> GetLink(AppCommandSetInput appCommandSet)
        {
            var command = (await commandClient.ListAppCommands(new AppCommandQuery()
            {
                AppCommandId = appCommandSet.AppCommandId,
                Limit = 1
            })).First();
            var link = command.LinkForExecute;
            return link;
        }
    }
}