using PiperHome.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: PiperHome.Kinect.Kinect1LibAttribute()]

namespace PiperHome.Kinect
{
    class Kinect1LibAttribute : KinectLibAttribute
    {
        public override KinectSensorManager createSensorManager()
        {
            return new Kinect1SensorManager();
        }
    }
}
