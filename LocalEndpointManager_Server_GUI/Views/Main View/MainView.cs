using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalEndpointManager_Server_GUI.Views
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            ServerService.CommunicationClient communicationClient = new ServerService.CommunicationClient();
            label1.Text = communicationClient.GetConnectedClientsInfo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
