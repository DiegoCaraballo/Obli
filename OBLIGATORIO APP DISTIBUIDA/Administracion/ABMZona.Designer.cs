namespace Administracion
{
    partial class ABMZona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABMZona));
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.txtServicio = new System.Windows.Forms.TextBox();
            this.txtHabitantes = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbServicios = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemIngresar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOtros = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMZonaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCASAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMAptoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Items.AddRange(new object[] {
            "Artigas",
            "Canelones"});
            this.cboDepartamento.Location = new System.Drawing.Point(110, 64);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(100, 21);
            this.cboDepartamento.TabIndex = 48;
            // 
            // txtServicio
            // 
            this.txtServicio.Location = new System.Drawing.Point(110, 146);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.Size = new System.Drawing.Size(100, 20);
            this.txtServicio.TabIndex = 41;
            // 
            // txtHabitantes
            // 
            this.txtHabitantes.Location = new System.Drawing.Point(109, 117);
            this.txtHabitantes.Name = "txtHabitantes";
            this.txtHabitantes.Size = new System.Drawing.Size(100, 20);
            this.txtHabitantes.TabIndex = 40;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(109, 91);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 39;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(110, 40);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Servicios";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Departamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Habitantes";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(44, 91);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 27;
            this.lblNombre.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Codigo";
            // 
            // lbServicios
            // 
            this.lbServicios.FormattingEnabled = true;
            this.lbServicios.Location = new System.Drawing.Point(109, 172);
            this.lbServicios.Name = "lbServicios";
            this.lbServicios.Size = new System.Drawing.Size(120, 95);
            this.lbServicios.TabIndex = 49;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemBuscar,
            this.MenuItemIngresar,
            this.MenuItemModificar,
            this.MenuItemEliminar,
            this.MenuItemCancelar,
            this.MenuItemOtros,
            this.MenuItemAyuda});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(605, 24);
            this.menuStrip1.TabIndex = 50;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemBuscar
            // 
            this.MenuItemBuscar.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemBuscar.Image")));
            this.MenuItemBuscar.Name = "MenuItemBuscar";
            this.MenuItemBuscar.Size = new System.Drawing.Size(70, 20);
            this.MenuItemBuscar.Text = "Buscar";
            this.MenuItemBuscar.Click += new System.EventHandler(this.MenuItemBuscar_Click);
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
            this.MenuItemCancelar.Click += new System.EventHandler(this.MenuItemCancelar_Click);
            // 
            // MenuItemOtros
            // 
            this.MenuItemOtros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMEmpleadoToolStripMenuItem,
            this.aBMZonaToolStripMenuItem,
            this.aBMCASAToolStripMenuItem,
            this.aBMAptoToolStripMenuItem});
            this.MenuItemOtros.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemOtros.Image")));
            this.MenuItemOtros.Name = "MenuItemOtros";
            this.MenuItemOtros.Size = new System.Drawing.Size(64, 20);
            this.MenuItemOtros.Text = "Otros";
            // 
            // aBMEmpleadoToolStripMenuItem
            // 
            this.aBMEmpleadoToolStripMenuItem.Name = "aBMEmpleadoToolStripMenuItem";
            this.aBMEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.aBMEmpleadoToolStripMenuItem.Text = "ABM Empleado";
            // 
            // aBMZonaToolStripMenuItem
            // 
            this.aBMZonaToolStripMenuItem.Name = "aBMZonaToolStripMenuItem";
            this.aBMZonaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.aBMZonaToolStripMenuItem.Text = "ABM Apto";
            // 
            // aBMCASAToolStripMenuItem
            // 
            this.aBMCASAToolStripMenuItem.Name = "aBMCASAToolStripMenuItem";
            this.aBMCASAToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.aBMCASAToolStripMenuItem.Text = "ABM Casa";
            // 
            // aBMAptoToolStripMenuItem
            // 
            this.aBMAptoToolStripMenuItem.Name = "aBMAptoToolStripMenuItem";
            this.aBMAptoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.aBMAptoToolStripMenuItem.Text = "ABM Comercio";
            // 
            // MenuItemAyuda
            // 
            this.MenuItemAyuda.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemAyuda.Image")));
            this.MenuItemAyuda.Name = "MenuItemAyuda";
            this.MenuItemAyuda.Size = new System.Drawing.Size(69, 20);
            this.MenuItemAyuda.Text = "Ayuda";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(44, 172);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 23);
            this.btnAgregar.TabIndex = 51;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(44, 201);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(60, 23);
            this.btnBorrar.TabIndex = 52;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(110, 293);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 13);
            this.lblMensaje.TabIndex = 53;
            // 
            // ABMZona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 372);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lbServicios);
            this.Controls.Add(this.cboDepartamento);
            this.Controls.Add(this.txtServicio);
            this.Controls.Add(this.txtHabitantes);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label1);
            this.Name = "ABMZona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABMZona";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.TextBox txtServicio;
        private System.Windows.Forms.TextBox txtHabitantes;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbServicios;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemBuscar;
        private System.Windows.Forms.ToolStripMenuItem MenuItemIngresar;
        private System.Windows.Forms.ToolStripMenuItem MenuItemModificar;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEliminar;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCancelar;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOtros;
        private System.Windows.Forms.ToolStripMenuItem aBMEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMZonaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMCASAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMAptoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAyuda;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label lblMensaje;
    }
}