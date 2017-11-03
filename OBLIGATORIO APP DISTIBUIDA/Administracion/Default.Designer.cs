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
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(241, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(252, 17);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Bienvenido al Sistema de Gestion";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoToolStripMenuItem,
            this.visitasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(702, 24);
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
            this.mantenimientoToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.mantenimientoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // aBMEmleadosToolStripMenuItem
            // 
            this.aBMEmleadosToolStripMenuItem.Name = "aBMEmleadosToolStripMenuItem";
            this.aBMEmleadosToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.aBMEmleadosToolStripMenuItem.Text = "ABM Emleado";
            this.aBMEmleadosToolStripMenuItem.Click += new System.EventHandler(this.aBMEmleadosToolStripMenuItem_Click);
            // 
            // aBMZonasToolStripMenuItem
            // 
            this.aBMZonasToolStripMenuItem.Name = "aBMZonasToolStripMenuItem";
            this.aBMZonasToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.aBMZonasToolStripMenuItem.Text = "ABM Zonas";
            this.aBMZonasToolStripMenuItem.Click += new System.EventHandler(this.aBMZonasToolStripMenuItem_Click_1);
            // 
            // aBMCasasToolStripMenuItem
            // 
            this.aBMCasasToolStripMenuItem.Name = "aBMCasasToolStripMenuItem";
            this.aBMCasasToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.aBMCasasToolStripMenuItem.Text = "ABM Casas";
            this.aBMCasasToolStripMenuItem.Click += new System.EventHandler(this.aBMCasasToolStripMenuItem_Click);
            // 
            // aBMApartamentoToolStripMenuItem
            // 
            this.aBMApartamentoToolStripMenuItem.Name = "aBMApartamentoToolStripMenuItem";
            this.aBMApartamentoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.aBMApartamentoToolStripMenuItem.Text = "ABM Apartamento";
            this.aBMApartamentoToolStripMenuItem.Click += new System.EventHandler(this.aBMApartamentoToolStripMenuItem_Click);
            // 
            // aBMLocalComercialToolStripMenuItem
            // 
            this.aBMLocalComercialToolStripMenuItem.Name = "aBMLocalComercialToolStripMenuItem";
            this.aBMLocalComercialToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.aBMLocalComercialToolStripMenuItem.Text = "ABM Local Comercial";
            this.aBMLocalComercialToolStripMenuItem.Click += new System.EventHandler(this.aBMLocalComercialToolStripMenuItem_Click);
            // 
            // visitasToolStripMenuItem
            // 
            this.visitasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaDeVisitasToolStripMenuItem});
            this.visitasToolStripMenuItem.Name = "visitasToolStripMenuItem";
            this.visitasToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.visitasToolStripMenuItem.Text = "Visitas";
            // 
            // consultaDeVisitasToolStripMenuItem
            // 
            this.consultaDeVisitasToolStripMenuItem.Name = "consultaDeVisitasToolStripMenuItem";
            this.consultaDeVisitasToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.consultaDeVisitasToolStripMenuItem.Text = "Consulta de Visitas";
            this.consultaDeVisitasToolStripMenuItem.Click += new System.EventHandler(this.consultaDeVisitasToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(678, 401);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 465);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Default";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
    }
}