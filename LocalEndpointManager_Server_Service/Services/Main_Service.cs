using LocalEndpointManager_Server_Service.Sockets;
using System;
using System.ServiceProcess;
using System.Threading;

using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using LocalEndpointManager_Server_Service.Module;
using LocalEndpointManager_Server_Service.Module.Commands;
using System.ServiceModel;
using LocalEndpointManager_Server_Service.GUI_Comunication;

namespace LocalEndpointManager_Server_Service.Services
{
    public partial class Main_Service : ServiceBase
    {
        private ServiceHost Host;
        public Main_Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            CommandModulesManager.RegisterModule(new MessageCommand());
            // Definir la dirección base del servicio
            Uri baseAddress = new Uri("http://localhost:5050/LEMServerService");

            // Crear un ServiceHost para el servicio y usar la dirección base
            Host = new ServiceHost(typeof(GUICommunication), baseAddress);
            // Configurar el endpoint del servicio
            Host.AddServiceEndpoint(typeof(ICommunication), new BasicHttpBinding(), "");

            // Abrir el ServiceHost para comenzar a aceptar solicitudes
            Host.Open();
            MainSocketClass.StartServer("127.0.0.1", 5000);
        }

        protected override void OnStop()
        {
            Host.Close();
        }
    }
}
