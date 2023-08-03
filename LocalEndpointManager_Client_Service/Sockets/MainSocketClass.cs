using LocalEndpointManager_Client_Service.Modules;
using LocalEndpointManager_Client_Service.Services;
using LocalEndpointManager_InterCommLib;
using LocalEndpointManager_InterCommLib.MessageFormat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace LocalEndpointManager_Client_Service.Sockets
{
    internal class MainSocketClass
    {
        private static Socket SocketClient;
        private static readonly byte[] buffer = new byte[CommonConstats.BUFFER_SIZE];
        private static List<byte[]> SendQueue = new List<byte[]>();
        private static int ConnectionTry = 0;
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
                ConnectionTry++;
                Console.WriteLine("Conectando al servidor...");
                SocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SocketClient.BeginConnect(ipAdress, port, ConnectCallBack, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Conectado al servidor: " + ex.Message);
                VerifyConnection();
            }
        }

        public static void Send(MessageFormat message)
        {
            try
            {
                Send(ObjectSerializer.Serialize(message));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar los datos al servidor!! \n" + ex.Message);
                VerifyConnection();
            }
        }

        public static void Send(byte[] data)
        {
            try
            {
                if (!IsConnected)
                {
                    Console.WriteLine("Aun no se ha conectado al servidor, el mensaje se ha puesto en cola para ser enviado");
                    SendQueue.Add(data);
                    return;
                }
                Console.WriteLine($"Bytes a enviar: {data.Length}");
                SocketClient.BeginSend(data, 0, data.Length, SocketFlags.None, SendCallback, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar los datos al servidor!! \n" + ex.Message);
                VerifyConnection();
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
                VerifyConnection();
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
                UpdateServer.StartUpdateServer();
                Console.WriteLine("Esperando mensajes...");
                ConnectionTry = 0;
                SocketClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReciveCallback, buffer);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar!! \n" + ex.Message);
                VerifyConnection();
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
                    MessageFormat Message = ObjectSerializer.Deserialize<MessageFormat>(buffer);
                    CommandModulesManager.ExecuteModule(Message.TypeMessage, Message);
                }
                else
                {
                    Console.WriteLine("Cliente desconectado...");
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Reciviendo los datos del servidor!! \n", ex.Message);
                VerifyConnection();
            }
            finally
            {
                SocketClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReciveCallback, buffer);
            }
        }

        // Callback para enviar los datos al servidor
        private static void SendCallback(IAsyncResult result)
        {
            try
            {
                int BytesSent = SocketClient.EndSend(result);
                Console.WriteLine($"El mensaje fue enviado al servidor, Bytes enviados: {BytesSent}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar los datos al servidor!! \n" + ex.Message);
                VerifyConnection();
            }
        }

        private static void VerifyConnection()
        {
            if (!IsConnected)
            {
                Console.WriteLine("El cliente se ha desconectado!!");
                Thread.Sleep(60000);
                if (ConnectionTry <= 3)
                {
                    Console.WriteLine("Reintentando Conexion...");
                    Connect(Main_Service.EndpointIP, Main_Service.EndpointPort);
                }
                else
                {
                    Console.WriteLine("Se reintento la conexion en varias ocasiones lo cual va a derivar en la salida inesperada del programa");
                    Environment.Exit(1);
                }
            }
        }
    }
}
