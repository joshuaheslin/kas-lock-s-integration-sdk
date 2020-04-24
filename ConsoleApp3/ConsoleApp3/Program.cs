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
            //private const int portNum = 2004;
            private const int portNum = 10003;
            private const string hostName = "192.168.15.100";
            //private const string hostName = "27.113.241.146";
            //private const string hostName = "192.168.15.199";
            // private const string hostName = "DESKTOP-673FLDO";

            public static int Main(String[] args)
        {
            try
            {
                TcpClient client = new TcpClient(hostName, portNum);


                //----


                ////// PREAPARE THE DATA

                var name = "GUEST1";
                var mobile = "+61411222333"; //Must be in real mobile number format.
                var startDateTime = "200212152100";
                var endDateTime = "200212302100";
                var room = "0101"; // Must be same room number as in Lock-S Software


                //// CHECK IN MOBILE KEY

                Byte[] data = System.Text.Encoding.ASCII.GetBytes("9800I|R" + room + "|N" + name + "|D" + endDateTime + "|O" + startDateTime + "|H"+ mobile);


                //// CHECK OUT MOBILE KEY


                //Byte[] data = System.Text.Encoding.ASCII.GetBytes("9800B|H" + mobile);


                //// REMOTE UNLOCK


                // Byte[] data = System.Text.Encoding.ASCII.GetBytes("9800O|R0102|UAdmin");


                //// ADD BOOKING = [Optional]


                //String bookingJson = "{\"cmd\":\"addbooking\",\"custname\":\"Josh\",\"rooms\":[\"0101\",\"001\"],\"firstdate\":\"20181101\",\"lastdate\":201811051930,\"lasttime\":1800,\"email\":\"jbmh@me.com\",\"mobile\":\"+61121234345\",\"breakfast\":0,\"remarks\":\"www.booking.com\"}";
                //Byte[] data = System.Text.Encoding.ASCII.GetBytes("9801J|J" + bookingJson);

                

                ////// SEND THE DATA TO TCP

                NetworkStream stream = client.GetStream();

                stream.WriteByte(0x02);
                stream.Write(data, 0, data.Length);
                stream.WriteByte(0x03);

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine(response);

                var result = response.Trim(new char[] { '\u0002', '\u0003' });

                Console.WriteLine(result);

                bool keyWasSent = result.Contains("\"ack\":0");
                Console.WriteLine(keyWasSent);
                if (keyWasSent)
                {
                    Console.WriteLine("Key was sent successfully to the guest \n OR \n Key was removed from guest successfully");
                } else
                {
                    Console.WriteLine("Key was NOT sent because of wrong parameters or other error \n OR \n Key was NOT removed from guest successfully");
                }

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
