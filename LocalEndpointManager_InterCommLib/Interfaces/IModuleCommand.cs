using LocalEndpointManager_InterCommLib.MessageFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_InterCommLib.Interfaces
{
    public interface IModuleCommand
    {
        string ModuleName { get; }
        void Exec(MessageFormat.MessageFormat Args);
    }
}
