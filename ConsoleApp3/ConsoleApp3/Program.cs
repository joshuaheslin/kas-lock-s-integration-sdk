using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ConsoleApp3
{







    class Program
    {
  

    public class TcpTimeClient
    {
            private const int portNum = 10003;
            //private const int portNum = 2004;
            //private const string hostName = "27.113.241.146";
            //private const string hostName = "192.168.15.199";
            private const string hostName = "192.168.15.100";

            public static int Main(String[] args)
        {
            try
            {
                TcpClient client = new TcpClient(hostName, portNum);

                    //Byte[] data = System.Text.Encoding.ASCII.GetBytes("<STX>9800T|R0101<ETX>");

                    //string hex = BitConverter.ToString(data);

                    // Console.WriteLine(hex);
                    // Console.ReadLine();

                    //Byte[] data = new byte[] {0x02, 0x39, 0x38, 0x30, 0x30, 0x54, 0x7C, 0x52, 0x30, 0x31, 0x30, 0x31, 0x7C, 0x55, 0x41, 0x64, 0x6D, 0x69, 0x6E, 0x03};
                    Byte[] data = new byte[] { 0x02, 0x39, 0x38, 0x30, 0x30, 0x4F, 0x7C, 0x52, 0x30, 0x31, 0x30, 0x31, 0x7C, 0x55, 0x41, 0x64, 0x6D, 0x69, 0x6E, 0x03 };

                    //Byte[] data = new byte[] { 0x4C };
                    //65 78 69 74

                   

                    NetworkStream stream = client.GetStream();

                    stream.Write(data, 0, data.Length);
                   

               byte[] buffer = new byte[1024];
               int bytesRead = stream.Read(buffer, 0, buffer.Length);
               string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
               Console.WriteLine(response);

               Console.ReadLine();

                client.Close();

                }
            catch (Exception e)
            {
                    Console.WriteLine("Error");
                    Console.ReadLine();
            }

            

            return 0;
        }
    }
}
}
