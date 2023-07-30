using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_InterCommLib.MessageFormat
{
    [Serializable]
    public class SystemUpdate
    {
        public string Client_Name;
        public List<ProcesesInfo> Proceses;
        public SystemUpdate(string Client_Name, List<ProcesesInfo> Proceses)
        {
            this.Client_Name = Client_Name;
            this.Proceses = Proceses;
        }
    }
    [Serializable]
    public class ProcesesInfo
    {
        public string name;
        public int PID;
    }
}
