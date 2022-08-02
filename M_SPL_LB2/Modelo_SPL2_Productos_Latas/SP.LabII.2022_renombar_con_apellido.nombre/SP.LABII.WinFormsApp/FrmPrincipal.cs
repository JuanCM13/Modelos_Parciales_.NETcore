using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP.LABII.WinFormsApp
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();

            this.Text = "Cambiar por su apellido y nombre";

            MessageBox.Show(this.Text);
            this.WindowState = FormWindowState.Maximized;
        }

        private void parteUnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParteUno frm = new FrmParteUno();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;

            frm.Show();
        }

        private void parteDosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParteDos frm = new FrmParteDos();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;

            frm.Show();

        }
    }
}
