using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Butler.InputModels;
using Butler.Database;
using Butler.ViewModels;

namespace Butler.Mappers
{
    public partial class AppMapper
    {
        public AppCommandSetEntity MapAppCommandSet(AppCommandSetInput src, AppCommandSetEntity dest)
        {
            return mapper.Map(src, dest);
        }

        public AppCommandSet MapAppCommandSet(AppCommandSetEntity src, AppCommandSet dest)
        {
            return mapper.Map(src, dest);
        }
    }

    public partial class AppCommandSetProfile : Profile
    {
        public AppCommandSetProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<AppCommandSetInput, AppCommandSetEntity>());

            //Map the entity to the view model.
            MapEntityToView(CreateMap<AppCommandSetEntity, AppCommandSet>());
        }

        void MapInputToEntity(IMappingExpression<AppCommandSetInput, AppCommandSetEntity> mapExpr)
        {
            mapExpr.ForMember(d => d.AppCommandSetId, opt => opt.Ignore())
                .ForMember(d => d.Json, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.MapFrom<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.MapFrom<IModifiedResolver>());
        }

        void MapEntityToView(IMappingExpression<AppCommandSetEntity, AppCommandSet> mapExpr)
        {
            
        }
    }
}