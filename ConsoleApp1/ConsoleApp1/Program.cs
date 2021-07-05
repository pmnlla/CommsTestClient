using System;
using System.Net.Sockets;
namespace ConsoleApp1
{
    class Program
    {
        // https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.tcpclient?view=net-5.0
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nMessage to send:");
                string msg = Console.ReadLine();
                Console.Clear();
                establishConnection("127.0.0.1", 12346, msg);
                
            }
        }
        static void establishConnection(String serverIP, Int32 port, String message)
        {
            try
            {
                // Define a client that connects to server <serverIP> open through port <port>
                TcpClient client = new TcpClient("127.0.0.1", 12346);
                Console.WriteLine("e");
                // Encode the message to send in ASCII, and store it in a byte array
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                Console.WriteLine("e");
                // Create a stream for reading and writing, and send the message to it
                NetworkStream netstream = client.GetStream();
                netstream.Write(data, 0, data.Length);
                Console.WriteLine("e");
                // buffer that stures the response in binary and 
                data = new Byte[256];
                string responseData = "";
                Console.WriteLine("e");
                // read response and store it in <bytes>, define <responseData> as <bytes> encoded in ASCII, and print <responseData>
                Int32 bytes = netstream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Recieved {0}", responseData);
                Console.WriteLine("e");
                // toilet flusher time
                netstream.Close();
                client.Close();
            }
            /// debugging shit (print exception ~if~when it occurs
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNUllException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
    }
}
