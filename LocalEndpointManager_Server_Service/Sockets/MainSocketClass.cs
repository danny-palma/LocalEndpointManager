using LocalEndpointManager_InterCommLib;
using LocalEndpointManager_InterCommLib.MessageFormat;
using LocalEndpointManager_Server_Service.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Timers;

namespace LocalEndpointManager_Server_Service.Sockets
{
    public class StateClientObject
    {
        public int id = 0;
        public Socket socket = null;
        public byte[] buffer = new byte[CommonConstats.BUFFER_SIZE];
        public string ComputerName = null;
    }
    internal class MainSocketClass
    {
        private static readonly ManualResetEvent AllDone = new ManualResetEvent(false);
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
                state.socket.Close();
                Console.WriteLine($"Desconectando el cliente: {state.id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error cuando se intentaba desconectar al cliente!! \n" + ex.Message);
                ConnectedClients.Remove(state);
            }

        }
        // Enviar un String al un cliente especifico
        public static void Send(StateClientObject state, MessageFormat Message)
        {
            try
            {
                byte[] data = ObjectSerializer.Serialize(Message);

                state.socket.BeginSend(data, 0, data.Length, 0, SendCallback, state);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enviando el mensaje al cliente con ID: {state.id} \n {ex.Message}");
                VerifyConnection(state);
            }
        }

        public static void SendAll(MessageFormat message)
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
            StateClientObject state = (StateClientObject)ar.AsyncState;
            try
            {
                state.socket.EndDisconnect(ar);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error desconectando el cliente!! " + ex.Message);
            }
            finally
            {
                ConnectedClients.Remove(state);
                Console.WriteLine("Cliente eliminado de la lista de clientes conectados");
            }
        }


        private static void AcceptCallback(IAsyncResult ar)
        {
            StateClientObject state = null;
            try
            {
                AllDone.Set();

                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);
                void AcceptCallbackTimeout(object sender, ElapsedEventArgs e)
                {
                    Console.WriteLine("La conexion entrante se cerró por que se supero el tiempo de espera de itentificacion");
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

                System.Timers.Timer timer = new System.Timers.Timer
                {
                    Interval = 1000
                };
                timer.Elapsed += AcceptCallbackTimeout;
                timer.Start();

                byte[] data = new byte[1024];
                int bytesRead = handler.Receive(data);

                timer.Stop();

                string ComputerName = Encoding.UTF8.GetString(data, 0, bytesRead).Trim();
                
                if (ConnectedClients.Any(ConnectedClient => ConnectedClient.ComputerName == ComputerName))
                {
                    Console.WriteLine("Nombre de pc duplicado, Se va a rechazar la conexion...");
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
                
                state = new StateClientObject
                {
                    socket = handler,
                    ComputerName = ComputerName
                };
                
                ConnectedClients.Add(state);
                state.id = ConnectedClients.Count;

                Console.WriteLine($"Cliente conectado, {ComputerName}, clientes totales: {ConnectedClients.Count}");

                handler.BeginReceive(state.buffer, 0, state.buffer.Length, 0, ReciveCallback, state);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Aceptando la conexion del cliente: \n" + ex.Message);
                VerifyConnection(state);
            }
        }


        private static void ReciveCallback(IAsyncResult ar)
        {
            StateClientObject state = (StateClientObject)ar.AsyncState;
            try
            {

                int BytesRead = state.socket.EndReceive(ar);

                if (BytesRead > 0)
                {
                    MessageFormat Message = ObjectSerializer.Deserialize<MessageFormat>(state.buffer);
                    Console.WriteLine($"Mensaje recibido de tipo: {Message.TypeMessage}");
                    CommandModulesManager.ExecuteModule(Message.TypeMessage, Message);
                    Send(state, new MessageFormat { TypeMessage = "Message", Data = Encoding.UTF8.GetBytes("OK Cliente!"), ping = new DateTime() });
                    state.socket.BeginReceive(state.buffer, 0, state.buffer.Length, 0, ReciveCallback, state);
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
                VerifyConnection(state);
            }
        }


        private static void SendCallback(IAsyncResult ar)
        {
            StateClientObject state = (StateClientObject)ar.AsyncState;
            try
            {
                int bytesSent = state.socket.EndSend(ar);
                Console.WriteLine("Mensaje enviado al cliente Bytes enviados: " + bytesSent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enviando el mensaje!! \n{ex.Message}");
                VerifyConnection(state);
            }
        }

        private static void VerifyConnection(StateClientObject state)
        {
            bool connected = state.socket?.Connected == null ? false : state.socket.Connected;
            if (!connected)
            {
                DisconnectClient(state);
            }
        }
    }
}
