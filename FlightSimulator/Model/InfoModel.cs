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
                listener.Start();
                while (true)
                {
                    

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
              
                    }
                    client.Close();
                }
                listener.Stop();

            }).Start();

            

        }
    }
}
