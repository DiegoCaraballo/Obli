namespace Administracion
{
    partial class Login
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

  
        private void InitializeComponent()
        {
            this.lblMensaje = new System.Windows.Forms.Label();
            this.ccLogin = new Controles.Logueo();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(60, 240);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 13);
            this.lblMensaje.TabIndex = 0;
            // 
            // ccLogin
            // 
            this.ccLogin.Location = new System.Drawing.Point(166, 43);
            this.ccLogin.Name = "ccLogin";
            this.ccLogin.Size = new System.Drawing.Size(245, 105);
            this.ccLogin.TabIndex = 1;
            this.ccLogin.Click += new System.EventHandler(this.ccLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 297);
            this.Controls.Add(this.ccLogin);
            this.Controls.Add(this.lblMensaje);
            this.Name = "Login";
            this.Text = "Bienvenido a Bios Real State";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.Logueo logueo1;
        private System.Windows.Forms.Label lblMensaje;
        private Controles.Logueo logueo2;
        private Controles.Logueo ccLogin;

    }
}