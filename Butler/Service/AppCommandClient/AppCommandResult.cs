using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Client;

namespace Butler.Service.AppCommand.Client
{
    public class AppCommandResult
    {
        private HalEndpointClient client;

        public AppCommandResult(HalEndpointClient client)
        {
            this.client = client;
        }

        private AppCommand strongData = default(AppCommand);
        public AppCommand Data
        {
            get
            {
                if (this.strongData == default(AppCommand))
                {
                    this.strongData = this.client.GetData<AppCommand>();
                }
                return this.strongData;
            }
        }

        public async Task Refresh()
        {
            var result = await this.client.LoadLink("self");
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

        public async Task Execute()
        {
            var result = await this.client.LoadLink("Execute");
        }

        public bool CanExecute
        {
            get
            {
                return this.client.HasLink("Execute");
            }
        }

        public HalLink LinkForExecute
        {
            get
            {
                return this.client.GetLink("Execute");
            }
        }
    }
}
