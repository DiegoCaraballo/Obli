namespace Administracion
{
    partial class Default
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aBMPropiedadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCasaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMAptoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMComercioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMZonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(241, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(165, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Bienvenido al Sistema de Gestion";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMPropiedadesToolStripMenuItem,
            this.aBMEmpleadoToolStripMenuItem,
            this.aBMZonasToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(119, 465);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aBMPropiedadesToolStripMenuItem
            // 
            this.aBMPropiedadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMCasaToolStripMenuItem,
            this.aBMAptoToolStripMenuItem,
            this.aBMComercioToolStripMenuItem});
            this.aBMPropiedadesToolStripMenuItem.Name = "aBMPropiedadesToolStripMenuItem";
            this.aBMPropiedadesToolStripMenuItem.Size = new System.Drawing.Size(106, 19);
            this.aBMPropiedadesToolStripMenuItem.Text = "ABM Propiedades";
            // 
            // aBMCasaToolStripMenuItem
            // 
            this.aBMCasaToolStripMenuItem.Name = "aBMCasaToolStripMenuItem";
            this.aBMCasaToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.aBMCasaToolStripMenuItem.Text = "ABM Casa";
            this.aBMCasaToolStripMenuItem.Click += new System.EventHandler(this.aBMCasaToolStripMenuItem_Click);
            // 
            // aBMAptoToolStripMenuItem
            // 
            this.aBMAptoToolStripMenuItem.Name = "aBMAptoToolStripMenuItem";
            this.aBMAptoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.aBMAptoToolStripMenuItem.Text = "ABM Apto";
            this.aBMAptoToolStripMenuItem.Click += new System.EventHandler(this.aBMAptoToolStripMenuItem_Click);
            // 
            // aBMComercioToolStripMenuItem
            // 
            this.aBMComercioToolStripMenuItem.Name = "aBMComercioToolStripMenuItem";
            this.aBMComercioToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.aBMComercioToolStripMenuItem.Text = "ABM Comercio";
            this.aBMComercioToolStripMenuItem.Click += new System.EventHandler(this.aBMComercioToolStripMenuItem_Click);
            // 
            // aBMEmpleadoToolStripMenuItem
            // 
            this.aBMEmpleadoToolStripMenuItem.Name = "aBMEmpleadoToolStripMenuItem";
            this.aBMEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(106, 19);
            this.aBMEmpleadoToolStripMenuItem.Text = "ABM Empleado";
            this.aBMEmpleadoToolStripMenuItem.Click += new System.EventHandler(this.aBMEmpleadoToolStripMenuItem_Click);
            // 
            // aBMZonasToolStripMenuItem
            // 
            this.aBMZonasToolStripMenuItem.Name = "aBMZonasToolStripMenuItem";
            this.aBMZonasToolStripMenuItem.Size = new System.Drawing.Size(106, 19);
            this.aBMZonasToolStripMenuItem.Text = "ABM Zonas";
            this.aBMZonasToolStripMenuItem.Click += new System.EventHandler(this.aBMZonasToolStripMenuItem_Click);
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 465);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Default";
            this.Text = "Default";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aBMPropiedadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMCasaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMAptoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMComercioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMZonasToolStripMenuItem;
    }
}