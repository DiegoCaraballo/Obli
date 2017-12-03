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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Default));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMEmleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMZonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCasasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMApartamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMLocalComercialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeVisitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ssmensajes = new System.Windows.Forms.StatusStrip();
            this.lblUSU = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ssmensajes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.LightBlue;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(396, 4);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(244, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Bienvenido al Sistema de Gestion";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe Print", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoToolStripMenuItem,
            this.visitasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(892, 34);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mantenimientoToolStripMenuItem
            // 
            this.mantenimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMEmleadosToolStripMenuItem,
            this.aBMZonasToolStripMenuItem,
            this.aBMCasasToolStripMenuItem,
            this.aBMApartamentoToolStripMenuItem,
            this.aBMLocalComercialToolStripMenuItem});
            this.mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            this.mantenimientoToolStripMenuItem.Size = new System.Drawing.Size(128, 28);
            this.mantenimientoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // aBMEmleadosToolStripMenuItem
            // 
            this.aBMEmleadosToolStripMenuItem.Name = "aBMEmleadosToolStripMenuItem";
            this.aBMEmleadosToolStripMenuItem.Size = new System.Drawing.Size(231, 28);
            this.aBMEmleadosToolStripMenuItem.Text = "ABM Emleado";
            this.aBMEmleadosToolStripMenuItem.Click += new System.EventHandler(this.aBMEmleadosToolStripMenuItem_Click);
            // 
            // aBMZonasToolStripMenuItem
            // 
            this.aBMZonasToolStripMenuItem.Name = "aBMZonasToolStripMenuItem";
            this.aBMZonasToolStripMenuItem.Size = new System.Drawing.Size(231, 28);
            this.aBMZonasToolStripMenuItem.Text = "ABM Zonas";
            this.aBMZonasToolStripMenuItem.Click += new System.EventHandler(this.aBMZonasToolStripMenuItem_Click_1);
            // 
            // aBMCasasToolStripMenuItem
            // 
            this.aBMCasasToolStripMenuItem.Name = "aBMCasasToolStripMenuItem";
            this.aBMCasasToolStripMenuItem.Size = new System.Drawing.Size(231, 28);
            this.aBMCasasToolStripMenuItem.Text = "ABM Casas";
            this.aBMCasasToolStripMenuItem.Click += new System.EventHandler(this.aBMCasasToolStripMenuItem_Click);
            // 
            // aBMApartamentoToolStripMenuItem
            // 
            this.aBMApartamentoToolStripMenuItem.Name = "aBMApartamentoToolStripMenuItem";
            this.aBMApartamentoToolStripMenuItem.Size = new System.Drawing.Size(231, 28);
            this.aBMApartamentoToolStripMenuItem.Text = "ABM Apartamento";
            this.aBMApartamentoToolStripMenuItem.Click += new System.EventHandler(this.aBMApartamentoToolStripMenuItem_Click);
            // 
            // aBMLocalComercialToolStripMenuItem
            // 
            this.aBMLocalComercialToolStripMenuItem.Name = "aBMLocalComercialToolStripMenuItem";
            this.aBMLocalComercialToolStripMenuItem.Size = new System.Drawing.Size(231, 28);
            this.aBMLocalComercialToolStripMenuItem.Text = "ABM Local Comercial";
            this.aBMLocalComercialToolStripMenuItem.Click += new System.EventHandler(this.aBMLocalComercialToolStripMenuItem_Click);
            // 
            // visitasToolStripMenuItem
            // 
            this.visitasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaDeVisitasToolStripMenuItem});
            this.visitasToolStripMenuItem.Name = "visitasToolStripMenuItem";
            this.visitasToolStripMenuItem.Size = new System.Drawing.Size(67, 28);
            this.visitasToolStripMenuItem.Text = "Visitas";
            // 
            // consultaDeVisitasToolStripMenuItem
            // 
            this.consultaDeVisitasToolStripMenuItem.Name = "consultaDeVisitasToolStripMenuItem";
            this.consultaDeVisitasToolStripMenuItem.Size = new System.Drawing.Size(214, 28);
            this.consultaDeVisitasToolStripMenuItem.Text = "Consulta de Visitas";
            this.consultaDeVisitasToolStripMenuItem.Click += new System.EventHandler(this.consultaDeVisitasToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-5, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(901, 504);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
          
            // 
            // ssmensajes
            // 
            this.ssmensajes.BackColor = System.Drawing.Color.LightBlue;
            this.ssmensajes.Font = new System.Drawing.Font("Segoe Print", 10F);
            this.ssmensajes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUSU});
            this.ssmensajes.Location = new System.Drawing.Point(0, 524);
            this.ssmensajes.Name = "ssmensajes";
            this.ssmensajes.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.ssmensajes.Size = new System.Drawing.Size(892, 22);
            this.ssmensajes.TabIndex = 3;
            // 
            // lblUSU
            // 
            this.lblUSU.Name = "lblUSU";
            this.lblUSU.Size = new System.Drawing.Size(0, 17);
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 546);
            this.Controls.Add(this.ssmensajes);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Default";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ssmensajes.ResumeLayout(false);
            this.ssmensajes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMEmleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMZonasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMCasasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMApartamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMLocalComercialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDeVisitasToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip ssmensajes;
        private System.Windows.Forms.ToolStripStatusLabel lblUSU;
    }
}