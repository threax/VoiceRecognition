using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Butler.Service.AppCommand.Client
{
    public class AppCommandValueProvider : LabelValuePairProvider
    {
        private AppCommandClient entryPoint;

        public AppCommandValueProvider(AppCommandClient entryPoint)
        {
            this.entryPoint = entryPoint;
        }

        protected override async Task<IEnumerable<ILabelValuePair>> GetSources()
        {
            var items = await this.entryPoint.ListAppCommands(new AppCommandQuery()
            {
                Limit = int.MaxValue
            });
            return items.Select(i => new LabelValuePair<Guid>(i.Data.Name, i.Data.AppCommandId));
        }
    }
}
