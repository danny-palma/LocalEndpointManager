using LocalEndpointManager_InterCommLib;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;

namespace LocalEndpointManager_Server_Service.Sockets
{
    public class StateClientObject
    {
        public int id = 0;
        public Socket socket = null;
        public byte[] buffer = new byte[CommonConstats.BUFFER_SIZE];
        public StringBuilder sb = new StringBuilder();
    }
    internal class MainSocketClass
    {
        private static readonly ManualResetEvent AllDone = new ManualResetEvent(false);
        public static readonly int BufferSize = 1024;
        private static readonly int MaxClients = 10;
        public static List<StateClientObject> ConnectedClients = new List<StateClientObject>();
        public static Socket listener = null;

        // Iniciar servidor para la escucha de clientes entrantes
        public static void StartServer(string ip, int port)
        {
            Console.WriteLine("Iniciando servidor...");
            byte[] buffer = new byte[CommonConstats.BUFFER_SIZE];
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse(ip);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, port);

            try
            {
                listener.Bind(iPEndPoint);
                listener.Listen(MaxClients);

                while (true)
                {
                    AllDone.Reset();
                    Console.WriteLine("Esperando Conexiones...");
                    listener.BeginAccept(AcceptCallback, listener);
                    AllDone.WaitOne();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error!! \n" + ex.Message);
                Environment.Exit(1);
            }
        }
        // desconecta al cliente y lo remueve de la lista de clientes conectados
        public static void DisconnectClient(StateClientObject state)
        {
            try
            {
                state.socket.BeginDisconnect(false, DisconnectCallback, state);
                Console.WriteLine($"Desconectando el cliente: {state.id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error cuando se intentaba desconectar al cliente!! \n" + ex.Message);
            }
            ConnectedClients.Remove(state);

        }
        // Enviar un String al un cliente especifico
        public static void Send(StateClientObject state, string message)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);

                state.socket.BeginSend(data, 0, data.Length, 0, SendCallback, state);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enviando el mensaje al cliente con ID: {state.id} \n {ex.Message}");
            }
        }

        public static void SendAll(string message)
        {
            try
            {
                foreach (StateClientObject state in ConnectedClients)
                {
                    Send(state, message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enviando mensajes a todos los clientes!! \n{ex.Message}");
            }
        }


        private static void DisconnectCallback(IAsyncResult ar)
        {
            try
            {
                StateClientObject state = (StateClientObject)ar.AsyncState;
                state.socket.EndDisconnect(ar);
                state.socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error desconectando el cliente!! " + ex.Message);
            }
        }


        private static void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                AllDone.Set();

                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);

                StateClientObject state = new StateClientObject
                {
                    socket = handler
                };

                ConnectedClients.Add(state);
                state.id = ConnectedClients.Count;

                Console.WriteLine("Cliente conectado, clientes totales: " + ConnectedClients.Count);

                handler.BeginReceive(state.buffer, 0, BufferSize, 0, ReciveCallback, state);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Aceptando la conexion del cliente: \n" + ex.Message);
            }
        }


        private static void ReciveCallback(IAsyncResult ar)
        {
            try
            {
                string content = string.Empty;

                StateClientObject state = (StateClientObject)ar.AsyncState;
                Socket handler = state.socket;

                int BytesRead = handler.EndReceive(ar);

                if (BytesRead > 0)
                {
                    state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, BytesRead));
                    content = state.sb.ToString();
                    Console.WriteLine(content);
                    Send(state, "ok");
                    state.sb.Clear();
                    handler.BeginReceive(state.buffer, 0, BufferSize, 0, ReciveCallback, state);
                }
                else
                {
                    DisconnectClient(state);
                    Console.WriteLine("Cliente Desconectado; Clientes totales: " + ConnectedClients.Count);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reciviendo el mensaje: " + ex.Message);
            }
        }


        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                StateClientObject handler = (StateClientObject)ar.AsyncState;
                int bytesSent = handler.socket.EndSend(ar);
                Console.WriteLine("Mensaje enviado al cliente Bytes enviados: " + bytesSent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enviando el mensaje!! \n{ex.Message}");
            }
        }

        private static void VerifyConnection(StateClientObject state)
        {
            bool connected = state.socket?.Connected == null ? state.socket.Connected : false;
            if (!connected)
            {
                ConnectedClients.Remove(state);
            }
        }
    }
}
