using System;
using System.Windows.Forms;
using EntidadesRSP;


namespace WinFormsAppRSP
{
    public partial class FrmAlumno : Form
    {
        private Alumno alumno;

        public Alumno Alumno
        {
            get { return alumno; }
        }

        public FrmAlumno()
        {
            InitializeComponent();
        }

        public FrmAlumno(Alumno al)
            : this()
        {
            if(al is not null)
            {
                this.alumno = al;
                this.txtDNI.Text = al.Dni.ToString();
                this.txtDNI.Enabled = false;
                this.txtApellido.Text = al.Apellido;
                this.txtNombre.Text = al.Nombre;
                this.txtNota.Text = al.Nota.ToString();    
            }            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool sePuede = true;
            foreach(Control item in this.Controls)
            {
                if(item is TextBox && String.IsNullOrEmpty(((TextBox)item).Text))
                {
                    sePuede = false;
                }
            }

            if(sePuede)
            {
                this.alumno = new Alumno(
                    Double.Parse(this.txtNota.Text),
                    Int32.Parse(this.txtDNI.Text),
                    this.txtNombre.Text.ToString(),
                    this.txtApellido.Text.ToString()
                    );
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Error, tenes que completar toods los campos capo..", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
