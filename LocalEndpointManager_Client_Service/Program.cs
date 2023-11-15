using LocalEndpointManager_Client_Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LocalEndpointManager_Client_Service
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
#if DEBUG
            Debugger.Launch();
#endif
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Main_Service()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
