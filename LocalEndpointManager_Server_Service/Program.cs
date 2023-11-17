using LocalEndpointManager_Server_Service.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_Server_Service
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
            Console.WriteLine("Ejecutando En modo de lanzamiento!!");
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Main_Service()
            };
            
            ServiceBase.Run(ServicesToRun);
        }
    }
}
