using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalEndpointManager_Server_GUI.Views.Connections_View
{
    public partial class ClientSelectButton : UserControl
    {
        public string MachineNameReference;
        public ClientSelectButton(string machineNameReference)
        {
            InitializeComponent();
            MachineNameReference = machineNameReference;
            SelectMachineButton.Text = machineNameReference;
        }
    }
}
