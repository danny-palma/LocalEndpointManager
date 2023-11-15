using LocalEndpointManager_Client_Service.Logger;
using LocalEndpointManager_Client_Service.Sockets;
using LocalEndpointManager_InterCommLib;
using LocalEndpointManager_InterCommLib.MessageFormat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalEndpointManager_Client_Service.Modules
{
    internal class UpdateServer
    {
        private static Thread UpsateServerThread;
        private static bool StopThread;
        public static void StartUpdateServer()
        {
            System_Logger.Log("Se ha iniciado la actualizacion del servidor");
            StopThread = false;
            UpsateServerThread = new Thread(ServerUptade);
            UpsateServerThread.Start();
        }

        public static void StopUpdateServer()
        {
            StopThread = true;
            UpsateServerThread?.Join();
            System_Logger.Log("Se ha finalizado la actualizacion del servidor");
        }

        private static void ServerUptade()
        {
            while (StopThread == false)
            {
                Process[] processes = Process.GetProcesses();
                List<ProcesesInfo> procesesInfos = new List<ProcesesInfo>();
                foreach (Process process in processes)
                {
                    procesesInfos.Add(new ProcesesInfo()
                    {
                        name = process.ProcessName,
                        PID = process.Id
                    }
                    );
                }
                MessageFormat Message = new MessageFormat
                {
                    TypeMessage = "Update",
                    Data = ObjectSerializer.Serialize(new SystemUpdate(Environment.MachineName, procesesInfos)),
                    ping = new DateTime()
                };

                MainSocketClass.Send( Message );
                Thread.Sleep(60000);
            }
        }
    }
}
