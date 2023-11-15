using LocalEndpointManager_InterCommLib;
using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Windows.Documents;
using System.Runtime.InteropServices;
using LocalEndpointManager_Server_GUI.Views;

namespace LocalEndpointManager_Server_GUI
{
    public partial class Main_Window : Form
    {
        // Fiedls
        private IconButton CurrentButton;
        private Panel LeftBorderButton;
        private Form CurrentChildForm;

        // Contructor
        public Main_Window()
        {
            InitializeComponent();
            LeftBorderButton = new Panel();
            LeftBorderButton.Size = new Size(7, 60);
            MenuPanel.Controls.Add(LeftBorderButton);
            // form

            this.Text = "";
            this.ControlBox = false;
            this.DoubleBuffered = true;
        }

        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color colors = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = SystemColors.ControlLight;
        }

        // Methods
        private void ActivateButton(Object SenderBtn, Color color)
        {
            if (SenderBtn.Equals(CurrentButton)) return;
            DisableButton();

            //Current button
            CurrentButton = (IconButton)SenderBtn;
            CurrentButton.BackColor = Color.FromName("#181818");
            CurrentButton.ForeColor = color;
            CurrentButton.TextAlign = ContentAlignment.MiddleCenter;
            CurrentButton.IconColor = color;
            CurrentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            CurrentButton.ImageAlign = ContentAlignment.MiddleRight;
            CurrentButton.Cursor = Cursors.Default;
            // Left Border button
            LeftBorderButton.BackColor = color;
            LeftBorderButton.Location = new Point(0, CurrentButton.Location.Y);
            LeftBorderButton.Visible = true;
            LeftBorderButton.BringToFront();
            // Title icon
            IconCurrentForm.IconChar = CurrentButton.IconChar;
            IconCurrentForm.ForeColor = color;
            LabelTitle.Text = CurrentButton.Text;
            LabelTitle.ForeColor = color;
        }

        private void DisableButton()
        {
            if (CurrentButton == null) { return; }
            CurrentButton.BackColor = Color.FromName("#000000");
            CurrentButton.ForeColor = Color.Gainsboro;
            CurrentButton.TextAlign = ContentAlignment.MiddleLeft;
            CurrentButton.IconColor = Color.Gainsboro;
            CurrentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            CurrentButton.ImageAlign = ContentAlignment.MiddleLeft;
            CurrentButton.Cursor = Cursors.Hand;
        }
        private void ResetButtons()
        {
            DisableButton();
            LeftBorderButton.Visible = false;
            IconCurrentForm.IconChar = IconChar.HomeLg;
            IconCurrentForm.ForeColor = System.Drawing.SystemColors.ControlLight;
            LabelTitle.Text = "Inicio";
            LabelTitle.ForeColor = System.Drawing.SystemColors.ControlLight;
            CurrentChildForm?.Close();
            CurrentButton = null;
            OpenChildForm(new MainView());
        }

        private void OpenChildForm(Form ChildForm)
        {
            if (CurrentChildForm != null)
            {
                CurrentChildForm.Close();
            }
            CurrentChildForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            ContainerPanel.Tag = ChildForm;
            ContainerPanel.Controls.Add(ChildForm);
            ChildForm.BringToFront();
            ChildForm.Show();
            LabelTitle.Text = ChildForm.Text;
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            if (CurrentButton != null && CurrentButton.Equals((IconButton)sender)) return;
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new ViewControlPanel());
        }

        private void BtnConnections_Click(object sender, EventArgs e)
        {
            if (CurrentButton != null && CurrentButton.Equals((IconButton)sender)) return;
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new ViewConnections());
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            if (CurrentButton != null && CurrentButton.Equals((IconButton)sender)) return;
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new ViewSettings());
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            if (CurrentButton != null && CurrentButton.Equals((IconButton)sender)) return;
            ActivateButton(sender, RGBColors.color7);
            OpenChildForm(new MainView());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ResetButtons();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ResetButtons();
        }

        private void PanelLogo_Click(object sender, EventArgs e)
        {
            ResetButtons();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hlend, int wMsg, int wParam, int lParam);


        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void WindowMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void WindowSize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void Main_Window_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowSize.IconChar = IconChar.WindowRestore;
            else
                WindowSize.IconChar = IconChar.WindowMaximize;
        }

        private void Main_Window_Load(object sender, EventArgs e)
        {
            BtnHome.PerformClick();
        }
    }
}
