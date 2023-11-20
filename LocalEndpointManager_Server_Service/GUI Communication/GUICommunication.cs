using LocalEndpointManager_InterCommLib.MessageFormat;
using LocalEndpointManager_Server_Service.Module.Commands;
using LocalEndpointManager_Server_Service.Sockets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_Server_Service.GUI_Comunication
{
    public class GUICommunication: ICommunication
    {
        public SortedDictionary<string, List<ProcessInfo>> GetConnectedClientsInfo()
        {
            return ClientProcessInfo.Data ?? new SortedDictionary<string, List<ProcessInfo>>();
        }
    }
}
