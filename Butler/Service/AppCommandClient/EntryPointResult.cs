using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Client;

namespace Butler.Service.AppCommand.Client
{
    public class EntryPointResult
    {
        private HalEndpointClient client;

        public static async Task<EntryPointResult> Load(string url, IHttpClientFactory fetcher)
        {
            var result = await HalEndpointClient.Load(new HalLink(url, "GET"), fetcher);
            return new EntryPointResult(result);
        }

        public EntryPointResult(HalEndpointClient client)
        {
            this.client = client;
        }

        public async Task<AppCommandCollectionResult> ListAppCommands(AppCommandQuery data)
        {
            var result = await this.client.LoadLinkWithData("ListAppCommands", data);
            return new AppCommandCollectionResult(result);

        }

        public bool CanListAppCommands
        {
            get
            {
                return this.client.HasLink("ListAppCommands");
            }
        }

        public HalLink LinkForListAppCommands
        {
            get
            {
                return this.client.GetLink("ListAppCommands");
            }
        }

        public async Task<HalEndpointDoc> GetListAppCommandsDocs(HalEndpointDocQuery query = null)
        {
            var result = await this.client.LoadLinkDoc("ListAppCommands", query);
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasListAppCommandsDocs()
        {
            return this.client.HasLinkDoc("ListAppCommands");
        }
    }
}
