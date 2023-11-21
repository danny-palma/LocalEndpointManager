namespace LocalEndpointManager_Server_GUI.Views.Connections_View
{
    partial class ProcessListView
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "hola",
            "hola 1"}, -1);
            this.VistaListaProcesses = new System.Windows.Forms.ListView();
            this.Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // VistaListaProcesses
            // 
            this.VistaListaProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nombre,
            this.PID});
            this.VistaListaProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VistaListaProcesses.HideSelection = false;
            this.VistaListaProcesses.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.VistaListaProcesses.Location = new System.Drawing.Point(0, 0);
            this.VistaListaProcesses.Name = "VistaListaProcesses";
            this.VistaListaProcesses.Size = new System.Drawing.Size(802, 481);
            this.VistaListaProcesses.TabIndex = 0;
            this.VistaListaProcesses.UseCompatibleStateImageBehavior = false;
            this.VistaListaProcesses.View = System.Windows.Forms.View.Details;
            // 
            // Nombre
            // 
            this.Nombre.Text = "Nombre";
            this.Nombre.Width = 199;
            // 
            // PID
            // 
            this.PID.Text = "PID";
            this.PID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PID.Width = 180;
            // 
            // ProcessListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.Controls.Add(this.VistaListaProcesses);
            this.Name = "ProcessListView";
            this.Size = new System.Drawing.Size(802, 481);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView VistaListaProcesses;
        private System.Windows.Forms.ColumnHeader Nombre;
        private System.Windows.Forms.ColumnHeader PID;
    }
}
