using LocalEndpointManager_InterCommLib.MessageFormat;
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
    public partial class ProcessListView : UserControl
    {
        public ProcessListView(ProcessInfo[] ProcessesArgs)
        {
            InitializeComponent();
            VistaListaProcesses.Items.Clear();
            foreach (var item in ProcessesArgs)
            {
                ListViewItem NewItem = new ListViewItem();
                NewItem.Text = item.Name;
                ListViewItem.ListViewSubItem NewSubItem = new ListViewItem.ListViewSubItem();
                NewSubItem.Text = item.id.ToString();
                NewItem.SubItems.Add(NewSubItem);
                VistaListaProcesses.Items.Add(NewItem);
            }
        }
    }
}
