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

    }
}
