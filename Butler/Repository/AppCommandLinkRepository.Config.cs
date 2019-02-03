using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Threax.ReflectedServices;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Butler.Repository;

namespace Butler.Repository.Config
{
    public partial class AppCommandLinkRepositoryConfig : IServiceSetup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            OnConfigureServices(services);

            services.TryAddScoped<IAppCommandLinkRepository, AppCommandLinkRepository>();
        }

        partial void OnConfigureServices(IServiceCollection services);
    }
}