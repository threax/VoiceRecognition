using Butler.Service.AppCommand.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Client;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        public static IServiceCollection AddCommandClient(this IServiceCollection services, Action<AppCommandClientConfig> configure)
        {
            var client = new AppCommandClientConfig();
            configure.Invoke(client);

            var sharedCredentials = new SharedClientCredentials();
            client.GetSharedClientCredentials?.Invoke(sharedCredentials);
            sharedCredentials.MergeWith(client.ClientCredentials);

            services.TryAddSingleton<IHttpClientFactory, DefaultHttpClientFactory>();

            services.TryAddScoped<AppCommandEntry>(s =>
            {
                var clientCredsFactory = new ClientCredentialsAccessTokenFactory<AppCommandEntry>(client.ClientCredentials, new BearerHttpClientFactory<AppCommandEntry>(s.GetRequiredService<IHttpClientFactory>()));
                return new AppCommandEntry(client.ServiceUrl, clientCredsFactory);
            });

            services.TryAddScoped<IAppCommandClient, AppCommandClient>();
            services.TryAddScoped<AppCommandValueProvider>();

            return services;
        }
    }
}
