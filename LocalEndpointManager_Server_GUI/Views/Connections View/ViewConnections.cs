using LocalEndpointManager_InterCommLib.MessageFormat;
using LocalEndpointManager_Server_GUI.Views.Connections_View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalEndpointManager_Server_GUI.Views
{
    public partial class ViewConnections : Form
    {
        private Dictionary<string, ProcessInfo[]> Clientsinfo;
        public ViewConnections()
        {
            InitializeComponent();
            try
            {
                ServiceCommunicationPool.client.Open();
            }
            catch
            {

            }
            if (ServiceCommunicationPool.client.State != System.ServiceModel.CommunicationState.Opened)
            {
                NoServiceConnection NewControl = new NoServiceConnection();
                this.Controls.Add(NewControl);
                NewControl.Dock = DockStyle.Fill;
            }
            else
            {
                Clientsinfo = ServiceCommunicationPool.client.GetConnectedClientsInfo();
                foreach (var clientinfo in Clientsinfo)
                {
                    ClientSelectButton NewButton = new ClientSelectButton(clientinfo.Key);
                    NewButton.SelectMachineButton.Click += ClientsSelectButtonClick;
                    SelectPanel.Controls.Add(NewButton);

                }
            }

        }

        private void ClientsSelectButtonClick(object sender, EventArgs e)
        {
            FontAwesome.Sharp.IconButton boton = (FontAwesome.Sharp.IconButton)sender;
            ProcessInfo[] ClientProcesses;
            if (Clientsinfo.TryGetValue(boton.Text, out ClientProcesses))
            {
                ProcessListView NewView = new ProcessListView(ClientProcesses);
                Controls.Add(NewView);
                NewView.Location = new System.Drawing.Point(166, 0);
            };

        }

        private void ViewConnections_Load(object sender, EventArgs e)
        {
        }

        private void clientSelectButton1_Load(object sender, EventArgs e)
        {

        }
    }
}
