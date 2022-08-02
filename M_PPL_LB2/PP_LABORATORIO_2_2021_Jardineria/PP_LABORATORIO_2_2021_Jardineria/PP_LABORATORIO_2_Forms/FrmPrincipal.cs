using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PP_LABORATORIO_2_2021_Jardineria;

namespace PP_LABORATORIO_2_Forms
{
    public partial class FrmPrincipal : Form
    {
        private Jardin jardin;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.btn_verDatos.Click += this.MostrarInfor_Click;
            this.jardin = new Jardin(100);
            bool pudo = this.jardin + new Arbusto("Arbusto 1", 10);
            pudo = this.jardin + new Arbusto("Arbusto 2", 15);
            pudo = this.jardin + new Rosal("Rosa 1", 20, PP_LABORATORIO_2_2021_Jardineria.Color.Amarilla);
            pudo = this.jardin + new Rosal("Rosa clásica", 25);
            pudo = this.jardin + new Banano("Banano ecuador", 30, "ECU001");
            if (!(this.jardin + new Banano("No carga", 1, "ARG028")))
            {
                MessageBox.Show("ERROR!" , "Revisar!" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void MostrarInfor_Click(Object sender , EventArgs args)
        {
            String mostrar = "Error, rompimo todoo";

            if(this.jardin is not null)
            {
                mostrar = this.jardin.ToString();
            }
            this.rtbSalidaDeTest.Text = mostrar;
        }
    }
}
