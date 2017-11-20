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
            // ConsultaVisita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 520);
            this.Controls.Add(this.gvVisitas);
            this.Name = "ConsultaVisita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultaVisita";
            ((System.ComponentModel.ISupportInitialize)(this.gvVisitas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvVisitas;
    }
}