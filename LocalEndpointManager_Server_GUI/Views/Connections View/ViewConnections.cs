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
        public ViewConnections()
        {
            InitializeComponent();
            ServerService.CommunicationClient communicationClient = new ServerService.CommunicationClient();
            foreach (var item in communicationClient.GetConnectedClientsInfo())
            {
                SelectPanel.Controls.Add(new ClientSelectButton(item.Key));
            }
        }

        private void ViewConnections_Load(object sender, EventArgs e)
        {
        }

        private void clientSelectButton1_Load(object sender, EventArgs e)
        {

        }
    }
}
