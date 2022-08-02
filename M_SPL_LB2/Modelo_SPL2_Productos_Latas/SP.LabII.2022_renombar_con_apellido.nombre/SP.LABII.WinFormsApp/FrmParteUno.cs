using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesSP;

namespace SP.LABII.WinFormsApp
{
    public partial class FrmParteUno : Form
    {
        private Tomate tomate;
        private Pintura pintura;
        private Cerveza cerveza;

        private Lata<Tomate> lataDeTomate;
        private Lata<Pintura> lataDePintura;
        private Lata<Cerveza> lataDeCerveza;

        public FrmParteUno()
        {
            InitializeComponent();

            this.Text = "Cambiar por su apellido y nombre";
            MessageBox.Show(this.Text);
            this.StartPosition = FormStartPosition.CenterScreen;

            ///Agregar 'dinámicamente' los manejadores de eventos a los 
            ///eventos 'Click' de los botones btnPunto1, btnPunto2, btnPunto3, btnPunto4 y btnPunto5
            this.btnPunto1.Click += this.btnPunto1_Click;
            this.btnPunto2.Click += this.btnPunto2_Click;
            this.btnPunto3.Click += this.btnPunto3_Click;
            this.btnPunto4.Click += this.btnPunto4_Click;
            this.btnPunto5.Click += this.btnPunto5_Click;
        }

        ///Crear, en un proyecto de tipo class library (EntidadesSP), las siguientes clases:
        ///Articulo:
        ///atributos privados: marca : string, codigo : int, precio : double 
        ///propiedes públicas de lectura y escritura para todos sus atributos.
        ///contructor con 3 parámetros.
        ///Sobrescritura del método ToString, mostrando todos sus atributos.
        ///Tomate->hereda de Articulo 
        ///atributo público: tipo : string
        ///ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
        ///Pintura-> hereda de Articulo
        ///atributo protegido: color : string
        ///propiedad pública de lectura y escritura
        ///ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
        ///Cerveza-> hereda de Articulo

        private void btnPunto1_Click(object sender, EventArgs e)
        { 
            this.tomate = new Tomate("perita", "Del Valle", 111, 25.33);
            this.pintura = new Pintura("naranja", "Alba", 222, 790);
            this.cerveza = new Cerveza("Quilmes", 333, 250);

            MessageBox.Show(this.tomate.ToString());
            MessageBox.Show(this.pintura.ToString());
            MessageBox.Show(this.cerveza.ToString());
        }

        ///Crear, en EntidadesSP, la clase genérica Lata<T>, dónde T pueda ser de tipo Tomate, Pintura o Cerveza.
        ///atributos: capacidad : int y elementos : List<T> (TODOS protegidos)        
        ///Propiedades:
        ///Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        ///PrecioTotal:(sólo lectura) retorna el precio total de la lata (la suma de los precios de sus elementos).
        ///Constructor
        ///Lata(), Lata(int); 
        ///El constructor por default es el único que se encargará de inicializar la lista.
        ///Métodos:
        ///ToString: Mostrará en formato de tipo string: 
        ///el tipo de lata, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
        ///de todos los elementos contenidos en la misma. Reutilizar código.
        ///Sobrecarga de operadores:
        ///(+) Será el encargado de agregar elementos a la lata, 
        ///siempre y cuando no supere la capacidad máxima de la misma.
        
        private void btnPunto2_Click(object sender, EventArgs e)
        {
            this.lataDeTomate = new Lata<Tomate>(3);
            this.lataDePintura = new Lata<Pintura>(3);
            this.lataDeCerveza = new Lata<Cerveza>(2);

            this.lataDeTomate += new Tomate("redondo", "de finca", 112, 50);
            this.lataDeTomate += new Tomate("cherry", "La Carlota", 113, 49);
            this.lataDeTomate += this.tomate;

            this.lataDePintura += this.pintura;
            this.lataDePintura += new Pintura("naranja", "Sinteplast", 220, 800);

            this.lataDeCerveza += this.cerveza;
            this.lataDeCerveza += this.cerveza;

            MessageBox.Show(this.lataDeTomate.ToString());
            MessageBox.Show(this.lataDePintura.ToString());
            MessageBox.Show(this.lataDeCerveza.ToString());
        }

        ///Agregar un elemento a la lata de tomate, al superar la cantidad máxima, 
        ///lanzará un LataLlenaException (diseñarla), cuyo mensaje explicará lo sucedido.
        private void btnPunto3_Click(object sender, EventArgs e)
        {
            try
            {
                this.lataDeTomate += this.tomate;
            }
            catch (LataLlenaException ex)
            {
                ///Agregar, para la clase LataLlenaException, un método de extensión (InformarNovedad():string)
                ///que retorne el mensaje de error
                MessageBox.Show(ex.InformarNovedad());
            }
        }

        ///Si el precio total de la caja supera los 2000 pesos, se disparará el evento EventoPrecio. 
        ///Diseñarlo (de acuerdo a las convenciones vistas) en la clase Lata. 
        ///Adaptar la sobrecarga del operador +, para que lance el evento, según lo solicitado.
        ///Crear el manejador necesario para que, una vez capturado el evento, se imprima en un archivo de texto: 
        ///la fecha (con hora, minutos y segundos) y el total de la caja (en un nuevo renglón). 
        ///Se deben acumular los mensajes. 
        ///El archivo se guardará con el nombre 'facturas.log' en la carpeta 'Mis documentos' del cliente.
        ///El manejador de eventos (Lata_EventoPrecio) invocará al método (de clase) 
        ///ImprimirFactura(Lata<T>) (se alojará en la clase Facturadora<T>), que retorna un booleano 
        ///indicando si se pudo escribir o no.
        ///la clase Facturadora<T> sólo podrá 'facturar' tomates, pinturas o cervezas.
        private void btnPunto4_Click(object sender, EventArgs e)
        {
            ///Asociar 'dinámicamente' el manejador de eventos (Caja_EventoPrecio) aquí  


            this.lataDePintura += new Pintura("blanco", "Alba", 221, 450);
        }

        ///Crear el manejador necesario para que, una vez capturado el evento, se imprima en un archivo de texto: 
        ///la fecha (con hora, minutos y segundos) y el total de la caja (en un nuevo renglón). 
        ///Se deben acumular los mensajes. 
        ///El archivo se guardará con el nombre 'facturas.log' en la carpeta 'Mis documentos' del cliente.
        ///El manejador de eventos (Lata_EventoPrecio) invocará al método (de clase) 
        ///ImprimirFactura(Lata<T>) (se alojará en la clase Facturadora<T>), que retorna un booleano 
        ///indicando si se pudo escribir o no.
        ///la clase Facturadora<T> sólo podrá 'facturar' tomates, pinturas o cervezas.
        private void Lata_EventoPrecio(object sender, EventArgs e)
        {
            try
            {
                bool todoOK = Facturadora<Articulo>.ImprimirFactura((Lata<Articulo>)sender);///Reemplazar por la llamada al método de clase ImprimirFactura

                if (todoOK)
                {
                    MessageBox.Show("Factura impresa correctamente!!!");
                }
                else
                {
                    MessageBox.Show("No se pudo imprimir la factura!!!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }            
        }

        ///Crear las interfaces (en el proyecto class library): 
        ///#.-ISerializa -> Xml() : bool
        ///              -> PathXml{ get; } : string
        ///              -> Json() : bool
        ///              -> PathJson{ get; } : string
        ///#.-IDeserializa<T> (tendrá como restricción que la clase posea un constructor por defecto)
        ///             -> Xml(out T) : bool
        ///             -> Json(out T) : bool
        ///Implementar ISerializa e IDeserializa en Tomate y Pintura
        ///En la clase Tomate, implementar:
        ///implícitamente: PathXml, Xml() y Json(out T)
        ///explícitamente: PathJson, Xml(out T) y Json()
        ///En la clase Pintura, implementar:
        ///implícitamente: PathJson, Xml(out T) y Json()
        ///explícitamente: PathXml, Xml() y Json(out T)
        ///El archivo .xml guardarlo en el escritorio del cliente, con el nombre formado con: apellido.nombre.tomate.xml
        ///Ejemplo: Alumno Juan Pérez -> perez.juan.tomate.xml
        ///El archivo .json guardarlo en la carpeta 'Mis documentos' del cliente, con el nombre formado con: apellido.nombre.pintura.json
        ///Ejemplo: Alumno Juan Pérez -> perez.juan.pintura.json
        private void btnPunto5_Click(object sender, EventArgs e)
        {
            Tomate auxT = null;

            try
            {
                if (this.tomate.Xml())
                {
                    MessageBox.Show("Tomate serializado a XML, OK");
                }
                else
                {
                    MessageBox.Show("Tomate NO serializado a XML");
                }

                if (((IDeserializa<Tomate>)this.tomate).Xml(out auxT))
                {
                    MessageBox.Show("Tomate deserializado de XML, OK");
                    MessageBox.Show(auxT.ToString());
                }
                else
                {
                    MessageBox.Show("Tomate NO deserializado de XML");
                }

                Pintura auxP = null;

                if (this.pintura.Json())
                {
                    MessageBox.Show("Pintura serializada a JSON, OK");
                }
                else
                {
                    MessageBox.Show("Pintura NO serializada a JSON");
                }

                if (((IDeserializa<Pintura>)this.pintura).Json(out auxP))
                {
                    MessageBox.Show("Pintura deserializada de JSON, OK");
                    MessageBox.Show(auxP.ToString());
                }
                else
                {
                    MessageBox.Show("Pintura NO deserializada de JSON");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        ///Configurar el OpenFileDialog, para poder seleccionar el log de facturas
        private void btnVerLog_Click(object sender, EventArgs e)
        {
            ///titulo -> 'Abrir archivo de facturas'
            ///directorio por defecto -> Mis documentos
            ///tipo de archivo (filtro) -> .log
            ///extensión por defecto -> .log
            ///nombre de archivo (defecto) -> facturas

            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Abrir archivo de facturas";
            open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            open.Filter = "Archivos de texto|*.log";
            open.DefaultExt = ".log";
            open.FileName = "facturas";

            try
            {
                DialogResult rta = open.ShowDialog();///Reemplazar por la llamada al método correspondiente del OpenFileDialog

                if (rta == DialogResult.OK)
                {
                    ///leer el archivo seleccionado por el cliente y mostrarlo en lstVisor
                    this.lstVisor.Items.Clear();
                    using(StreamReader stR = new(open.FileName))
                    {
                        while(!(stR.ReadLine() is null))
                        {
                            this.lstVisor.Items.Add(stR.ReadLine());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        ///Iniciar una nueva tarea en segundo plano (hilo) que muestre en lstVisor el contenido
        ///de los objetos this.tomate, this.pintura y this.cerveza
        ///agregando un retardo de 3 segundos.
        ///Asociarlo al método MostrarArticulosFormTask(object)
        ///
        private void btnHilos_Click(object sender, EventArgs e)
        {
            this.lstVisor.Items.Clear();
            Task.Run(() =>
            {
                this.MostrarArticulosFormTask(this);
            });

        }

        private void MostrarArticulosFormTask(object param)
        {
            if(InvokeRequired)
            {
                Action<Object> delegTask = this.MostrarArticulosFormTask;
                Object[] arr = new object[] { param }; // si o si cuando invoco un delegado con parametros en el this.Invoke, tengo que pasarle los parametros
                this.Invoke(delegTask , arr);       //a travez de un array..
            }
            else
            {
                FrmParteUno auxForm = (FrmParteUno)param;
                if (!(param is null) && !(auxForm.lataDeCerveza is null) && !(auxForm.lataDePintura is null) && !(auxForm.lataDeTomate is null))
                {
                    List<Articulo> arts = new();
                    arts.AddRange(auxForm.lataDeCerveza.Elementos);
                    arts.AddRange(auxForm.lataDePintura.Elementos);
                    arts.AddRange(auxForm.lataDeTomate.Elementos);

                    foreach(Articulo item in arts)
                    {
                        lstVisor.Items.Add(item.ToString());
                        Task.Delay(300);
                    }
                }
            }
        }
    }


}
