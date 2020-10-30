using ModelLib;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JsonUDPReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPReceiverJson udpReceiver = new UDPReceiverJson();
            udpReceiver.Start();
            Console.ReadLine();
        }
    }
    public class UDPReceiverJson
    {
        public static int port = 11002;
        public void Start()
        {
            UdpClient udpServer = new UdpClient(port);

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEndPoint = new IPEndPoint(ip, port);

            try
            {
                Console.WriteLine("Server is blocked");
                while (true)
                {

                    Byte[] receiveBytes = udpServer.Receive(ref remoteEndPoint);

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);
                    Car carJson = JsonConvert.DeserializeObject<Car>(receivedData);
                    Console.WriteLine(carJson);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
