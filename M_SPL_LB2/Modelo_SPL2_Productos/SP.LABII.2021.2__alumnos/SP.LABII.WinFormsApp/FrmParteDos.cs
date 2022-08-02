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
    ///Agregar manejo de excepciones en TODOS los lugares críticos!!!


    ///Crear, en EntidadesSP, la clase ADO.
    ///Dicha clase se deberá comunicar con la base de datos, tendrá:
    ///Métodos de clase:
    ///ObtenerTodos() : List<Producto>
    ///ObtenerTodos(string) : List<Producto> -> se obtienen por marca 
    ///de acuerdo al parámetro recibido
    ///Métodos de instancia:
    ///Agregar(Producto) : bool
    ///Modificar(Producto) : bool -> se modifica a partir del código
    ///Eliminar(Producto) : bool -> se elimina a partir del código

    ///BASE DE DATOS
    ///Crear la BASE de DATOS almacen_db y ejecutar el siguiente script:
    ///USE [almacen_db]
    ///GO
    ///CREATE TABLE[dbo].[productos]
    ///(
    ///[marca][varchar](50) NULL,
    ///[tipo] [varchar] (50) NULL,
    ///[codigo] [int] NULL,
    ///[precio] [float] NULL
    ///) ON[PRIMARY]
    ///GO

    public partial class FrmParteDos : Form
    {
        List<EntidadesSP.Producto> lista;

        public FrmParteDos()
        {
            InitializeComponent();

            this.Text = "Mendez Juan Cruz";
            MessageBox.Show(this.Text);
        }

        private void FrmAlmacen_Load(object sender, EventArgs e)
        {
            this.CargarListadoProductosBD();
        }

        public void CargarListadoProductosBD()
        {
            ///Utilizando la clase ADO, obtener y mostrar todos los productos
            ///
            try
            {
                this.lista = EntidadesSP.ADO.ObtenerTodos();
                this.listBox1.DataSource = this.lista;
            }            
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ///Agregar un nuevo producto a la base de datos
            ///Utilizar FrmProducto.
            ///Si la marca ya existe en la base, se disparará el evento MarcaExistente. 
            ///Diseñarlo (de acuerdo a las convenciones vistas) en la clase ADO. 
            ///Crear el manejador (Manejador_marcaExistente) para que, una vez capturado el evento, 
            ///se muestren con un MessageBox: 
            ///la fecha (con hora, minutos y segundos) y todos los datos de los productos
            ///que coincidan con esa marca.

            FrmProducto frm = new FrmProducto();
            frm.StartPosition = FormStartPosition.CenterParent;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                EntidadesSP.ADO ado = new EntidadesSP.ADO();
                EntidadesSP.ADO.MarcaExistente += this.Manejador_marcaExistente;
                ///Asociar 'dinámicamente' el manejador de eventos (Manejador_marcaExistente) aquí 
                try
                {
                    if (ado.Agregar(frm.MiProducto))
                    {
                        this.FrmAlmacen_Load(sender, e);

                        MessageBox.Show("Agregado!!");
                    }
                    else
                    {
                        MessageBox.Show("No se agregó");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }

                ///Desasociar 'dinámicamente' el manejador de eventos (Manejador_marcaExistente) aquí 
                EntidadesSP.ADO.MarcaExistente -= this.Manejador_marcaExistente;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ///Modificar el producto seleccionado (el código no se debe modificar, adecuar FrmUsuario)
            ///Se deben mostrar todos los datos en el formulario (adaptarlo)
            ///reutilizar FrmUsuario
            
            int i = this.listBox1.SelectedIndex;

            if (i < 0) { return; }

            EntidadesSP.Producto prod = this.lista[i];

            FrmProducto frm = new FrmProducto(prod);
            frm.StartPosition = FormStartPosition.CenterParent;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    EntidadesSP.ADO ado = new EntidadesSP.ADO();
                    if (ado.Modificar(frm.MiProducto))
                    {
                        this.lista[i] = frm.MiProducto;

                        this.FrmAlmacen_Load(sender, e);

                        MessageBox.Show("Modificado!!");
                    }
                    else
                    {
                        MessageBox.Show("No se modificó");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ///Eliminar el producto seleccionado (el código no se debe modificar, adecuar FrmUsuario)
            ///Se deben mostrar todos los datos en el formulario (adaptarlo)
            ///reutilizar FrmUsuario
           
            int i = this.listBox1.SelectedIndex;

            if (i < 0) { return; }

            EntidadesSP.Producto prod = this.lista[i];

            FrmProducto frm = new FrmProducto(prod);
            frm.StartPosition = FormStartPosition.CenterParent;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    EntidadesSP.ADO ado = new EntidadesSP.ADO();
                    if (ado.Eliminar(frm.MiProducto))
                    {
                        this.lista.RemoveAt(i);

                        this.FrmAlmacen_Load(sender, e);

                        MessageBox.Show("Eliminado!!");
                    }
                    else
                    {
                        MessageBox.Show("No se eliminó");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void Manejador_marcaExistente(object sender, EventArgs e)
        {
            /// Mostrar los datos del producto
            ///
            try
            {
                List<EntidadesSP.Producto> lista = EntidadesSP.ADO.ObtenerTodos(((EntidadesSP.Producto)sender).Marca);///reemplazar por lo que corresponda

                foreach (var item in lista)
                {
                    MessageBox.Show(item.ToString(), "Marcas repetidas " + DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
