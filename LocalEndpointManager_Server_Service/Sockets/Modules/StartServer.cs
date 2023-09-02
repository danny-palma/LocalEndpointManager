using LocalEndpointManager_InterCommLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_Server_Service.Sockets
{
    internal partial class MainSocketClass
    {
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
    }
}
