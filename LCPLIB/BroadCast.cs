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
    public delegate void ConnectHandler(string str);

    public class BroadCast
    {
        public IPEndPoint from = new IPEndPoint(0, 0);
        
        public void Recieve(int recievePort, ConnectHandler handler)
        {
            UdpClient udpClient = new UdpClient(recievePort); // recieving port
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        byte[] recvBuffer = udpClient.Receive(ref from); // сообщение и от кого пришло
                        string message = Encoding.Unicode.GetString(recvBuffer); // message from sender
                        string strarg = from.Address.ToString() + "  " + from.Port.ToString() + " " + message + '\n';

                        handler(strarg); // обработка результата
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            });
        }

        public void StopRecieve()
        {

        }

        public void Send(int port) // Порт получателя
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
