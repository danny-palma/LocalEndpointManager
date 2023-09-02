using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_Server_Service.Sockets
{
    internal partial class MainSocketClass
    {
        // desconecta al cliente y lo remueve de la lista de clientes conectados
        public static void DisconnectClient(StateClientObject state)
        {
            try
            {
                state.socket.BeginDisconnect(false, DisconnectCallback, state);
                state.socket?.Close();
                Console.WriteLine($"Desconectando el cliente: {state.id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error cuando se intentaba desconectar al cliente!! \n" + ex.Message);
                ConnectedClients.Remove(state);
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
                if (ConnectedClients.Remove(state))
                {
                    Console.WriteLine("Cliente eliminado de la lista de clientes conectados");
                } else
                {
                    Console.WriteLine("Ciente no se elimino de la lista por que no se encontro!!");
                }
            }
        }

    }
}
