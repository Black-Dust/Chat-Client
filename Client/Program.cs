using System;
using System.IO;
using System.Net.Sockets;

namespace Client
{
    
    class Program
    {
        static void Main(string[] args)
        {
            MyNetworkStream strm;
            string str;
            TcpClient client = new TcpClient("127.0.0.1", 7000);
            Console.WriteLine(">>> Client Started");
            NetworkStream stream = client.GetStream();
            strm = new MyNetworkStream(stream);
            strm.Write("Hi everybody!");
            strm = new MyNetworkStream(stream);
            str = strm.ReadString();
            Console.WriteLine("Message from Server: " + str);

            Console.ReadKey();
        }
    }
}