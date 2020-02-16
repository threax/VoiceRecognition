using Butler.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Client.OpenIdConnect;

namespace VoiceRecognition
{
    public class ButlerClientOptionsVoiceRecognition : ButlerClientOptions
    {
        /// <summary>
        /// The options when using ClientCredentials, otherwise ignored.
        /// </summary>
        public ClientCredentailsAccessTokenFactoryOptions ClientCredentials { get; set; } = new ClientCredentailsAccessTokenFactoryOptions();
    }
}
