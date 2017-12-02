namespace Administracion
{
    partial class ABMComercio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABMComercio));
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
            this.cboHabilitado = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPadron = new System.Windows.Forms.TextBox();
            this.cboAccion = new System.Windows.Forms.ComboBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBanio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemIngresar,
            this.MenuItemModificar,
            this.MenuItemEliminar,
            this.MenuItemCancelar,
            this.MenuItemAyuda});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(629, 24);
            this.menuStrip1.TabIndex = 50;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemIngresar
            // 
            this.MenuItemIngresar.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemIngresar.Image")));
            this.MenuItemIngresar.Name = "MenuItemIngresar";
            this.MenuItemIngresar.Size = new System.Drawing.Size(77, 20);
            this.MenuItemIngresar.Text = "Ingresar";
            // 
            // MenuItemModificar
            // 
            this.MenuItemModificar.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemModificar.Image")));
            this.MenuItemModificar.Name = "MenuItemModificar";
            this.MenuItemModificar.Size = new System.Drawing.Size(86, 20);
            this.MenuItemModificar.Text = "Modificar";
            // 
            // MenuItemEliminar
            // 
            this.MenuItemEliminar.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemEliminar.Image")));
            this.MenuItemEliminar.Name = "MenuItemEliminar";
            this.MenuItemEliminar.Size = new System.Drawing.Size(78, 20);
            this.MenuItemEliminar.Text = "Eliminar";
            // 
            // MenuItemCancelar
            // 
            this.MenuItemCancelar.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemCancelar.Image")));
            this.MenuItemCancelar.Name = "MenuItemCancelar";
            this.MenuItemCancelar.Size = new System.Drawing.Size(81, 20);
            this.MenuItemCancelar.Text = "Cancelar";
            // 
            // MenuItemAyuda
            // 
            this.MenuItemAyuda.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemAyuda.Image")));
            this.MenuItemAyuda.Name = "MenuItemAyuda";
            this.MenuItemAyuda.Size = new System.Drawing.Size(69, 20);
            this.MenuItemAyuda.Text = "Ayuda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Padron";
            // 
            // ccZona
            // 
            this.ccZona.Codigo = "";
            this.ccZona.LetraDepto = "";
            this.ccZona.Location = new System.Drawing.Point(32, 274);
            this.ccZona.Name = "ccZona";
            this.ccZona.Size = new System.Drawing.Size(189, 52);
            this.ccZona.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Direccion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Precio";
            // 
            // cboHabilitado
            // 
            this.cboHabilitado.FormattingEnabled = true;
            this.cboHabilitado.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cboHabilitado.Location = new System.Drawing.Point(113, 247);
            this.cboHabilitado.Name = "cboHabilitado";
            this.cboHabilitado.Size = new System.Drawing.Size(100, 21);
            this.cboHabilitado.TabIndex = 9;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(113, 63);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 20);
            this.txtDireccion.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "Accion";
            // 
            // txtPadron
            // 
            this.txtPadron.Location = new System.Drawing.Point(113, 36);
            this.txtPadron.Name = "txtPadron";
            this.txtPadron.Size = new System.Drawing.Size(100, 20);
            this.txtPadron.TabIndex = 1;
            // 
            // cboAccion
            // 
            this.cboAccion.FormattingEnabled = true;
            this.cboAccion.Items.AddRange(new object[] {
            "ALQUILER",
            "VENTA",
            "PERMUTA"});
            this.cboAccion.Location = new System.Drawing.Point(113, 116);
            this.cboAccion.Name = "cboAccion";
            this.cboAccion.Size = new System.Drawing.Size(100, 21);
            this.cboAccion.TabIndex = 4;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(113, 89);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Baños";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(53, 250);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 70;
            this.label12.Text = "Habilitado";
            // 
            // txtBanio
            // 
            this.txtBanio.Location = new System.Drawing.Point(113, 143);
            this.txtBanio.Name = "txtBanio";
            this.txtBanio.Size = new System.Drawing.Size(100, 20);
            this.txtBanio.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Habitaciones";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(113, 221);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 8;
            // 
            // txtHabitaciones
            // 
            this.txtHabitaciones.Location = new System.Drawing.Point(113, 169);
            this.txtHabitaciones.Name = "txtHabitaciones";
            this.txtHabitaciones.Size = new System.Drawing.Size(100, 20);
            this.txtHabitaciones.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Mt2(Construccion)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 67;
            this.label10.Text = "Modificado Por";
            // 
            // txtMt2Const
            // 
            this.txtMt2Const.Location = new System.Drawing.Point(113, 195);
            this.txtMt2Const.Name = "txtMt2Const";
            this.txtMt2Const.Size = new System.Drawing.Size(100, 20);
            this.txtMt2Const.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensajes,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 426);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(629, 22);
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
            // ABMComercio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 448);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ccZona);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboHabilitado);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPadron);
            this.Controls.Add(this.cboAccion);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtBanio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtHabitaciones);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMt2Const);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ABMComercio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABMComercio";
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
        private System.Windows.Forms.ComboBox cboHabilitado;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPadron;
        private System.Windows.Forms.ComboBox cboAccion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBanio;
        private System.Windows.Forms.Label label6;
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