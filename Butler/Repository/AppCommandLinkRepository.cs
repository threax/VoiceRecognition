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
    public partial class AppCommandLinkRepository : IAppCommandLinkRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;

        public AppCommandLinkRepository(AppDbContext dbContext, AppMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<AppCommandLinkCollection> List(AppCommandLinkQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var results = await dbQuery.ToListAsync();

            return new AppCommandLinkCollection(query, total, results.Select(i => mapper.MapAppCommandLink(i, new AppCommandLink())));
        }

        public async Task<AppCommandLink> Get(Guid appCommandLinkId)
        {
            var entity = await this.Entity(appCommandLinkId);
            return mapper.MapAppCommandLink(entity, new AppCommandLink());
        }

        public async Task<AppCommandLink> Add(AppCommandLinkInput appCommandLink)
        {
            var entity = mapper.MapAppCommandLink(appCommandLink, new AppCommandLinkEntity());
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.MapAppCommandLink(entity, new AppCommandLink());
        }

        public async Task<AppCommandLink> Update(Guid appCommandLinkId, AppCommandLinkInput appCommandLink)
        {
            var entity = await this.Entity(appCommandLinkId);
            if (entity != null)
            {
                mapper.MapAppCommandLink(appCommandLink, entity);
                await SaveChanges();
                return mapper.MapAppCommandLink(entity, new AppCommandLink());
            }
            throw new KeyNotFoundException($"Cannot find appCommandLink {appCommandLinkId.ToString()}");
        }

        public async Task Delete(Guid id)
        {
            var entity = await this.Entity(id);
            if (entity != null)
            {
                Entities.Remove(entity);
                await SaveChanges();
            }
        }

        public virtual async Task<bool> HasAppCommandLinks()
        {
            return await Entities.CountAsync() > 0;
        }

        public virtual async Task AddRange(IEnumerable<AppCommandLinkInput> appCommandLinks)
        {
            var entities = appCommandLinks.Select(i => mapper.MapAppCommandLink(i, new AppCommandLinkEntity()));
            this.dbContext.AppCommandLinks.AddRange(entities);
            await SaveChanges();
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private DbSet<AppCommandLinkEntity> Entities
        {
            get
            {
                return dbContext.AppCommandLinks;
            }
        }

        private Task<AppCommandLinkEntity> Entity(Guid appCommandLinkId)
        {
            return Entities.Where(i => i.AppCommandLinkId == appCommandLinkId).FirstOrDefaultAsync();
        }
    }
}