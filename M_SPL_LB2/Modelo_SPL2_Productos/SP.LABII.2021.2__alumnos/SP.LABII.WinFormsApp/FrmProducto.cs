using System;
using System.Windows.Forms;

namespace SP.LABII.WinFormsApp
{
    public partial class FrmProducto : Form
    {
        private EntidadesSP.Producto miProducto;

        public EntidadesSP.Producto MiProducto
        {
            get { return this.miProducto; }
        }

        public FrmProducto()
        {
            InitializeComponent();
        }

        public FrmProducto(EntidadesSP.Producto p)
            : this()
        {
            if(!(p is null))
            {
                this.txtCodigo.Text = p.Codigo.ToString();
                this.txtCodigo.Enabled = false;
                this.txtPrecio.Text = p.Precio.ToString();
                this.txtTipo.Text = p.Tipo;
                this.txtMarca.Text = p.Marca;
            }
        }

        /// Crar una instancia de tipo Producto
        /// Establecer, como valor de la propiedad, el atributo miProducto
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool sePuede = true;
            foreach(Control item in this.Controls)
            {
                if(item is TextBox && String.IsNullOrWhiteSpace(((TextBox)item).Text))
                {
                    sePuede = false;
                    break;
                }
            }

            if(sePuede)
            {
                Int32 auxI;
                Double auxD;
                if(Double.TryParse(this.txtPrecio.Text,out auxD) && Int32.TryParse(this.txtCodigo.Text, out auxI))
                {
                    this.miProducto = new EntidadesSP.Producto(this.txtMarca.Text,this.txtTipo.Text,auxI,auxD);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Error, verifique los datos", "Alert", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Error, complete todos los espacios!", "Alert", MessageBoxButtons.OK);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
