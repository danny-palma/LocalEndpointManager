using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LocalEndpointManager_Client_Service.Logger
{
    public static class System_Logger
    {
        public static EventLog logger = new EventLog();

        public static void Log(string value, EventLogEntryType type = EventLogEntryType.Information)
        {
            if (!EventLog.SourceExists("Logs"))
            {
                EventLog.CreateEventSource("Logs", "LEM_CLIENT_LOGS");
            }

            logger.Log = "Logs";
            logger.Source = "LEM_CLIENT";
            logger.WriteEntry(value + $"\n\n{Environment.StackTrace}", type);
        }
    }
}
