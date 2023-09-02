using LocalEndpointManager_InterCommLib;
using LocalEndpointManager_InterCommLib.MessageFormat;
using LocalEndpointManager_Server_Service.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Timers;

namespace LocalEndpointManager_Server_Service.Sockets
{
    public class StateClientObject
    {
        public int id = 0;
        public Socket socket = null;
        public byte[] buffer = new byte[CommonConstats.BUFFER_SIZE];
        public string ComputerName = null;
    }
    internal partial class MainSocketClass
    {
        private static readonly ManualResetEvent AllDone = new ManualResetEvent(false);
        private static readonly int MaxClients = 10;
        public static List<StateClientObject> ConnectedClients = new List<StateClientObject>();
        public static Socket listener = null;

        private static void VerifyConnection(StateClientObject state)
        {
            bool connected = state.socket?.Connected == null ? false : state.socket.Connected;
            if (!connected)
            {
                DisconnectClient(state);
            }
        }
    }
}
