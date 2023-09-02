using LocalEndpointManager_InterCommLib.MessageFormat;
using LocalEndpointManager_InterCommLib;
using LocalEndpointManager_Server_Service.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_Server_Service.Sockets
{
    internal partial class MainSocketClass
    {

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

    }
}
