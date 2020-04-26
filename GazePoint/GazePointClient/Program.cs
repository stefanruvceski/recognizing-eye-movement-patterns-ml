using GazePointCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GazePointClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(GazePointService));
            serviceHost.AddServiceEndpoint(typeof(IGazePoint), new NetTcpBinding(), "net.tcp://localhost:11000/IGazePoint");
            serviceHost.Open();
            GazePointTcpClient.StartClient();
            
            Console.ReadKey();
            serviceHost.Close();
            GazePointTcpClient.StopClient();
            
        }
    }
}
