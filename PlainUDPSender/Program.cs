using ModelLib;
using PlainUDPReceiver;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PlainUDPSender
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPSender udpSender = new UDPSender();
            udpSender.Start();
            Console.ReadLine();
        }
    }

    public class UDPSender
    {
        public void Start()
        {
            Car car = new Car { Model = "Tesla", Color = "Red", RegNr = "EL23400" };

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            UdpClient udpClient = new UdpClient("127.0.0.1", UDPReceiver.port);
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, UDPReceiver.port);
            for (int i = 0; i < 500; i++)
            {
                Byte[] sendBytes = Encoding.ASCII.GetBytes(car.ToString());
                udpClient.Send(sendBytes, sendBytes.Length);
            }
            //Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);

            //string receivedData = Encoding.ASCII.GetString(receiveBytes);
            //Console.WriteLine(receivedData);

        }
    }
}
