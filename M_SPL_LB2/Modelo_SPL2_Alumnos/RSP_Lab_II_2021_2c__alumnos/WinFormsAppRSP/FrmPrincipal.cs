using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

/*
 * Cuando apretamos el gatillo...?
 */
namespace WinFormsAppRSP
{
    ///Agregar manejo de excepciones en TODOS los lugares críticos!!!

    public partial class FrmPrincipal : Form
    {
        ///Crear en un proyecto de tipo class library (EntidadesRSP), las clases:
        ///Persona
        ///Atributos (todos privados)
        ///dni : int
        ///apellido : string
        ///nombre : string
        ///Propiedades públicas de lectura y escritura para todos sus atributos.
        ///Constructor que reciba parámetros para cada atributo
        ///Polimorfismo sobre ToString
        ///
        ///Alumno (deriva de Persona)
        ///Atributo
        ///nota : double
        ///Propiedad pública de lectura y escritura para su atributo.
        ///Constructor que reciba parámetro para cada atributo
        ///Polimorfismo sobre ToString
        ///Eventos (diseñados según convenciones vistas)
        ///Aprobar
        ///NoAprobar
        ///Promocionar
        ///Método de instancia (público)
        ///Clasificar() : void
        ///Si el atributo nota es menor a 4, lanzará el evento NoAprobar.
        ///Si el atributo nota es menor a 6 (y mayor o igual a 4), lanzará el evento Aprobar.
        ///Si el atributo nota es mayor o igual a 6, lanzará el evento Promocionar.
        ///
        ///AlumnoADO (hereda de Alumno)
        ///Atributos (estáticos)
        ///conexion : string
        ///connection : SqlConnection
        ///command : SqlCommand
        ///Constructor de clase que inicialice todos sus atributos
        ///Constructor que recibe un objeto de tipo Alumno cómo parámetro
        ///Métodos de instancia (públicos):
        ///ObtenerTodos() : List<Alumno> 
        ///Agregar() : bool
        ///Modificar() : bool -> se modifica a partir del dni
        ///Eliminar() : bool -> se elimina a partir del dni

        ///BASE DE DATOS
        ///Crear la BASE de DATOS utn_fra_alumnos y ejecutar el siguiente script:
        ///USE [utn_fra_alumnos]
        ///GO
        ///CREATE TABLE [dbo].[alumnos]
        ///(
        ///[dni] [int] NOT NULL,
        ///[apellido] [varchar](50) NOT NULL,
        ///[nombre] [varchar](50) NOT NULL,
        ///[nota] [float] NOT NULL,
        ///) ON[PRIMARY]
        ///GO
        ///

        private List<EntidadesRSP.Alumno> alumnos;
        private static String rutaArchivo;

        static FrmPrincipal()
        {
            String rutaSemiCompleta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            String rutaCompleta = "Mendez.JuanCruz.alumnos.xml";
            FrmPrincipal.rutaArchivo = Path.Combine(rutaSemiCompleta, rutaCompleta);
        }

        public FrmPrincipal()
        {
            InitializeComponent();

            this.Text = "Mendez Juan Cruz";
            MessageBox.Show(this.Text);

            this.CargarListados();

            ///Agregar los manejadores de eventos para: 
            ///btnAgregar, btnEliminar, btnModificar, btnSerializar, btnDeserializar y btnHilos
            ///

            this.btnAgregar.Click += ManejadorAgregar;
            this.btnEliminar.Click += ManejadorEliminar;
            this.btnModificar.Click += ManejadorModificar;
            this.btnSerializar.Click += ManejadorSerializar;
            this.btnDeserializar.Click += ManejadorDeserializar;
            this.btnHilos.Click += ManejadorHilos;

        }

        private void CargarListados()
        {
            this.lstAprobados.Items.Clear();
            this.lstDesaprobados.Items.Clear();
            this.lstPromocionados.Items.Clear();

            ///Utilizando la clase AlumnoADO, obtener y mostrar todos los productos
            ///
            try
            {
                this.alumnos = new EntidadesRSP.AlumnoADO(new EntidadesRSP.Alumno(4, 525525, "pepe", "Falcone")).ObtenerTodos();
                this.lstTodos.DataSource = this.alumnos;

                foreach (EntidadesRSP.Alumno item in this.alumnos)
                {
                    ///Agregar, para los eventos
                    ///Aprobar, NoAprobar y Promocionar, los manejadores
                    ///AlumnoAprobado, AlumnoNoAprobado y AlumnoPromocionado, respectivamente
                    ///
                    EntidadesRSP.Alumno.Aprobar += this.AlumnoAprobado;
                    EntidadesRSP.Alumno.Promocionar += this.AlumnoPromocionado;
                    EntidadesRSP.Alumno.NoAprobar += this.AlumnoNoAprobado;
                    item.Clasificar();

                    ///Quitar los manejadores de eventos para:
                    ///Aprobar, NoAprobar y Promocionar
                    ///
                    EntidadesRSP.Alumno.Aprobar -= this.AlumnoAprobado;
                    EntidadesRSP.Alumno.Promocionar -= this.AlumnoPromocionado;
                    EntidadesRSP.Alumno.NoAprobar -= this.AlumnoNoAprobado;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",MessageBoxButtons.OK);
            }
        }

        private void ManejadorAgregar(object emisor, EventArgs argumentos)
        {
            ///Agregar un nuevo alumno a la base de datos
            ///Utilizar FrmAlumno.
            ///Si se pudo agregar, invocar al método CargarListados, caso contrario mostrar mensaje
            ///
            EntidadesRSP.AlumnoADO al;
            try
            {
                FrmAlumno frmA = new FrmAlumno();
                //frmA.Show();
                if(frmA.ShowDialog() == DialogResult.OK)
                {
                    al = new EntidadesRSP.AlumnoADO(frmA.Alumno);
                    if(al.Agregar())
                    {
                        this.CargarListados();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo cargar el alumno... reingrese..","Error",MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK);
            }
        }

        private void ManejadorModificar(object emisor, EventArgs argumentos)
        {
            ///Modificar el alumno seleccionado (el dni no se debe modificar, adecuar FrmAlumno)
            ///Se deben mostrar todos los datos en el formulario (adaptarlo)
            ///reutilizar FrmAlumno.
            ///Si se pudo modificar, invocar al método CargarListados, caso contrario mostrar mensaje
            ///
            EntidadesRSP.AlumnoADO al;
            try
            {
                if(this.lstTodos.SelectedIndex > -1)
                {
                    FrmAlumno frmA = new FrmAlumno(((EntidadesRSP.Alumno)this.lstTodos.SelectedItem));
                    //frmA.Show();
                    if (frmA.ShowDialog() == DialogResult.OK)
                    {
                        al = new EntidadesRSP.AlumnoADO(frmA.Alumno);
                        if (al.Modificar())
                        {
                            this.CargarListados();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo modificar el alumno... reingrese..", "Error", MessageBoxButtons.OK);
                        }
                    }
                }    
                else
                {
                    MessageBox.Show("Maquina tenes que elegir un alumno de la lista , duh", "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK);
            }
        }

        private void ManejadorEliminar(object emisor, EventArgs argumentos)
        {
            ///Eliminar el alumno seleccionado (el dni no se debe modificar, adecuar FrmAlumno)
            ///Se deben mostrar todos los datos en el formulario (adaptarlo)
            ///reutilizar FrmAlumno.
            ///Si se pudo eliminar, invocar al método CargarListados, caso contrario mostrar mensaje
            ///
            EntidadesRSP.AlumnoADO al;
            try
            {
                if (this.lstTodos.SelectedIndex > -1)
                {
                    FrmAlumno frmA = new FrmAlumno(((EntidadesRSP.Alumno)this.lstTodos.SelectedItem));
                    //frmA.Show();
                    if (frmA.ShowDialog() == DialogResult.OK)
                    {
                        al = new EntidadesRSP.AlumnoADO(frmA.Alumno);
                        if (al.Eliminar())
                        {
                            this.CargarListados();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el alumno... reingrese..", "Error", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Maquina tenes que elegir un alumno de la lista , duh", "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK);
            }
        }

        private void ManejadorSerializar(object emisor, EventArgs argumentos)
        {
            ///Serializar a XML la lista de alumnos del formulario (this.alumnos)
            ///El archivo .xml guardarlo en el escritorio del cliente, 
            ///con el nombre formado con su apellido.nombre.alumnos.xml
            ///Ejemplo: Alumno Juan Pérez -> perez.juan.alumnos.xml
            ///Indicar si se pudo o no serializar la lista de alumnos
            ///
            if(this.alumnos.Count > 0)
            {
                try
                {
                    using(StreamWriter stw = new(FrmPrincipal.rutaArchivo))
                    {
                        XmlSerializer xmlS = new(typeof(List<EntidadesRSP.Alumno>));
                        xmlS.Serialize(stw, this.alumnos);
                        MessageBox.Show("Alumnos serializados con exito..");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error en metodo ManejadorSerializar, clase FrmPrincipal\nErroyType: {ex.Message}", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Maquina esta vacia la lista..","Error",MessageBoxButtons.OK);
            }
        }

        private void ManejadorDeserializar(object emisor, EventArgs argumentos)
        {
            ///Deserializar de XML a una lista de alumnos
            ///El archivo .xml tomarlo del escritorio del cliente, 
            ///con el nombre formado con su apellido.nombre.alumnos.xml
            ///Ejemplo: Alumno Juan Pérez -> perez.juan.alumnos.xml
            ///Si se pudo serializar, mostrar el listado completo en un MessageBox.
            ///Si no se pudo deserializar, mostrar los motivos
            ///

            StringBuilder listado = new StringBuilder();
            List<EntidadesRSP.Alumno> alumnos;
            try
            {
                using (StreamReader str = new(FrmPrincipal.rutaArchivo))
                {
                    XmlSerializer xmlS = new(typeof(List<EntidadesRSP.Alumno>));
                    alumnos = ((List<EntidadesRSP.Alumno>)xmlS.Deserialize(str));
                    
                    if(alumnos.Count > 0)
                    {
                        foreach (EntidadesRSP.Alumno item in alumnos)
                        {
                            listado.AppendLine(item.ToString());                                
                        }
                    }
                    else
                    {
                        listado.AppendLine("Sin elementos al momento");
                    }
                    MessageBox.Show(listado.ToString(), "Listado Deserializado");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error metodo ManjeadorDeserializar, clase FrmPrincipal\nErrorType: {ex.Message}", "Error", MessageBoxButtons.OK);      
            }
        }

        public void AlumnoNoAprobado(object alumni, EventArgs e)
        {
            ///Agregar el alumno al listado lstDesaprobados
            ///
            this.lstDesaprobados.Items.Add(((EntidadesRSP.Alumno)alumni));
        }

        public void AlumnoAprobado(object alumni, EventArgs e)
        {
            ///Agregar el alumno al listado lstAprobados
            ///
            this.lstAprobados.Items.Add(((EntidadesRSP.Alumno)alumni));
        }

        public void AlumnoPromocionado(object alumni, EventArgs e)
        {
            ///Agregar el alumno al listado lstPromocionados
            ///
            this.lstPromocionados.Items.Add(((EntidadesRSP.Alumno)alumni));
        }

        private void ManejadorHilos(object emisor, EventArgs argumentos)
        {
            ///Iniciar una nueva tarea en segundo plano que, para lstDesaprobados:
            ///cambie el color de fondo (a rojo) y el color de la fuente (a blanco)
            ///y lo intercambie (fondo a blanco y fuente a rojo) 10 veces,
            ///agregando un retardo de 1 segundo por cada intercambio.
            ///
            ///NOTA: propiedades BackColor (fondo) y ForeColor (fuente)
            ///colores: 
            ///System.Drawing.Color.Red (rojo)
            ///System.Drawing.Color.White (blanco)
            Int32 cont = 0;

            Task.Run( () => {

                while (cont < 10)
                {
                    this.CambiarColor();
                    Thread.Sleep(1000);
                    cont++;
                }
                this.lstDesaprobados.BackColor = System.Drawing.Color.White;
                this.lstDesaprobados.ForeColor = System.Drawing.Color.Red;
            });
        }

        private void CambiarColor()
        {
            if(InvokeRequired)
            {
                Action del = this.CambiarColor;
                this.Invoke(del);
            }
            else
            {
                if (this.lstDesaprobados.BackColor == System.Drawing.Color.White)
                {
                    this.lstDesaprobados.BackColor = System.Drawing.Color.Red;
                    this.lstDesaprobados.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    this.lstDesaprobados.BackColor = System.Drawing.Color.White;
                    this.lstDesaprobados.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}
