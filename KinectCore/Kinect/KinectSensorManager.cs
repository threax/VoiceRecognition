using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PiperHome.Kinect
{
    public interface KinectSensorManager : IDisposable
    {
        event Action<KinectSensorManager> SensorConnected;

        event Action<KinectSensorManager> SensorDisconnected;

        void initialize();

        Stream startAudioSource();

        String Type { get; }
    }
}
