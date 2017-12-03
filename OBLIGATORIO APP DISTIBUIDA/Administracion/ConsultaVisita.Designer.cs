namespace Administracion
{
    partial class ConsultaVisita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaVisita));
            this.gvVisitas = new System.Windows.Forms.DataGridView();
            this.cboAccion = new System.Windows.Forms.ComboBox();
            this.txtPadron = new System.Windows.Forms.TextBox();
            this.btnContarVisitas = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.EPPadron = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvVisitas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EPPadron)).BeginInit();
            this.SuspendLayout();
            // 
            // gvVisitas
            // 
            this.gvVisitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvVisitas.Location = new System.Drawing.Point(16, 158);
            this.gvVisitas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gvVisitas.Name = "gvVisitas";
            this.gvVisitas.Size = new System.Drawing.Size(745, 508);
            this.gvVisitas.TabIndex = 0;
            // 
            // cboAccion
            // 
            this.cboAccion.FormattingEnabled = true;
            this.cboAccion.Items.AddRange(new object[] {
            "--Seleccione Opcion--",
            "ALQUILER",
            "VENTA",
            "PERMUTA"});
            this.cboAccion.Location = new System.Drawing.Point(65, 61);
            this.cboAccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboAccion.Name = "cboAccion";
            this.cboAccion.Size = new System.Drawing.Size(160, 26);
            this.cboAccion.TabIndex = 1;
            this.cboAccion.SelectedIndexChanged += new System.EventHandler(this.cboAccion_SelectedIndexChanged);
            // 
            // txtPadron
            // 
            this.txtPadron.Location = new System.Drawing.Point(256, 61);
            this.txtPadron.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPadron.Name = "txtPadron";
            this.txtPadron.Size = new System.Drawing.Size(132, 25);
            this.txtPadron.TabIndex = 2;
            this.txtPadron.Validating += new System.ComponentModel.CancelEventHandler(this.txtPadron_Validating);
            // 
            // btnContarVisitas
            // 
            this.btnContarVisitas.Location = new System.Drawing.Point(421, 58);
            this.btnContarVisitas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnContarVisitas.Name = "btnContarVisitas";
            this.btnContarVisitas.Size = new System.Drawing.Size(100, 32);
            this.btnContarVisitas.TabIndex = 3;
            this.btnContarVisitas.Text = "Visitas";
            this.btnContarVisitas.UseVisualStyleBackColor = true;
            this.btnContarVisitas.Click += new System.EventHandler(this.btnContarVisitas_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(529, 58);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(124, 32);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar Filtros";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // EPPadron
            // 
            this.EPPadron.ContainerControl = this;
            // 
            // ConsultaVisita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(783, 720);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnContarVisitas);
            this.Controls.Add(this.txtPadron);
            this.Controls.Add(this.cboAccion);
            this.Controls.Add(this.gvVisitas);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ConsultaVisita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultaVisita";
            ((System.ComponentModel.ISupportInitialize)(this.gvVisitas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EPPadron)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvVisitas;
        private System.Windows.Forms.ComboBox cboAccion;
        private System.Windows.Forms.TextBox txtPadron;
        private System.Windows.Forms.Button btnContarVisitas;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ErrorProvider EPPadron;
    }
}