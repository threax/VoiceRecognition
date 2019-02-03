using PiperHome.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: PiperHome.Kinect.Kinect2LibAttribute()]

namespace PiperHome.Kinect
{
    class Kinect2LibAttribute : KinectLibAttribute
    {
        public override KinectSensorManager createSensorManager()
        {
            return new Kinect2SensorManager();
        }
    }
}
