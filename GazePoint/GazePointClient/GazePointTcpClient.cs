using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GazePointClient
{
    public class GazePointTcpClient
    {
        const int ServerPort = 4242;
        const string ServerAddr = "127.0.0.1";
        static bool exit_state = false;
        public static void StartClient()
        {
            
            int startindex, endindex;
            TcpClient gp3_client;
            NetworkStream data_feed;
            StreamWriter data_write;
            String incoming_data = "";


            //Try to create client object, return if no server found
            try
            {
                gp3_client = new TcpClient(ServerAddr, ServerPort);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to connect with error: {0}", e);
                return;
            }

            // Load the read and write streams
            data_feed = gp3_client.GetStream();
            data_write = new StreamWriter(data_feed);

            // Setup the data records
            data_write.Write("<SET ID=\"ENABLE_SEND_TIME\" STATE=\"1\" />\r\n");
            data_write.Write("<SET ID=\"ENABLE_SEND_POG_FIX\" STATE=\"1\" />\r\n");
            data_write.Write("<SET ID=\"ENABLE_SEND_CURSOR\" STATE=\"1\" />\r\n");
            data_write.Write("<SET ID=\"ENABLE_SEND_DATA\" STATE=\"1\" />\r\n");

            // Flush the buffer out the socket
            data_write.Flush();

            GazePointService.b.Append("Question,Time,FpogX,FpogY,Valid\n");

            do
            {
                int ch = data_feed.ReadByte();
                if (ch != -1)
                {
                    incoming_data += (char)ch;

                    // find string terminator ("\r\n") 
                    if (incoming_data.IndexOf("\r\n") != -1)
                    {
                        // only process DATA RECORDS, ie <REC .... />
                        if (incoming_data.IndexOf("<REC") != -1)
                        {
                            double time_val = -1;
                double fpogx = -1;
                double fpogy = -1;
                int fpog_valid = -1;

                // Process incoming_data string to extract FPOGX, FPOGY, etc...
                startindex = incoming_data.IndexOf("TIME=\"") + "TIME=\"".Length;
                endindex = incoming_data.IndexOf("\"", startindex);
                time_val = Double.Parse(incoming_data.Substring(startindex, endindex - startindex));

                startindex = incoming_data.IndexOf("FPOGX=\"") + "FPOGX=\"".Length;
                endindex = incoming_data.IndexOf("\"", startindex);
                fpogx = Double.Parse(incoming_data.Substring(startindex, endindex - startindex));

                startindex = incoming_data.IndexOf("FPOGY=\"") + "FPOGY=\"".Length;
                endindex = incoming_data.IndexOf("\"", startindex);
                fpogy = Double.Parse(incoming_data.Substring(startindex, endindex - startindex));

                startindex = incoming_data.IndexOf("FPOGV=\"") + "FPOGV=\"".Length;
                endindex = incoming_data.IndexOf("\"", startindex);
                fpog_valid = Int32.Parse(incoming_data.Substring(startindex, endindex - startindex));

                Console.WriteLine("Raw data: {0}", incoming_data);
                Console.WriteLine("Processed data: Time {0}, Gaze ({1},{2}) Valid={3}", time_val, fpogx, fpogy, fpog_valid);

                if (GazePointService.write_state)
                                GazePointService.b.Append($"{GazePointService.question},{time_val},{fpogx},{fpogy},{fpog_valid}\n");
                        }

                        incoming_data = "";
            }
                }


    }while(exit_state == false);

            data_write.Close();
            data_feed.Close();
            gp3_client.Close();
        }
        public static void StopClient()
        {
            exit_state = true;
            using (StreamWriter sw = File.CreateText(GazePointService.fileName))
            {
                sw.Write(GazePointService.b);
            }
        }
    }
}
