using LocalEndpointManager_InterCommLib;
using LocalEndpointManager_InterCommLib.Interfaces;
using LocalEndpointManager_InterCommLib.MessageFormat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (ClientProcessInfo.Data.TryGetValue(Args.NameSender, out _)){
                ClientProcessInfo.Data[Args.NameSender] = ObjectSerializer.Deserialize<SystemUpdate>(Args.Data).Processes;
            }
            else
            {
                ClientProcessInfo.Data.Add(Args.NameSender, ObjectSerializer.Deserialize<SystemUpdate>(Args.Data).Processes);
            }
        }
    }
    public static class ClientProcessInfo
    {
        public static SortedDictionary<string, List<ProcessInfo>> Data = new SortedDictionary<string, List<ProcessInfo>>();
    }
}
    