using LocalEndpointManager_InterCommLib.MessageFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_Server_Service.GUI_Comunication
{

    [ServiceContract]
    public interface ICommunication
    {
        [OperationContract]
        string GetConnectedClientsInfo();
    }
}
