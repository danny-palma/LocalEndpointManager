using LocalEndpointManager_Server_Service.Sockets;
using System;
using System.ServiceProcess;
using System.Threading;

using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

namespace LocalEndpointManager_Server_Service.Services
{
    public partial class Main_Service : ServiceBase
    {
        public Main_Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            MainSocketClass.StartServer("127.0.0.1", 5000);
        }

        protected override void OnStop()
        {

        }
        public void StartDebug()
        {
            OnStart(Array.Empty<string>());
            Console.ReadLine();
            OnStop();
        }
    }
}
