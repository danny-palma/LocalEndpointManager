namespace LocalEndpointManager_Server_GUI
{
    partial class Main_Window
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Window));
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.BtnHome = new FontAwesome.Sharp.IconButton();
            this.BtnSettings = new FontAwesome.Sharp.IconButton();
            this.BtnConnections = new FontAwesome.Sharp.IconButton();
            this.BtnDashboard = new FontAwesome.Sharp.IconButton();
            this.PanelTitleBar = new System.Windows.Forms.Panel();
            this.WindowMinimize = new FontAwesome.Sharp.IconButton();
            this.WindowSize = new FontAwesome.Sharp.IconButton();
            this.CloseButton = new FontAwesome.Sharp.IconButton();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.IconCurrentForm = new FontAwesome.Sharp.IconPictureBox();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.MenuPanel.SuspendLayout();
            this.PanelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconCurrentForm)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.MenuPanel.Controls.Add(this.BtnConnections);
            this.MenuPanel.Controls.Add(this.BtnDashboard);
            this.MenuPanel.Controls.Add(this.BtnHome);
            this.MenuPanel.Controls.Add(this.BtnSettings);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(200, 561);
            this.MenuPanel.TabIndex = 0;
            // 
            // BtnHome
            // 
            this.BtnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnHome.FlatAppearance.BorderSize = 0;
            this.BtnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHome.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHome.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.BtnHome.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            this.BtnHome.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnHome.IconSize = 32;
            this.BtnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHome.Location = new System.Drawing.Point(0, 0);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.BtnHome.Size = new System.Drawing.Size(200, 60);
            this.BtnHome.TabIndex = 4;
            this.BtnHome.Text = "Inicio";
            this.BtnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnHome.UseVisualStyleBackColor = true;
            this.BtnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // BtnSettings
            // 
            this.BtnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnSettings.FlatAppearance.BorderSize = 0;
            this.BtnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSettings.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.BtnSettings.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.BtnSettings.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnSettings.IconSize = 32;
            this.BtnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSettings.Location = new System.Drawing.Point(0, 501);
            this.BtnSettings.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.BtnSettings.Size = new System.Drawing.Size(200, 60);
            this.BtnSettings.TabIndex = 3;
            this.BtnSettings.Text = "Configuracion";
            this.BtnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSettings.UseVisualStyleBackColor = true;
            this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // BtnConnections
            // 
            this.BtnConnections.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnConnections.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnConnections.FlatAppearance.BorderSize = 0;
            this.BtnConnections.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnConnections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConnections.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConnections.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.BtnConnections.IconChar = FontAwesome.Sharp.IconChar.NetworkWired;
            this.BtnConnections.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnConnections.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnConnections.IconSize = 32;
            this.BtnConnections.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConnections.Location = new System.Drawing.Point(0, 120);
            this.BtnConnections.Margin = new System.Windows.Forms.Padding(3, 20, 3, 5);
            this.BtnConnections.Name = "BtnConnections";
            this.BtnConnections.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.BtnConnections.Size = new System.Drawing.Size(200, 60);
            this.BtnConnections.TabIndex = 2;
            this.BtnConnections.Text = "Conexiones";
            this.BtnConnections.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConnections.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnConnections.UseVisualStyleBackColor = true;
            this.BtnConnections.Click += new System.EventHandler(this.BtnConnections_Click);
            // 
            // BtnDashboard
            // 
            this.BtnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnDashboard.FlatAppearance.BorderSize = 0;
            this.BtnDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDashboard.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.BtnDashboard.IconChar = FontAwesome.Sharp.IconChar.Dashboard;
            this.BtnDashboard.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnDashboard.IconSize = 32;
            this.BtnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDashboard.Location = new System.Drawing.Point(0, 60);
            this.BtnDashboard.Name = "BtnDashboard";
            this.BtnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.BtnDashboard.Size = new System.Drawing.Size(200, 60);
            this.BtnDashboard.TabIndex = 1;
            this.BtnDashboard.Text = "Panel de control";
            this.BtnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDashboard.UseVisualStyleBackColor = true;
            this.BtnDashboard.Click += new System.EventHandler(this.BtnDashboard_Click);
            // 
            // PanelTitleBar
            // 
            this.PanelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.PanelTitleBar.Controls.Add(this.WindowMinimize);
            this.PanelTitleBar.Controls.Add(this.WindowSize);
            this.PanelTitleBar.Controls.Add(this.CloseButton);
            this.PanelTitleBar.Controls.Add(this.LabelTitle);
            this.PanelTitleBar.Controls.Add(this.IconCurrentForm);
            this.PanelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitleBar.Location = new System.Drawing.Point(200, 0);
            this.PanelTitleBar.Name = "PanelTitleBar";
            this.PanelTitleBar.Size = new System.Drawing.Size(984, 41);
            this.PanelTitleBar.TabIndex = 1;
            this.PanelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitleBar_MouseDown);
            // 
            // WindowMinimize
            // 
            this.WindowMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WindowMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.WindowMinimize.FlatAppearance.BorderSize = 0;
            this.WindowMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.WindowMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.WindowMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WindowMinimize.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowMinimize.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.WindowMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.WindowMinimize.IconColor = System.Drawing.Color.Gainsboro;
            this.WindowMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.WindowMinimize.IconSize = 24;
            this.WindowMinimize.Location = new System.Drawing.Point(861, 0);
            this.WindowMinimize.Name = "WindowMinimize";
            this.WindowMinimize.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.WindowMinimize.Size = new System.Drawing.Size(41, 41);
            this.WindowMinimize.TabIndex = 6;
            this.WindowMinimize.UseVisualStyleBackColor = true;
            this.WindowMinimize.Click += new System.EventHandler(this.WindowMinimize_Click);
            // 
            // WindowSize
            // 
            this.WindowSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WindowSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.WindowSize.FlatAppearance.BorderSize = 0;
            this.WindowSize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.WindowSize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.WindowSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WindowSize.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowSize.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.WindowSize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.WindowSize.IconColor = System.Drawing.Color.Gainsboro;
            this.WindowSize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.WindowSize.IconSize = 24;
            this.WindowSize.Location = new System.Drawing.Point(902, 0);
            this.WindowSize.Name = "WindowSize";
            this.WindowSize.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.WindowSize.Size = new System.Drawing.Size(41, 41);
            this.WindowSize.TabIndex = 5;
            this.WindowSize.UseVisualStyleBackColor = true;
            this.WindowSize.Click += new System.EventHandler(this.WindowSize_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.CloseButton.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.CloseButton.IconColor = System.Drawing.Color.Gainsboro;
            this.CloseButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.CloseButton.IconSize = 24;
            this.CloseButton.Location = new System.Drawing.Point(943, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.CloseButton.Size = new System.Drawing.Size(41, 41);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTitle.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LabelTitle.Location = new System.Drawing.Point(41, 10);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(50, 21);
            this.LabelTitle.TabIndex = 1;
            this.LabelTitle.Text = "Inicio";
            // 
            // IconCurrentForm
            // 
            this.IconCurrentForm.BackColor = System.Drawing.Color.Transparent;
            this.IconCurrentForm.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.IconCurrentForm.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            this.IconCurrentForm.IconColor = System.Drawing.SystemColors.ControlLight;
            this.IconCurrentForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconCurrentForm.Location = new System.Drawing.Point(3, 5);
            this.IconCurrentForm.Name = "IconCurrentForm";
            this.IconCurrentForm.Size = new System.Drawing.Size(32, 32);
            this.IconCurrentForm.TabIndex = 0;
            this.IconCurrentForm.TabStop = false;
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(200, 41);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(984, 520);
            this.ContainerPanel.TabIndex = 2;
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.ContainerPanel);
            this.Controls.Add(this.PanelTitleBar);
            this.Controls.Add(this.MenuPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "Main_Window";
            this.Text = "Managment Window";
            this.Load += new System.EventHandler(this.Main_Window_Load);
            this.Resize += new System.EventHandler(this.Main_Window_Resize);
            this.MenuPanel.ResumeLayout(false);
            this.PanelTitleBar.ResumeLayout(false);
            this.PanelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconCurrentForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private FontAwesome.Sharp.IconButton BtnDashboard;
        private FontAwesome.Sharp.IconButton BtnConnections;
        private FontAwesome.Sharp.IconButton BtnSettings;
        private System.Windows.Forms.Panel PanelTitleBar;
        private System.Windows.Forms.Label LabelTitle;
        private FontAwesome.Sharp.IconPictureBox IconCurrentForm;
        private System.Windows.Forms.Panel ContainerPanel;
        private FontAwesome.Sharp.IconButton CloseButton;
        private FontAwesome.Sharp.IconButton WindowMinimize;
        private FontAwesome.Sharp.IconButton WindowSize;
        private FontAwesome.Sharp.IconButton BtnHome;
    }
}

