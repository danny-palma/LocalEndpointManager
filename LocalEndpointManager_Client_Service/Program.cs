using LocalEndpointManager_Client_Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Ejecutando el servidor en modo de depuracion!!");
            Main_Service Service = new Main_Service();
            Service.StartDebug();
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Main_Service()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
