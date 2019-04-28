using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;
using System.Net.Sockets;
using System.IO;
using FlightSimulator.ViewModels;
using System.Threading;

namespace FlightSimulator.Model
{
    class InfoModel : AFlightGearInfoModel
    {
        

        override public void Connect(IPAddress ip, int port)
        {
            new Thread(() =>
            {
                IPEndPoint ep = new IPEndPoint(ip, port);
                TcpListener listener = new TcpListener(ep);
                while(true)
                {
                    listener.Start();

                    TcpClient client = listener.AcceptTcpClient();

                    using (NetworkStream stream = client.GetStream())
                    using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                    {
                        while (true)
                        {
                            string line = "";
                            line = reader.ReadLine();
                            while (line != null)
                            {
                                List<string> values = line.Split(',').ToList<string>();
                                Lon = Convert.ToDouble(values[0]);
                                Lat = Convert.ToDouble(values[1]);
                                line = reader.ReadLine();
                            }
                        }
                        //int x = 0;
                        /*
                        while (true)
                        {
                            x++;
                            byte[] allData = reader.ReadBytes(1024);
                            //reader.ReadString();
                            string line = System.Text.Encoding.Default.GetString(allData);
                            List<string> values = line.Split(',').ToList<string>();
                            Lon = Convert.ToDouble(values[0]);
                            Lat = Convert.ToDouble(values[1]);

                        }
                        */
                    }
                    client.Close();
                }
                listener.Stop();

            }).Start();

            

        }
    }
}
