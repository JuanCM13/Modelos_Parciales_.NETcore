
namespace Senado
{
    partial class FrmSenado
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnActivarSesion = new System.Windows.Forms.Button();
            this.btnVotar = new System.Windows.Forms.Button();
            this.lblAfirmativos = new System.Windows.Forms.Label();
            this.lblNegativos = new System.Windows.Forms.Label();
            this.lblAbstenciones = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnActivarSesion
            // 
            this.btnActivarSesion.Location = new System.Drawing.Point(574, 252);
            this.btnActivarSesion.Name = "btnActivarSesion";
            this.btnActivarSesion.Size = new System.Drawing.Size(104, 52);
            this.btnActivarSesion.TabIndex = 0;
            this.btnActivarSesion.Text = "Activar Sesión";
            this.btnActivarSesion.UseVisualStyleBackColor = true;
            this.btnActivarSesion.Click += new System.EventHandler(this.btnActivarSesion_Click);
            // 
            // btnVotar
            // 
            this.btnVotar.Enabled = false;
            this.btnVotar.Location = new System.Drawing.Point(684, 252);
            this.btnVotar.Name = "btnVotar";
            this.btnVotar.Size = new System.Drawing.Size(104, 52);
            this.btnVotar.TabIndex = 1;
            this.btnVotar.Text = "Votar";
            this.btnVotar.UseVisualStyleBackColor = true;
            this.btnVotar.Click += new System.EventHandler(this.btnVotar_Click);
            // 
            // lblAfirmativos
            // 
            this.lblAfirmativos.AutoSize = true;
            this.lblAfirmativos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAfirmativos.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAfirmativos.Location = new System.Drawing.Point(37, 259);
            this.lblAfirmativos.Name = "lblAfirmativos";
            this.lblAfirmativos.Size = new System.Drawing.Size(37, 30);
            this.lblAfirmativos.TabIndex = 2;
            this.lblAfirmativos.Text = "00";
            // 
            // lblNegativos
            // 
            this.lblNegativos.AutoSize = true;
            this.lblNegativos.BackColor = System.Drawing.Color.Red;
            this.lblNegativos.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNegativos.Location = new System.Drawing.Point(109, 259);
            this.lblNegativos.Name = "lblNegativos";
            this.lblNegativos.Size = new System.Drawing.Size(37, 30);
            this.lblNegativos.TabIndex = 3;
            this.lblNegativos.Text = "00";
            // 
            // lblAbstenciones
            // 
            this.lblAbstenciones.AutoSize = true;
            this.lblAbstenciones.BackColor = System.Drawing.Color.Yellow;
            this.lblAbstenciones.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAbstenciones.Location = new System.Drawing.Point(181, 259);
            this.lblAbstenciones.Name = "lblAbstenciones";
            this.lblAbstenciones.Size = new System.Drawing.Size(37, 30);
            this.lblAbstenciones.TabIndex = 4;
            this.lblAbstenciones.Text = "00";
            // 
            // FrmSenado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 316);
            this.Controls.Add(this.lblAbstenciones);
            this.Controls.Add(this.lblNegativos);
            this.Controls.Add(this.lblAfirmativos);
            this.Controls.Add(this.btnVotar);
            this.Controls.Add(this.btnActivarSesion);
            this.Name = "FrmSenado";
            this.Text = "Senado";
            this.Load += new System.EventHandler(this.FrmSenado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActivarSesion;
        private System.Windows.Forms.Button btnVotar;
        private System.Windows.Forms.Label lblAfirmativos;
        private System.Windows.Forms.Label lblNegativos;
        private System.Windows.Forms.Label lblAbstenciones;
    }
}

