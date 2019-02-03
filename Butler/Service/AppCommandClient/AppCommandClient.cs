using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butler.Service.AppCommand.Client
{
    public class AppCommandClient : IAppCommandClient
    {
        private AppCommandEntry entryPoint;

        public AppCommandClient(AppCommandEntry entryPoint)
        {
            this.entryPoint = entryPoint;
        }

        public async Task<IEnumerable<AppCommandResult>> ListAppCommands(AppCommandQuery query)
        {
            var entryResult = await entryPoint.Load();
            if (!entryResult.CanListAppCommands)
            {
                throw new InvalidOperationException($"Cannot list app commands for {entryPoint.Url}.");
            }
            var commands = await entryResult.ListAppCommands(query);
            return commands.Items;
        }
    }
}
