using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LCPLIB
{
    public class BroadCast
    {
        public IPEndPoint from = new IPEndPoint(0, 0);
        
        public void Recieve()
        {
            UdpClient udpClient = new UdpClient(1111);
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        byte[] recvBuffer = udpClient.Receive(ref from);
                        string str = Encoding.Unicode.GetString(recvBuffer);
                        Debug.WriteLine(from.Address.ToString() + "  " + from.Port.ToString() + " " + str + '\n');
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            });
        }

        public void Send(int port)
        {
            UdpClient sender = new UdpClient();
            try
            {
                byte[] data = Encoding.Unicode.GetBytes(port.ToString());
                sender.Send(data, data.Length, new IPEndPoint(IPAddress.Broadcast, port));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
