namespace Administracion
{
    partial class ABMEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABMEmpleado));
            this.MenuItemEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemIngresar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.EPUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPUsuario)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuItemEliminar
            // 
            this.MenuItemEliminar.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemEliminar.Image")));
            this.MenuItemEliminar.Name = "MenuItemEliminar";
            this.MenuItemEliminar.Size = new System.Drawing.Size(78, 20);
            this.MenuItemEliminar.Text = "Eliminar";
            this.MenuItemEliminar.Click += new System.EventHandler(this.MenuItemEliminar_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(106, 101);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(106, 75);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsuario_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Contraseña";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(41, 75);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(43, 13);
            this.lblNombre.TabIndex = 41;
            this.lblNombre.Text = "Usuario";
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
            this.menuStrip1.Size = new System.Drawing.Size(586, 24);
            this.menuStrip1.TabIndex = 45;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemIngresar
            // 
            this.MenuItemIngresar.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemIngresar.Image")));
            this.MenuItemIngresar.Name = "MenuItemIngresar";
            this.MenuItemIngresar.Size = new System.Drawing.Size(77, 20);
            this.MenuItemIngresar.Text = "Ingresar";
            this.MenuItemIngresar.Click += new System.EventHandler(this.MenuItemIngresar_Click);
            // 
            // MenuItemModificar
            // 
            this.MenuItemModificar.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemModificar.Image")));
            this.MenuItemModificar.Name = "MenuItemModificar";
            this.MenuItemModificar.Size = new System.Drawing.Size(86, 20);
            this.MenuItemModificar.Text = "Modificar";
            this.MenuItemModificar.Click += new System.EventHandler(this.MenuItemModificar_Click);
            // 
            // MenuItemCancelar
            // 
            this.MenuItemCancelar.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemCancelar.Image")));
            this.MenuItemCancelar.Name = "MenuItemCancelar";
            this.MenuItemCancelar.Size = new System.Drawing.Size(81, 20);
            this.MenuItemCancelar.Text = "Cancelar";
            this.MenuItemCancelar.Click += new System.EventHandler(this.MenuItemCancelar_Click);
            // 
            // MenuItemAyuda
            // 
            this.MenuItemAyuda.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemAyuda.Image")));
            this.MenuItemAyuda.Name = "MenuItemAyuda";
            this.MenuItemAyuda.Size = new System.Drawing.Size(69, 20);
            this.MenuItemAyuda.Text = "Ayuda";
            // 
            // EPUsuario
            // 
            this.EPUsuario.ContainerControl = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 408);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(586, 22);
            this.statusStrip1.TabIndex = 46;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 17);
            // 
            // ABMEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 430);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNombre);
            this.Name = "ABMEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABMEmpleado";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPUsuario)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemIngresar;
        private System.Windows.Forms.ToolStripMenuItem MenuItemModificar;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCancelar;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAyuda;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEliminar;
        private System.Windows.Forms.ErrorProvider EPUsuario;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
    }
}