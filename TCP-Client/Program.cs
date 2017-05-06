using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string dl;
            byte[] data = new byte[1024 * 5];
            //Khởi tạo socket để trao đổi dữ liệu
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint _ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2017);

            // kết nối tới server
            client.Connect(_ipe);
            if (client.Connected)
            {
                //nhan chuoi ket noi tu server
                client.Receive(data);
                dl = Encoding.ASCII.GetString(data);
                Console.WriteLine(dl);
            }
            //trao đổi dữ liệu với server

            while (true)
            {
                data = new byte[1024 * 5];
                dl = Console.ReadLine();
                data = Encoding.ASCII.GetBytes(dl);
                client.Send(data);

            }

        }
    }
}
