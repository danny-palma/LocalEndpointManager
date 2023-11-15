using LocalEndpointManager_Client_Service.Logger;
using LocalEndpointManager_Client_Service.Modules;
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
        // Intentar la desconexion al servidor
        public static void Disconnect()
        {
            try
            {
                UpdateServer.StopUpdateServer();
                SocketClient.Shutdown(SocketShutdown.Both);
                SocketClient.Close();
                System_Logger.Log("Desconectado con exito!!");
            }
            catch (Exception ex)
            {
                System_Logger.Log("Error al desconectar! \n" + ex.Message);
            }
        }

    }
}
