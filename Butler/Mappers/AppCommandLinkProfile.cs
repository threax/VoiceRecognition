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
        public AppCommandLinkEntity MapAppCommandLink(AppCommandLinkInput src, AppCommandLinkEntity dest)
        {
            return mapper.Map(src, dest);
        }

        public AppCommandLink MapAppCommandLink(AppCommandLinkEntity src, AppCommandLink dest)
        {
            return mapper.Map(src, dest);
        }
    }

    public partial class AppCommandLinkProfile : Profile
    {
        public AppCommandLinkProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<AppCommandLinkInput, AppCommandLinkEntity>());

            //Map the entity to the view model.
            MapEntityToView(CreateMap<AppCommandLinkEntity, AppCommandLink>());
        }

        void MapInputToEntity(IMappingExpression<AppCommandLinkInput, AppCommandLinkEntity> mapExpr)
        {
            mapExpr.ForMember(d => d.AppCommandLinkId, opt => opt.Ignore())
                .ForMember(d => d.Json, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.MapFrom<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.MapFrom<IModifiedResolver>());
        }

        void MapEntityToView(IMappingExpression<AppCommandLinkEntity, AppCommandLink> mapExpr)
        {
            
        }
    }
}