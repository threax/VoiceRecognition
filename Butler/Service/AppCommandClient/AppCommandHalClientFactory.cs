using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Client;

namespace Butler.Service.AppCommand.Client
{
    public class AppCommandHalClientFactory : IAppCommandHalClientFactory
    {
        private IHttpClientFactory httpClientFactory;

        public AppCommandHalClientFactory(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public Task<HalEndpointClient> Load(HalLink link)
        {
            return HalEndpointClient.Load(link, this.httpClientFactory);
        }
    }
}
