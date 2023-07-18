using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace LocalEndpointManager_Client_Service.Sockets
{
    internal class MainSocketClass
    {
        private static Socket SocketClient;
        private static readonly byte[] buffer = new byte[1024];
        private static List<byte[]> SendQueue = new List<byte[]>();
        public static bool IsConnected
        {
            get
            {
                if (SocketClient == null)
                {
                    return false;
                }
                return SocketClient.Connected;
            }
        }

        // Intentar una conexion socket con el servidor
        public static void Connect(string ipAdress, int port)
        {
            try
            {
                Console.WriteLine("Conectando al servidor...");
                SocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SocketClient.BeginConnect(ipAdress, port, ConnectCallBack, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Conectado al servidor: " + ex.Message);
            }
        }

        // Intentar enviar un mensaje string a travez del servidor
        public static void Send(string message)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);

                if (!IsConnected)
                {
                    Console.WriteLine("Aun no se ha conectado al servidor, el mensaje se ha puesto en cola para ser enviado");
                    SendQueue.Add(data);
                    return;
                }

                SocketClient.BeginSend(data, 0, data.Length, SocketFlags.None, SendCallback, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar los datos al servidor!! \n" + ex.Message);
            }
        }

        public static void Send(byte[] message)
        {
            try
            {
                byte[] data = message;

                if (!IsConnected)
                {
                    SendQueue.Add(data);
                    return;
                }

                SocketClient.BeginSend(data, 0, data.Length, SocketFlags.None, SendCallback, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar los datos al servidor!! \n" + ex.Message);
            }
        }

        // Intentar la desconexion al servidor
        public static void Disconnect()
        {
            try
            {
                SocketClient.Shutdown(SocketShutdown.Both);
                SocketClient.Close();
                Console.WriteLine("Desconectado con exito!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al desconectar! \n" + ex.Message);
            }
        }
        // Funcion de callback cuando se conecta con el servidor
        private static void ConnectCallBack(IAsyncResult result)
        {
            try
            {
                SocketClient.EndConnect(result);
                Console.WriteLine("Conectado al servidor");
                if (SendQueue.Count > 0)
                {
                    for (int i = 0; i < SendQueue.Count; i++)
                    {
                        Send(SendQueue[i]);
                    }
                    SendQueue.Clear();
                }
                Console.WriteLine("Esperando mensajes...");
                SocketClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReciveCallback, buffer);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar!! \n" + ex.Message);
            }
        }

        // Funcion callback cuando se recive un mensaje 
        private static void ReciveCallback(IAsyncResult result)
        {
            try
            {
                int BytesRead = SocketClient.EndReceive(result);

                if (BytesRead > 0)
                {
                    byte[] DataBuffer = (byte[])result.AsyncState;
                    string message = Encoding.UTF8.GetString(DataBuffer, 0, BytesRead);
                    Console.WriteLine("Mensaje recibido: " + message);

                    SocketClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReciveCallback, buffer);
                }
                else
                {

                    Console.WriteLine();
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Reciviendo los datos del servidor!! \n", ex.Message);
            }
        }

        // Callback para enviar los datos al servidor
        private static void SendCallback(IAsyncResult result)
        {
            try
            {
                int BytesSent = SocketClient.EndSend(result);
                Console.WriteLine("El mensaje fue enviado al servidor");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar los datos al servidor!! \n" + ex.Message);
            }
        }
    }
}
