using ModelLib;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JsonUDPSender
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPSenderJson udpSender = new UDPSenderJson();
            udpSender.Start();
            Console.ReadLine();
        }
    }

    public class UDPSenderJson
    {
        public void Start()
        {
            Car car = new Car { Model = "Tesla", Color = "Red", RegNr = "EL23400" };

            //IPAddress ip = IPAddress.Parse("127.0.0.1");
            UdpClient udpClient = new UdpClient("127.0.0.1", 11002);
            //IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 11002);
            string jsonCar = JsonConvert.SerializeObject(car);
            for (int i = 0; i < 50; i++)
            {
                Byte[] sendBytes = Encoding.ASCII.GetBytes(jsonCar);
                udpClient.Send(sendBytes, sendBytes.Length);
            }

        }
    }
}
