using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PiperHome.Kinect
{
    class KinectMultiSensorManager : KinectSensorManager
    {
        private KinectSensorManager activeSensor = null;
        private object activeSensorLock = new object();
        private List<KinectSensorManager> managers = new List<KinectSensorManager>(2);

        public event Action<KinectSensorManager> SensorConnected;
        public event Action<KinectSensorManager> SensorDisconnected;

        public KinectMultiSensorManager()
        {
            loadKinectLib("Kinect1Lib.dll");
            loadKinectLib("Kinect2Lib.dll");

            foreach(var manager in managers)
            {
                manager.SensorConnected += Manager_SensorConnected;
                manager.SensorDisconnected += Manager_SensorDisconnected;
            }
        }

        public void Dispose()
        {
            managers.ForEach(i => i.Dispose());
            managers.Clear();
        }

        private void loadKinectLib(String path)
        {
            try
            {
                path = Path.GetFullPath(path);
                Assembly assembly = Assembly.LoadFile(path);
                KinectLibAttribute[] attributes = (KinectLibAttribute[])assembly.GetCustomAttributes(typeof(KinectLibAttribute), true);
                managers.Add(attributes[0].createSensorManager());
            }
            catch (Exception) { }
        }

        public string Type
        {
            get
            {
                if(activeSensor != null)
                {
                    return activeSensor.Type;
                }
                return "Multi Version - No type found";
            }
        }

        public void initialize()
        {
            managers.ForEach(i => i.initialize());
        }

        public Stream startAudioSource()
        {
            if(activeSensor != null)
            {
                return activeSensor.startAudioSource();
            }
            else
            {
                throw new Exception("No active sensor found. Please wait for connection event.");
            }
        }

        private void Manager_SensorDisconnected(KinectSensorManager obj)
        {
            lock (activeSensorLock)
            {
                if (activeSensor == obj)
                {
                    if (SensorDisconnected != null)
                    {
                        SensorDisconnected.Invoke(this);
                    }
                    activeSensor = null;
                }
            }
        }

        private void Manager_SensorConnected(KinectSensorManager obj)
        {
            lock (activeSensorLock)
            {
                if (activeSensor == null)
                {
                    activeSensor = obj;
                    if(SensorConnected != null)
                    {
                        SensorConnected.Invoke(this);
                    }
                }
            }
        }
    }
}
