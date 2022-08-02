
namespace SP.LABII.WinFormsApp
{
    partial class FrmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.parteUnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parteDosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parteUnoToolStripMenuItem,
            this.parteDosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // parteUnoToolStripMenuItem
            // 
            this.parteUnoToolStripMenuItem.Name = "parteUnoToolStripMenuItem";
            this.parteUnoToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.parteUnoToolStripMenuItem.Text = "Parte Uno";
            this.parteUnoToolStripMenuItem.Click += new System.EventHandler(this.parteUnoToolStripMenuItem_Click);
            // 
            // parteDosToolStripMenuItem
            // 
            this.parteDosToolStripMenuItem.Name = "parteDosToolStripMenuItem";
            this.parteDosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.parteDosToolStripMenuItem.Text = "Parte Dos";
            this.parteDosToolStripMenuItem.Click += new System.EventHandler(this.parteDosToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem parteUnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parteDosToolStripMenuItem;
    }
}