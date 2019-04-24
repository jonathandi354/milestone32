using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace FlightSimulator.Model
{
    class Client:ITelnetClient
    {
        /*TcpClient client;
        NetworkStream stream;
        Stream s;
        public void connect(string ip, int port)
        {
            //client = new TcpClient(ip, port);
            //stream = client.GetStream();
            s = client.GetStream();
        }*/
        public void write(string data, string ip, int port)
        {
            //Thread myThread = new Thread(() => writeOnThread(data));
            //myThread.Start();
            new Thread(delegate ()
            {
                TcpClient client = new TcpClient(ip, port);
                NetworkStream stream = client.GetStream();
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
        private bool running = false;
        public void writeOne(string str, string ip, int port)
        {
            Thread myThread = new Thread(() => writeOnThread(str, ip, port));
            if (!running)
            {
                myThread.Start();
            }
            

        }
        
        private void writeOnThread(string str, string ip, int port)
        {
            running = true;
            TcpClient client = new TcpClient(ip, port);
            NetworkStream stream = client.GetStream();
            string copy = str;
            copy += "\r\n";
            Byte[] message = System.Text.Encoding.ASCII.GetBytes(copy);
            
            stream.Write(message, 0, message.Length);
            stream.Close();
            client.Close();
            


            running = false;
        }

        /*public string read()
        {
            Byte[] data = new Byte[256];
            
            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            return responseData;
        }*/
        /*public void disconnect()
        {
            //stream.Dispose();
           // stream.Close();
            client.Close();
        }*/
    }
}
