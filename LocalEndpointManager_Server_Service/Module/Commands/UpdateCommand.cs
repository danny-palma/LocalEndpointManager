using LocalEndpointManager_InterCommLib.Interfaces;
using LocalEndpointManager_InterCommLib.MessageFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_Server_Service.Module.Commands
{
    internal class UpdateCommand : IModuleCommand
    {
        public string ModuleName => "Update";
        public void Exec(MessageFormat Args)
        {

        }
    }
}
    