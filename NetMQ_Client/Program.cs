using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetMQ;
using NetMQ.Sockets;

namespace NetMQ_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NetMQSocket clientSocket = new RequestSocket())
            {
                Random rd = new Random();
                int num = rd.Next(0, 100);
                clientSocket.Connect("tcp://127.0.0.1:5555");
                while (true)
                {
                    Console.WriteLine(num + ",Please enter your message:");
                    string message = Console.ReadLine();
                    clientSocket.SendFrame(num + ":" + message);

                    string answer = clientSocket.ReceiveFrameString();

                    Console.WriteLine("Answer from server:{0}", answer);

                    if (message == "exit")
                    {
                        break;
                    }
                }
            }
        }
    }
}
