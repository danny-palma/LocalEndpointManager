using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEndpointManager_InterCommLib.MessageFormat
{
    [Serializable]
    public class MessageFormat
    {
        public string TypeMessage;
        public byte[] Data;
    }
}
