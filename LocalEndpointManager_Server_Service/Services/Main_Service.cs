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
        private void MessagesController()
        {
            string message = string.Empty;
            while (message == "exit")
            {
                message = Console.ReadLine();
                MainSocketClass.SendAll(message);
            }
        }
        public void StartDebug()
        {
            Thread thread = new Thread(MessagesController);
            thread.Start();

            OnStart(Array.Empty<string>());
            Console.ReadLine();
            OnStop();
        }
    }
}
