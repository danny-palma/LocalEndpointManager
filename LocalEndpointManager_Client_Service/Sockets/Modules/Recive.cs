using LocalEndpointManager_Client_Service.Modules;
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
    }
}
