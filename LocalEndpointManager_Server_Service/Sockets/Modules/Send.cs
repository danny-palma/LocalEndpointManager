using LocalEndpointManager_InterCommLib.MessageFormat;
using LocalEndpointManager_InterCommLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_Server_Service.Sockets
{
    internal partial class MainSocketClass
    {
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

    }
}
