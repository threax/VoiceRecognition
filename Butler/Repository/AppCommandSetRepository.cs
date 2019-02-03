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

namespace Butler.Repository
{
    public partial class AppCommandSetRepository : IAppCommandSetRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;

        public AppCommandSetRepository(AppDbContext dbContext, AppMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
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

        public async Task<AppCommandSet> Add(AppCommandSetInput appCommandSet)
        {
            var entity = mapper.MapAppCommandSet(appCommandSet, new AppCommandSetEntity());
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.MapAppCommandSet(entity, new AppCommandSet());
        }

        public async Task<AppCommandSet> Update(Guid appCommandSetId, AppCommandSetInput appCommandSet)
        {
            var entity = await this.Entity(appCommandSetId);
            if (entity != null)
            {
                mapper.MapAppCommandSet(appCommandSet, entity);
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

        public virtual async Task AddRange(IEnumerable<AppCommandSetInput> appCommandSets)
        {
            var entities = appCommandSets.Select(i => mapper.MapAppCommandSet(i, new AppCommandSetEntity()));
            this.dbContext.AppCommandSets.AddRange(entities);
            await SaveChanges();
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private IQueryable<AppCommandSetEntity> Entities
        {
            get
            {
                return dbContext.AppCommandSets.Include(i => i.AppCommandLinks);
            }
        }

        private Task<AppCommandSetEntity> Entity(Guid appCommandSetId)
        {
            return Entities.Where(i => i.AppCommandSetId == appCommandSetId).FirstOrDefaultAsync();
        }
    }
}