using LocalEndpointManager_InterCommLib.MessageFormat;
using LocalEndpointManager_InterCommLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_Client_Service.Sockets
{
    internal partial class MainSocketClass
    {
        //Funcion para enviar datos en formato MessageFormat
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

        //Funcion para enviar datos en formato byte[]
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
                allDone.WaitOne();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar los datos al servidor!! \n" + ex.Message);
                VerifyConnection();
            }
        }

        // Callback para enviar los datos al servidor
        private static void SendCallback(IAsyncResult result)
        {
            try
            {
                int BytesSent = SocketClient.EndSend(result);
                Console.WriteLine($"El mensaje fue enviado al servidor, Bytes enviados: {BytesSent}");
                allDone.Set();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar los datos al servidor!! \n" + ex.Message);
                VerifyConnection();
            }
        }

    }
}
