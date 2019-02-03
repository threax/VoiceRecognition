using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Butler.Client;
using System;
using Threax.AspNetCore.AuthCore;
using Threax.AspNetCore.Halcyon.Client;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        /// <summary>
        /// Add the AppTemplate setup to use client credentials to connect to the service.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configure">The configure callback.</param>
        /// <returns></returns>
        public static IServiceCollection AddAppTemplateWithClientCredentials(this IServiceCollection services, Action<ButlerClientOptions> configure)
        {
            var options = new ButlerClientOptions();
            configure?.Invoke(options);

            var sharedCredentials = new SharedClientCredentials();
            options.GetSharedClientCredentials?.Invoke(sharedCredentials);
            sharedCredentials.MergeWith(options.ClientCredentials);

            services.TryAddSingleton<IHttpClientFactory, DefaultHttpClientFactory>();
            services.TryAddSingleton<IHttpClientFactory<EntryPointInjector>>(s =>
            {
                return new ClientCredentialsAccessTokenFactory<EntryPointInjector>(options.ClientCredentials, new BearerHttpClientFactory<EntryPointInjector>(s.GetRequiredService<IHttpClientFactory>()));
            });
            services.TryAddScoped<EntryPointInjector>(s =>
            {
                return new EntryPointInjector(options.ServiceUrl, s.GetRequiredService<IHttpClientFactory<EntryPointInjector>>());
            });

            return services;
        }
    }
}
