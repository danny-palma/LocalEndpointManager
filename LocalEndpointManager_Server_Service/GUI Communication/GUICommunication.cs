using LocalEndpointManager_InterCommLib.MessageFormat;
using LocalEndpointManager_Server_Service.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_Server_Service.GUI_Comunication
{
    public class GUICommunication: ICommunication
    {
        public string GetConnectedClientsInfo()
        {
            return "hola mundoooo!!";
        }
    }
}
