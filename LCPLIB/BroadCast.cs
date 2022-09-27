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
        
        public class Reciever
        {
            IPEndPoint from = new IPEndPoint(0, 0);
            int recievePort;
            ConnectHandler? handler;
            bool stopped = false;
            public UdpClient? udpClient; // recieving port

            public Reciever(int recievePort, ConnectHandler? handler)
            {
                this.recievePort = recievePort;
                this.handler = handler;
            }

            public void StartRecieve()
            {
                udpClient = new UdpClient(this.recievePort);
                stopped = false;
                Task.Run(() =>
                {
                    while (true && !stopped)
                    {
                        try
                        {
                            byte[] recvBuffer = udpClient.Receive(ref from); // сообщение и от кого пришло
                            string message = Encoding.Unicode.GetString(recvBuffer); // message from sender
                            string strarg = from.Address.ToString() + "  " + from.Port.ToString() + " " + message + '\n';

                            if(handler!=null)
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
                stopped= true;
                if(udpClient!=null)
                    udpClient.Close();
            }
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
