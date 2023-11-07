using LocalEndpointManager_InterCommLib.Interfaces;
using LocalEndpointManager_InterCommLib.MessageFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_Client_Service.Modules
{
    internal class CommandModulesManager
    {
        private static readonly Dictionary<string, IModuleCommand> Modules = new Dictionary<string, IModuleCommand>();

        public static void RegisterModule(IModuleCommand Command)
        {
            Modules[Command.ModuleName] = Command;
        }

        public static void ExecuteModule(string Name, MessageFormat Args)
        {
            if (Modules.TryGetValue(Name, out IModuleCommand Command))
            {
                Command.Exec(Args);
            }
            else
            { 
                Console.WriteLine($"Modulo {Name} no encontrado!!");
            }
        }

    }
}
