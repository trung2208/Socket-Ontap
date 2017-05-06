using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string dl;
            byte[] data = new byte[1024 * 5];
            //Khởi tạo socket để trao đổi dữ liệu
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint _ipe = new IPEndPoint(IPAddress.Any, 2017);

            //gán ipe cho server
            server.Bind(_ipe);
            server.Listen(10);
            // chấp nhận kết nối từ client
            Socket client = server.Accept();

            //gui chuoi ket noi toi client
            string dataSend = "da ket noi";
            data = Encoding.ASCII.GetBytes(dataSend);
            client.Send(data);
            //trao đổi dữ liệu với client

            while (true)
            {
                data = new byte[1024 * 5];
                int rcv = client.Receive(data);
                dl = Encoding.ASCII.GetString(data, 0, rcv);
                Console.WriteLine(dl);
            }
        }
    }
}
