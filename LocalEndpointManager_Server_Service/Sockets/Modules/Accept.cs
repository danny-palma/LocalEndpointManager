using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LocalEndpointManager_Server_Service.Sockets
{
    internal partial class MainSocketClass
    {
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
                    handler?.Shutdown(SocketShutdown.Both);
                    handler?.Close();
                    return;
                }

                Timer timer = new Timer
                {
                    Interval = 100
                };
                timer.Elapsed += AcceptCallbackTimeout;
                timer.Start();
                byte[] data = new byte[1024];
                string ComputerName;
                lock (data)
                {
                    int bytesRead = handler.Receive(data);
                    ComputerName = Encoding.UTF8.GetString(data, 0, bytesRead).Trim();
                }

                timer.Stop();
                handler.Send(Encoding.UTF8.GetBytes("ok"));
                if (ConnectedClients.Any(ConnectedClient => ConnectedClient.ComputerName == ComputerName))
                {
                    Console.WriteLine("Nombre de pc duplicado, Se va a rechazar la conexion...");
                    handler?.Shutdown(SocketShutdown.Both);
                    handler?.Close();
                    return;
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

    }
}
