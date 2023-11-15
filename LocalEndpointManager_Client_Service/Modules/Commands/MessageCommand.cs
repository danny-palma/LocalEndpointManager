using LocalEndpointManager_Client_Service.Logger;
using LocalEndpointManager_InterCommLib.Interfaces;
using LocalEndpointManager_InterCommLib.MessageFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_Client_Service.Modules.Commands
{
    internal class MessageCommand : IModuleCommand
    {
        public string ModuleName => "Message";
        public void Exec(MessageFormat Args)
        {
            System_Logger.Log("EJecutando el comando Mensaje!!");
            System_Logger.Log($"Mensaje recibido: {Encoding.UTF8.GetString(Args.Data)}");
        }
    }
}
