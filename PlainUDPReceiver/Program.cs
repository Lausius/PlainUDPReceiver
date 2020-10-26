using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PlainUDPReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPReceiver udpReceiver = new UDPReceiver();
            udpReceiver.Start();
            Console.ReadLine();
        }
    }

    public class UDPReceiver
    {
        public static int port = 11001;
        public void Start()
        {
            UdpClient udpServer = new UdpClient(port);

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEndPoint = new IPEndPoint(ip, port);

            try
            {
                Console.WriteLine("Server is blocked");
                    Byte[] receiveBytes = udpServer.Receive(ref remoteEndPoint);
                    Console.WriteLine("Server is now activated");

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);
                    Console.WriteLine(receivedData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
