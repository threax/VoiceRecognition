using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Client;

namespace Butler.Service.AppCommand.Client
{
    public class AppCommandEntry
    {
        private string url;
        private IHttpClientFactory fetcher;
        private Task<EntryPointResult> instanceTask = default(Task<EntryPointResult>);

        public AppCommandEntry(string url, IHttpClientFactory fetcher)
        {
            this.url = url;
            this.fetcher = fetcher;
        }

        public String Url => url;

        public Task<EntryPointResult> Load()
        {
            if (this.instanceTask == default(Task<EntryPointResult>))
            {
                this.instanceTask = EntryPointResult.Load(this.url, this.fetcher);
            }
            return this.instanceTask;
        }
    }
}
