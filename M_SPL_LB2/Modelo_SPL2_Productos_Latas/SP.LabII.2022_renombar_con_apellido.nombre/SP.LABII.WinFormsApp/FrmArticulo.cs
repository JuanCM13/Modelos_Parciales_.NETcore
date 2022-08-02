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
    public partial class FrmArticulo : Form
    {
        private EntidadesSP.Articulo miArticulo;

        public EntidadesSP.Articulo MiArticulo
        {
            get { return this.miArticulo; }
        }
        public FrmArticulo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        /// Crar una instancia de tipo Articulo
        /// Establecer, como valor de la propiedad, el atributo miArticulo
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
