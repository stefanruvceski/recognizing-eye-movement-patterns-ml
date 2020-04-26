using GazePointCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazePointClient
{
    class GazePointService : IGazePoint
    {
        public static StringBuilder b = new StringBuilder();
        public static bool write_state = false;
        public static string fileName = "stefan.csv";
        public static int question;
        public static int answer;
        public void StartRecording(int q)
        {
            try
            {
                question = q;
                write_state = true;
                Console.WriteLine("Start Recording.");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void StopRecording(int a)
        {
            try
            {
                answer = a;
                b.Append("Answer,"+answer + "\n");
                write_state = false;
                GazePointTcpClient.StopClient();
                Console.WriteLine("Stop Recording.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ChangeQuestion(int ans, int q)
        {
            try
            {
                question = q;
                answer = ans;
                b.Append(answer + "\n");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
