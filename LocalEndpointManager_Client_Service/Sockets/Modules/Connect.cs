﻿using LocalEndpointManager_Client_Service.Logger;
using LocalEndpointManager_Client_Service.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalEndpointManager_Client_Service.Sockets
{
    // Connect to the server functions
    internal partial class MainSocketClass
    {
        // Intentar una conexion socket con el servidor
        public static void Connect(string ipAdress, int port)
        {
            try
            {
                ConnectionTry++;
                System_Logger.Log("Conectando al servidor...");
                SocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SocketClient.BeginConnect(ipAdress, port, ConnectCallBack, null);
            }
            catch (Exception ex)
            {
                System_Logger.Log("Error Conectado al servidor: " + ex.Message);
                VerifyConnection();
            }
        }

        // Funcion de callback cuando se conecta con el servidor
        private static void ConnectCallBack(IAsyncResult result)
        {
            try
            {
                SocketClient.EndConnect(result);
                System_Logger.Log("Conectado al servidor");

                string ComputerName = Environment.MachineName;

                Send(Encoding.UTF8.GetBytes(ComputerName));
                Thread.Sleep(1000);
                if (SendQueue.Count > 0)
                {
                    for (int i = 0; i < SendQueue.Count; i++)
                    {
                        Send(SendQueue[i]);
                        allDone.WaitOne();
                    }
                    SendQueue.Clear();
                }
                UpdateServer.StartUpdateServer();
                System_Logger.Log("Esperando mensajes...");
                ConnectionTry = 0;
                SocketClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReciveCallback, buffer);
            }
            catch (Exception ex)
            {
                System_Logger.Log("Error al conectar!! \n" + ex.Message);
                VerifyConnection();
            }
        }
    }
}
