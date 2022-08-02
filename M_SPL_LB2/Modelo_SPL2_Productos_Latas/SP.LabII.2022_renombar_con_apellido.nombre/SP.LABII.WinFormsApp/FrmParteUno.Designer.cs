
namespace SP.LABII.WinFormsApp
{
    partial class FrmParteUno
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
            this.btnPunto1 = new System.Windows.Forms.Button();
            this.btnPunto2 = new System.Windows.Forms.Button();
            this.btnPunto3 = new System.Windows.Forms.Button();
            this.btnPunto4 = new System.Windows.Forms.Button();
            this.btnPunto5 = new System.Windows.Forms.Button();
            this.lstVisor = new System.Windows.Forms.ListBox();
            this.btnVerLog = new System.Windows.Forms.Button();
            this.btnHilos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPunto1
            // 
            this.btnPunto1.Location = new System.Drawing.Point(12, 12);
            this.btnPunto1.Name = "btnPunto1";
            this.btnPunto1.Size = new System.Drawing.Size(75, 23);
            this.btnPunto1.TabIndex = 0;
            this.btnPunto1.Text = "Punto 1";
            this.btnPunto1.UseVisualStyleBackColor = true;
            // 
            // btnPunto2
            // 
            this.btnPunto2.Location = new System.Drawing.Point(93, 12);
            this.btnPunto2.Name = "btnPunto2";
            this.btnPunto2.Size = new System.Drawing.Size(75, 23);
            this.btnPunto2.TabIndex = 1;
            this.btnPunto2.Text = "Punto 2";
            this.btnPunto2.UseVisualStyleBackColor = true;
            // 
            // btnPunto3
            // 
            this.btnPunto3.Location = new System.Drawing.Point(174, 12);
            this.btnPunto3.Name = "btnPunto3";
            this.btnPunto3.Size = new System.Drawing.Size(75, 23);
            this.btnPunto3.TabIndex = 2;
            this.btnPunto3.Text = "Punto 3";
            this.btnPunto3.UseVisualStyleBackColor = true;
            // 
            // btnPunto4
            // 
            this.btnPunto4.Location = new System.Drawing.Point(255, 12);
            this.btnPunto4.Name = "btnPunto4";
            this.btnPunto4.Size = new System.Drawing.Size(75, 23);
            this.btnPunto4.TabIndex = 3;
            this.btnPunto4.Text = "Punto 4";
            this.btnPunto4.UseVisualStyleBackColor = true;
            // 
            // btnPunto5
            // 
            this.btnPunto5.Location = new System.Drawing.Point(336, 12);
            this.btnPunto5.Name = "btnPunto5";
            this.btnPunto5.Size = new System.Drawing.Size(75, 23);
            this.btnPunto5.TabIndex = 4;
            this.btnPunto5.Text = "Punto 5";
            this.btnPunto5.UseVisualStyleBackColor = true;
            // 
            // lstVisor
            // 
            this.lstVisor.FormattingEnabled = true;
            this.lstVisor.ItemHeight = 15;
            this.lstVisor.Location = new System.Drawing.Point(12, 58);
            this.lstVisor.Name = "lstVisor";
            this.lstVisor.Size = new System.Drawing.Size(399, 229);
            this.lstVisor.TabIndex = 5;
            // 
            // btnVerLog
            // 
            this.btnVerLog.Location = new System.Drawing.Point(12, 293);
            this.btnVerLog.Name = "btnVerLog";
            this.btnVerLog.Size = new System.Drawing.Size(134, 37);
            this.btnVerLog.TabIndex = 6;
            this.btnVerLog.Text = "Ver log de Facturas";
            this.btnVerLog.UseVisualStyleBackColor = true;
            this.btnVerLog.Click += new System.EventHandler(this.btnVerLog_Click);
            // 
            // btnHilos
            // 
            this.btnHilos.Location = new System.Drawing.Point(277, 293);
            this.btnHilos.Name = "btnHilos";
            this.btnHilos.Size = new System.Drawing.Size(134, 37);
            this.btnHilos.TabIndex = 7;
            this.btnHilos.Text = "Hilos";
            this.btnHilos.UseVisualStyleBackColor = true;
            this.btnHilos.Click += new System.EventHandler(this.btnHilos_Click);
            // 
            // FrmParteUno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 342);
            this.Controls.Add(this.btnHilos);
            this.Controls.Add(this.btnVerLog);
            this.Controls.Add(this.lstVisor);
            this.Controls.Add(this.btnPunto5);
            this.Controls.Add(this.btnPunto4);
            this.Controls.Add(this.btnPunto3);
            this.Controls.Add(this.btnPunto2);
            this.Controls.Add(this.btnPunto1);
            this.Name = "FrmParteUno";
            this.Text = "FrmParteUno";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPunto1;
        private System.Windows.Forms.Button btnPunto2;
        private System.Windows.Forms.Button btnPunto3;
        private System.Windows.Forms.Button btnPunto4;
        private System.Windows.Forms.Button btnPunto5;
        private System.Windows.Forms.ListBox lstVisor;
        private System.Windows.Forms.Button btnVerLog;
        private System.Windows.Forms.Button btnHilos;
    }
}