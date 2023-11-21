using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_Server_GUI
{
    public static class ServiceCommunicationPool
    {
        public static ServerService.CommunicationClient client = new ServerService.CommunicationClient();
    }
}
