using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_InterCommLib.MessageFormat
{
    [Serializable]
    public class SystemUpdate
    {
        public List<ProcessInfo> Processes = new List<ProcessInfo>();
        public SystemUpdate(Process[] Proceses)
        {
            foreach (var item in Proceses)
            {
                Processes.Add(new ProcessInfo()
                {
                    id = item.Id,
                    Name = item.ProcessName
                });
            }
        }
    }
    [Serializable]
    public class ProcessInfo
    {
        public string Name;
        public int id;
    }
}
