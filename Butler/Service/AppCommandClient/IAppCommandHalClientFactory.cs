using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Client;

namespace Butler.Service.AppCommand.Client
{
    /// <summary>
    /// This factory allows links to be visited using the credentials from the app command setup.
    /// </summary>
    public interface IAppCommandHalClientFactory
    {
        Task<HalEndpointClient> Load(HalLink link);
    }
}