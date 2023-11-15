using LocalEndpointManager_Client_Service.Logger;
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
    internal partial class MainSocketClass
    {
        private static Socket SocketClient;
        private static readonly byte[] buffer = new byte[CommonConstats.BUFFER_SIZE];
        private static List<byte[]> SendQueue = new List<byte[]>();
        private static int ConnectionTry = 0;
        private static ManualResetEvent allDone = new ManualResetEvent(false);
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

        private static void VerifyConnection()
        {
            if (!IsConnected)
            {
                Disconnect();
                System_Logger.Log("El cliente se ha desconectado!! Reintentando conexion en 1 min...");
                Thread.Sleep(60000);
                if (ConnectionTry <= 3)
                {
                    System_Logger.Log("Reintentando Conexion...");
                    Connect(Main_Service.EndpointIP, Main_Service.EndpointPort);
                }
                else
                {
                    System_Logger.Log("Se reintento la conexion en varias ocasiones lo cual va a derivar en la salida inesperada del programa");
                    Environment.Exit(1);
                }
            }
        }
    }
}
