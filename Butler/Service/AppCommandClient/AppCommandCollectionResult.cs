using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Client;

namespace Butler.Service.AppCommand.Client
{
    public class AppCommandCollectionResult
    {
        private HalEndpointClient client;

        public AppCommandCollectionResult(HalEndpointClient client)
        {
            this.client = client;
        }

        private AppCommandCollection strongData = default(AppCommandCollection);
        public AppCommandCollection Data
        {
            get
            {
                if (this.strongData == default(AppCommandCollection))
                {
                    this.strongData = this.client.GetData<AppCommandCollection>();
                }
                return this.strongData;
            }
        }

        private List<AppCommandResult> itemsStrong = null;
        public List<AppCommandResult> Items
        {
            get
            {
                if (this.itemsStrong == null)
                {
                    var embeds = this.client.GetEmbed("values");
                    var clients = embeds.GetAllClients();
                    this.itemsStrong = new List<AppCommandResult>(clients.Select(i => new AppCommandResult(i)));
                }
                return this.itemsStrong;
            }
        }

        public async Task<AppCommandCollectionResult> Refresh()
        {
            var result = await this.client.LoadLink("self");
            return new AppCommandCollectionResult(result);

        }

        public bool CanRefresh
        {
            get
            {
                return this.client.HasLink("self");
            }
        }

        public HalLink LinkForRefresh
        {
            get
            {
                return this.client.GetLink("self");
            }
        }

        public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null)
        {
            var result = await this.client.LoadLinkDoc("self", query);
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasRefreshDocs()
        {
            return this.client.HasLinkDoc("self");
        }

        public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null)
        {
            var result = await this.client.LoadLinkDoc("Get", query);
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasGetDocs()
        {
            return this.client.HasLinkDoc("Get");
        }

        public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null)
        {
            var result = await this.client.LoadLinkDoc("List", query);
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasListDocs()
        {
            return this.client.HasLinkDoc("List");
        }

        public async Task<AppCommandCollectionResult> Next()
        {
            var result = await this.client.LoadLink("next");
            return new AppCommandCollectionResult(result);

        }

        public bool CanNext
        {
            get
            {
                return this.client.HasLink("next");
            }
        }

        public HalLink LinkForNext
        {
            get
            {
                return this.client.GetLink("next");
            }
        }

        public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null)
        {
            var result = await this.client.LoadLinkDoc("next", query);
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasNextDocs()
        {
            return this.client.HasLinkDoc("next");
        }

        public async Task<AppCommandCollectionResult> Previous()
        {
            var result = await this.client.LoadLink("previous");
            return new AppCommandCollectionResult(result);

        }

        public bool CanPrevious
        {
            get
            {
                return this.client.HasLink("previous");
            }
        }

        public HalLink LinkForPrevious
        {
            get
            {
                return this.client.GetLink("previous");
            }
        }

        public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null)
        {
            var result = await this.client.LoadLinkDoc("previous", query);
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasPreviousDocs()
        {
            return this.client.HasLinkDoc("previous");
        }

        public async Task<AppCommandCollectionResult> First()
        {
            var result = await this.client.LoadLink("first");
            return new AppCommandCollectionResult(result);

        }

        public bool CanFirst
        {
            get
            {
                return this.client.HasLink("first");
            }
        }

        public HalLink LinkForFirst
        {
            get
            {
                return this.client.GetLink("first");
            }
        }

        public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null)
        {
            var result = await this.client.LoadLinkDoc("first", query);
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasFirstDocs()
        {
            return this.client.HasLinkDoc("first");
        }

        public async Task<AppCommandCollectionResult> Last()
        {
            var result = await this.client.LoadLink("last");
            return new AppCommandCollectionResult(result);

        }

        public bool CanLast
        {
            get
            {
                return this.client.HasLink("last");
            }
        }

        public HalLink LinkForLast
        {
            get
            {
                return this.client.GetLink("last");
            }
        }

        public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null)
        {
            var result = await this.client.LoadLinkDoc("last", query);
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasLastDocs()
        {
            return this.client.HasLinkDoc("last");
        }
    }
}
