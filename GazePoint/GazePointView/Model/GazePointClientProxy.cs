using GazePointCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GazePointView.Model
{
    static class GazePointClientProxy
    {
        static IGazePoint proxy = new ChannelFactory<IGazePoint>(new NetTcpBinding(), "net.tcp://localhost:11000/IGazePoint").CreateChannel();

        

        public static void StartRecording( int question)
        {
            try
            {
                proxy.StartRecording(question);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public static void StopRecording(int answer)
        {
            try
            {
                proxy.StopRecording(answer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void ChangeQuestion(int a,int q)
        {
            try
            {
                proxy.ChangeQuestion(a,q);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
