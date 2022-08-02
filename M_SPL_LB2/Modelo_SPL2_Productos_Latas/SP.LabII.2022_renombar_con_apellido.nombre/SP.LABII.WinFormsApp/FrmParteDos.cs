using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP.LABII.WinFormsApp
{
    ///Agregar manejo de excepciones en TODOS los lugares críticos!!!


    ///Crear, en EntidadesSP, la clase ADO.
    ///Dicha clase se deberá comunicar con la base de datos, tendrá:
    ///Métodos de clase:
    ///ObtenerTodos() : List<Articulo>
    ///ObtenerTodos(string) : List<Articulo> -> se obtienen por marca 
    ///de acuerdo al parámetro recibido
    ///Métodos de instancia:
    ///Agregar(Articulo) : bool
    ///Modificar(Articulo) : bool -> se modifica a partir del código
    ///Eliminar(Articulo) : bool -> se elimina a partir del código
    ///
    
    public partial class FrmParteDos : Form
    {
        List<EntidadesSP.Articulo> lista;

        public FrmParteDos()
        {
            InitializeComponent();

            this.Text = "Cambiar por su apellido y nombre";
            MessageBox.Show(this.Text);
            this.StartPosition = FormStartPosition.CenterScreen;

        }
       
        private void FrmParteDos_Load(object sender, EventArgs e)
        {
            this.CargarListadoArticulosBD();
        }
        
        public void CargarListadoArticulosBD()
        {
            ///Utilizando la clase ADO, obtener y mostrar todos los articulos
            ///en lstVisorBD
            
       //     this.lista = EntidadesSP.ADO.ObtenerTodos();
            this.lstVisorBD.DataSource = this.lista;
        }

        ///Agregar un nuevo artículo a la base de datos.
        ///Utilizar FrmArticulo.
        ///Si la marca ya existe en la base, se disparará el evento MarcaExistente. 
        ///Diseñarlo (de acuerdo a las convenciones vistas) en la clase ADO. 
        ///Crear el manejador (Manejador_marcaExistente) para que, una vez capturado el evento, 
        ///se muestren con un MessageBox: 
        ///la fecha (con hora, minutos y segundos) y todos los datos de los artículos (existentes en la bd)
        ///que coincidan con esa marca.
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmArticulo frm = new FrmArticulo();
            frm.StartPosition = FormStartPosition.CenterParent;

            if (frm.ShowDialog() == DialogResult.OK)
            {
/*                EntidadesSP.ADO ado = new EntidadesSP.ADO();

                ///Asociar 'dinámicamente' el manejador de eventos (Manejador_marcaExistente) aquí 


                if (ado.Agregar(frm.MiArticulo))
                {
                    this.CargarListadoArticulosBD();

                    MessageBox.Show("Artículo agregado!!!");
                }
                else
                {
                    MessageBox.Show("No se agregó el artículo!!!");
                }

                ///Desasociar 'dinámicamente' el manejador de eventos (Manejador_marcaExistente) aquí 
*/
            }
        }

        ///Modificar el artículo seleccionado (el código no se debe modificar, adecuar FrmArticulo)
        ///reutilizar FrmArticulo
        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            
        }

        ///Eliminar el artículo seleccionado 
        ///reutilizar FrmArticulo
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }

        ///Crear el manejador de eventos, Manejador_marcaExistente, aquí:
        ///*/
    }
}
