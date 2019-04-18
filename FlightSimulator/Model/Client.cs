using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;
using System.Net.Sockets;
using System.Threading;

namespace FlightSimulator.Model
{
    class Client:ITelnetClient
    {
        TcpClient client;
        NetworkStream stream;
        public void connect(string ip, int port)
        {
            client = new TcpClient(ip, port);
            stream = client.GetStream();
        }
        public void write(string data)
        {
            //Thread myThread = new Thread(() => writeOnThread(data));
            //myThread.Start();
            new Thread(delegate ()
            {
                string[] splited = data.Split('\n');
                int i = 0;
                while (i < splited.Length)
                {
                    splited[i] += "\r\n";
                    Byte[] message = System.Text.Encoding.ASCII.GetBytes(splited[i]);

                    stream.Write(message, 0, message.Length);
                    Thread.Sleep(2000);
                    i++;

                }
                stream.Close();
                client.Close();

            }).Start();
            


        }
        private bool ruuning = false;
        private void writeOnThread(string data)
        {
            ruuning = true;




            ruuning = false;
        }

        public string read()
        {
            Byte[] data = new Byte[256];
            
            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            return responseData;
        }
        public void disconnect()
        {
            stream.Close();
            client.Close();
        }
    }
}
