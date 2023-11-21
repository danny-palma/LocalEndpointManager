namespace LocalEndpointManager_Server_GUI.Views.Connections_View
{
    partial class ClientSelectButton
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectMachineButton = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // SelectMachineButton
            // 
            this.SelectMachineButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectMachineButton.FlatAppearance.BorderSize = 0;
            this.SelectMachineButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SelectMachineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectMachineButton.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectMachineButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.SelectMachineButton.IconChar = FontAwesome.Sharp.IconChar.Computer;
            this.SelectMachineButton.IconColor = System.Drawing.Color.Gainsboro;
            this.SelectMachineButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SelectMachineButton.IconSize = 32;
            this.SelectMachineButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SelectMachineButton.Location = new System.Drawing.Point(0, 0);
            this.SelectMachineButton.Margin = new System.Windows.Forms.Padding(3, 20, 3, 5);
            this.SelectMachineButton.Name = "SelectMachineButton";
            this.SelectMachineButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.SelectMachineButton.Size = new System.Drawing.Size(256, 60);
            this.SelectMachineButton.TabIndex = 3;
            this.SelectMachineButton.Text = "N/A";
            this.SelectMachineButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SelectMachineButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SelectMachineButton.UseVisualStyleBackColor = true;
            // 
            // ClientSelectButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SelectMachineButton);
            this.Name = "ClientSelectButton";
            this.Size = new System.Drawing.Size(256, 63);
            this.ResumeLayout(false);

        }

        #endregion

        public FontAwesome.Sharp.IconButton SelectMachineButton;
    }
}
