using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiperHome.Kinect
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public abstract class KinectLibAttribute : Attribute
    {
        public abstract KinectSensorManager createSensorManager();
    }
}
