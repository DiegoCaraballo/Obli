namespace Administracion
{
    partial class ABMCasa
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABMCasa));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemIngresar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.ccZona = new Controles.CodigoDpto();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFondo = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPadron = new System.Windows.Forms.TextBox();
            this.cboAccion = new System.Windows.Forms.ComboBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFondo = new System.Windows.Forms.Label();
            this.txtMt2Terreno = new System.Windows.Forms.TextBox();
            this.txtBanio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtHabitaciones = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMt2Const = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensajes = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.EPPadron = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPPadron)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe Print", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemIngresar,
            this.MenuItemModificar,
            this.MenuItemEliminar,
            this.MenuItemCancelar,
            this.MenuItemAyuda});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(111, 472);
            this.menuStrip1.TabIndex = 50;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemIngresar
            // 
            this.MenuItemIngresar.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemIngresar.Image")));
            this.MenuItemIngresar.Name = "MenuItemIngresar";
            this.MenuItemIngresar.Size = new System.Drawing.Size(94, 28);
            this.MenuItemIngresar.Text = "Ingresar";
            this.MenuItemIngresar.Click += new System.EventHandler(this.MenuItemIngresar_Click);
            // 
            // MenuItemModificar
            // 
            this.MenuItemModificar.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemModificar.Image")));
            this.MenuItemModificar.Name = "MenuItemModificar";
            this.MenuItemModificar.Size = new System.Drawing.Size(94, 28);
            this.MenuItemModificar.Text = "Modificar";
            this.MenuItemModificar.Click += new System.EventHandler(this.MenuItemModificar_Click);
            // 
            // MenuItemEliminar
            // 
            this.MenuItemEliminar.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemEliminar.Image")));
            this.MenuItemEliminar.Name = "MenuItemEliminar";
            this.MenuItemEliminar.Size = new System.Drawing.Size(94, 28);
            this.MenuItemEliminar.Text = "Eliminar";
            this.MenuItemEliminar.Click += new System.EventHandler(this.MenuItemEliminar_Click);
            // 
            // MenuItemCancelar
            // 
            this.MenuItemCancelar.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemCancelar.Image")));
            this.MenuItemCancelar.Name = "MenuItemCancelar";
            this.MenuItemCancelar.Size = new System.Drawing.Size(94, 28);
            this.MenuItemCancelar.Text = "Cancelar";
            this.MenuItemCancelar.Click += new System.EventHandler(this.MenuItemCancelar_Click);
            // 
            // MenuItemAyuda
            // 
            this.MenuItemAyuda.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemAyuda.Image")));
            this.MenuItemAyuda.Name = "MenuItemAyuda";
            this.MenuItemAyuda.Size = new System.Drawing.Size(94, 28);
            this.MenuItemAyuda.Text = "Ayuda";
            this.MenuItemAyuda.Click += new System.EventHandler(this.MenuItemAyuda_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 51;
            this.label1.Text = "Padron";
            // 
            // ccZona
            // 
            this.ccZona.Codigo = "";
            this.ccZona.LetraDepto = "";
            this.ccZona.Location = new System.Drawing.Point(182, 333);
            this.ccZona.Margin = new System.Windows.Forms.Padding(4);
            this.ccZona.Name = "ccZona";
            this.ccZona.Size = new System.Drawing.Size(260, 72);
            this.ccZona.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 53;
            this.label2.Text = "Direccion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 18);
            this.label3.TabIndex = 54;
            this.label3.Text = "Precio";
            // 
            // cboFondo
            // 
            this.cboFondo.FormattingEnabled = true;
            this.cboFondo.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cboFondo.Location = new System.Drawing.Point(294, 302);
            this.cboFondo.Margin = new System.Windows.Forms.Padding(4);
            this.cboFondo.Name = "cboFondo";
            this.cboFondo.Size = new System.Drawing.Size(132, 26);
            this.cboFondo.TabIndex = 10;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(294, 37);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(132, 25);
            this.txtDireccion.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 18);
            this.label4.TabIndex = 56;
            this.label4.Text = "Accion";
            // 
            // txtPadron
            // 
            this.txtPadron.Location = new System.Drawing.Point(294, 5);
            this.txtPadron.Margin = new System.Windows.Forms.Padding(4);
            this.txtPadron.Name = "txtPadron";
            this.txtPadron.Size = new System.Drawing.Size(132, 25);
            this.txtPadron.TabIndex = 1;
            this.txtPadron.Validating += new System.ComponentModel.CancelEventHandler(this.txtPadron_Validating);
            // 
            // cboAccion
            // 
            this.cboAccion.FormattingEnabled = true;
            this.cboAccion.Items.AddRange(new object[] {
            "ALQUILER",
            "VENTA",
            "PERMUTA"});
            this.cboAccion.Location = new System.Drawing.Point(294, 103);
            this.cboAccion.Margin = new System.Windows.Forms.Padding(4);
            this.cboAccion.Name = "cboAccion";
            this.cboAccion.Size = new System.Drawing.Size(132, 26);
            this.cboAccion.TabIndex = 4;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(294, 70);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(132, 25);
            this.txtPrecio.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 144);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 58;
            this.label5.Text = "Baños";
            // 
            // txtFondo
            // 
            this.txtFondo.AutoSize = true;
            this.txtFondo.Location = new System.Drawing.Point(231, 310);
            this.txtFondo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtFondo.Name = "txtFondo";
            this.txtFondo.Size = new System.Drawing.Size(45, 18);
            this.txtFondo.TabIndex = 70;
            this.txtFondo.Text = "Fondo";
            // 
            // txtMt2Terreno
            // 
            this.txtMt2Terreno.Location = new System.Drawing.Point(294, 269);
            this.txtMt2Terreno.Margin = new System.Windows.Forms.Padding(4);
            this.txtMt2Terreno.Name = "txtMt2Terreno";
            this.txtMt2Terreno.Size = new System.Drawing.Size(132, 25);
            this.txtMt2Terreno.TabIndex = 9;
            // 
            // txtBanio
            // 
            this.txtBanio.Location = new System.Drawing.Point(294, 137);
            this.txtBanio.Margin = new System.Windows.Forms.Padding(4);
            this.txtBanio.Name = "txtBanio";
            this.txtBanio.Size = new System.Drawing.Size(132, 25);
            this.txtBanio.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 177);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 18);
            this.label6.TabIndex = 61;
            this.label6.Text = "Habitaciones";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(195, 276);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 18);
            this.label11.TabIndex = 69;
            this.label11.Text = "Mt2(Terreno)";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(294, 236);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(132, 25);
            this.txtUser.TabIndex = 8;
            // 
            // txtHabitaciones
            // 
            this.txtHabitaciones.Location = new System.Drawing.Point(294, 170);
            this.txtHabitaciones.Margin = new System.Windows.Forms.Padding(4);
            this.txtHabitaciones.Name = "txtHabitaciones";
            this.txtHabitaciones.Size = new System.Drawing.Size(132, 25);
            this.txtHabitaciones.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(166, 210);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 18);
            this.label7.TabIndex = 63;
            this.label7.Text = "Mt2(Construccion)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(179, 243);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 18);
            this.label10.TabIndex = 67;
            this.label10.Text = "Modificado Por";
            // 
            // txtMt2Const
            // 
            this.txtMt2Const.Location = new System.Drawing.Point(294, 203);
            this.txtMt2Const.Margin = new System.Windows.Forms.Padding(4);
            this.txtMt2Const.Name = "txtMt2Const";
            this.txtMt2Const.Size = new System.Drawing.Size(132, 25);
            this.txtMt2Const.TabIndex = 8;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensajes,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(111, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(503, 22);
            this.statusStrip1.TabIndex = 71;
            // 
            // lblMensajes
            // 
            this.lblMensajes.Name = "lblMensajes";
            this.lblMensajes.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // EPPadron
            // 
            this.EPPadron.ContainerControl = this;
            // 
            // ABMCasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(614, 472);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ccZona);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboFondo);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPadron);
            this.Controls.Add(this.cboAccion);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFondo);
            this.Controls.Add(this.txtMt2Terreno);
            this.Controls.Add(this.txtBanio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtHabitaciones);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMt2Const);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ABMCasa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABMCasa";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPPadron)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemIngresar;
        private System.Windows.Forms.ToolStripMenuItem MenuItemModificar;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEliminar;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCancelar;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAyuda;
        private System.Windows.Forms.Label label1;
        private Controles.CodigoDpto ccZona;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFondo;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPadron;
        private System.Windows.Forms.ComboBox cboAccion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtFondo;
        private System.Windows.Forms.TextBox txtMt2Terreno;
        private System.Windows.Forms.TextBox txtBanio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtHabitaciones;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMt2Const;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMensajes;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ErrorProvider EPPadron;
    }
}