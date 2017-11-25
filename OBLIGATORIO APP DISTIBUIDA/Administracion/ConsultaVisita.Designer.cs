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
            this.gvVisitas = new System.Windows.Forms.DataGridView();
            this.cboAccion = new System.Windows.Forms.ComboBox();
            this.txtPadron = new System.Windows.Forms.TextBox();
            this.btnContarVisitas = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvVisitas)).BeginInit();
            this.SuspendLayout();
            // 
            // gvVisitas
            // 
            this.gvVisitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvVisitas.Location = new System.Drawing.Point(23, 159);
            this.gvVisitas.Name = "gvVisitas";
            this.gvVisitas.Size = new System.Drawing.Size(545, 150);
            this.gvVisitas.TabIndex = 0;
            // 
            // cboAccion
            // 
            this.cboAccion.FormattingEnabled = true;
            this.cboAccion.Items.AddRange(new object[] {
            "ALQUILER",
            "VENTA",
            "PERMUTA"});
            this.cboAccion.Location = new System.Drawing.Point(49, 44);
            this.cboAccion.Name = "cboAccion";
            this.cboAccion.Size = new System.Drawing.Size(121, 21);
            this.cboAccion.TabIndex = 1;
            // 
            // txtPadron
            // 
            this.txtPadron.Location = new System.Drawing.Point(192, 44);
            this.txtPadron.Name = "txtPadron";
            this.txtPadron.Size = new System.Drawing.Size(100, 20);
            this.txtPadron.TabIndex = 2;
            // 
            // btnContarVisitas
            // 
            this.btnContarVisitas.Location = new System.Drawing.Point(316, 42);
            this.btnContarVisitas.Name = "btnContarVisitas";
            this.btnContarVisitas.Size = new System.Drawing.Size(75, 23);
            this.btnContarVisitas.TabIndex = 3;
            this.btnContarVisitas.Text = "Visitas";
            this.btnContarVisitas.UseVisualStyleBackColor = true;
            this.btnContarVisitas.Click += new System.EventHandler(this.btnContarVisitas_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(397, 42);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(93, 23);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar Filtros";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // ConsultaVisita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 520);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnContarVisitas);
            this.Controls.Add(this.txtPadron);
            this.Controls.Add(this.cboAccion);
            this.Controls.Add(this.gvVisitas);
            this.Name = "ConsultaVisita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultaVisita";
            ((System.ComponentModel.ISupportInitialize)(this.gvVisitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvVisitas;
        private System.Windows.Forms.ComboBox cboAccion;
        private System.Windows.Forms.TextBox txtPadron;
        private System.Windows.Forms.Button btnContarVisitas;
        private System.Windows.Forms.Button btnLimpiar;
    }
}