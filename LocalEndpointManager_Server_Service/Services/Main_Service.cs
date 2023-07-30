using LocalEndpointManager_Server_Service.Sockets;
using System;
using System.ServiceProcess;
using System.Threading;

using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using LocalEndpointManager_Server_Service.Module;
using LocalEndpointManager_Server_Service.Module.Commands;

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
            CommandModulesManager.RegisterModule(new MessageCommand());
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
