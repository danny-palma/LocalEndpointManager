using LocalEndpointManager_Client_Service.Modules;
using LocalEndpointManager_Client_Service.Modules.Commands;
using LocalEndpointManager_Client_Service.Sockets;
using LocalEndpointManager_InterCommLib.MessageFormat;
using System;
using System.ServiceProcess;
using System.Text;

namespace LocalEndpointManager_Client_Service.Services
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
            MainSocketClass.Connect("127.0.0.1", 5000);
            MainSocketClass.Send(new MessageFormat { TypeMessage = "Message", Data = Encoding.UTF8.GetBytes("Hola Servidor!!!") });
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
