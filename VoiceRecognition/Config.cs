using Butler.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Client;

namespace VoiceRecognition
{
    public class Config
    {
        /// <summary>
        /// The hotword that starts commands.
        /// </summary>
        public String Hotword { get; set; } = "collins";

        /// <summary>
        /// The sensitivity of the commands 0-1.
        /// </summary>
        public double Sensitivity { get; set; } = 0.55;

        /// <summary>
        /// The name of the playback device to use or null for the default.
        /// </summary>
        public String PlaybackDeviceName { get; set; }

        /// <summary>
        /// Butler client options.
        /// </summary>
        public ButlerClientOptions ButlerClient { get; set; } = new ButlerClientOptions()
        {
            ServiceUrl = null,
            ClientCredentials = new ClientCredentailsAccessTokenFactoryOptions()
            {
                ClientId = "Butler.Kinect",
                ClientSecret = "notyetdefined",
                IdServerHost = null,
                Scope = "Butler"
            }
        };

        //public int RestartTime { get; set; } = 30;
    }
}
