using System.Collections.Generic;
using System.Threading.Tasks;

namespace Butler.Service.AppCommand.Client
{
    public interface IAppCommandClient
    {
        Task<IEnumerable<AppCommandResult>> ListAppCommands(AppCommandQuery query);
    }
}