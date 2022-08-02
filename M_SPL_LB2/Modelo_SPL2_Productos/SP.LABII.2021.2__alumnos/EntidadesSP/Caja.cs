using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///Crear, en EntidadesSP, la clase Caja<T>, dónde T sea de tipo Zapato, Fósforo o Remedio.
    ///atributos: capacidad:int y elementos:List<T> (TODOS protegidos)        
    ///Propiedades:
    ///Elementos:(sólo lectura) expone al atributo de tipo List<T>.
    ///PrecioTotal:(sólo lectura) retorna el precio total de la caja (la suma de los precios de sus elementos).
    ///Constructor
    ///Caja(), Caja(int); 
    ///El constructor por default es el único que se encargará de inicializar la lista.
    ///Métodos:
    ///ToString: Mostrará en formato de tipo string: 
    ///.-el tipo de caja, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
    ///de todos los elementos contenidos en la misma. Reutilizar código.
    ///Sobrecarga de operadores:
    ///(+) Será el encargado de agregar elementos a la caja, 
    ///siempre y cuando no supere la capacidad máxima de la misma.
    ///

    public delegate void DelegadoNormie(Object sender, EventArgs args);
    public class Caja<T> where T : Producto
    {
        protected Int32 capacidad;
        protected List<T> elementos;
        public DelegadoNormie EventoPrecio;

        public Caja()
        {
            this.elementos = new List<T>();
        }

        public Caja(Int32 cap)
            : this()
        {
            this.capacidad = cap;
        }
    
        public List<T> Elementos { get { return this.elementos; } }

        public Double PrecioTotal
        {
            get
            {
                Double ret = 0;
                
                if(!(this.Elementos is null))
                {
                    foreach(T item in this.Elementos)
                    {
                        ret += item.Precio;
                    }
                }
                return ret;
            }
        }

        ///Sobrecarga de operadores:
        ///(+) Será el encargado de agregar elementos a la caja, 
        ///siempre y cuando no supere la capacidad máxima de la misma.   
        public static Caja<T> operator +(Caja<T> caja , T item)
        {
            if(!(caja is null) && !(item is null))
            {
                if (caja.Elementos.Count < caja.capacidad)
                {
                    caja.Elementos.Add(item);
                    ///Si el precio total de la caja supera los 999 pesos, se disparará el evento EventoPrecio. 
                    ///Diseñarlo (de acuerdo a las convenciones vistas) en la clase caja. 
                    ///Adaptar la sobrecarga del operador +, para que lance el evento, según lo solicitado.
                    if(caja.PrecioTotal > 999)
                    {
                        if(caja.EventoPrecio is not null)
                        {
                            caja.EventoPrecio.Invoke(caja, new EventArgs());
                        }                        
                    }
                }
                else
                {
                    throw new CajaLlenaException($"La caja ya esta llena ({caja.capacidad} elementos)..");
                }
            }
            return caja;
        }

        ///ToString: Mostrará en formato de tipo string: 
        ///.-el tipo de caja, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
        ///de todos los elementos contenidos en la misma. Reutilizar código.
        public override string ToString()
        {
            StringBuilder str = new();
            Object tip;

            if(!(this.Elementos is null))
            {
                tip = this.Elementos.FirstOrDefault();

                str.AppendLine($"Tipo Caja: {tip.GetType()}\nCapacidad: {this.capacidad}\nCantidad de Elementos: {this.Elementos.Count}\n" +
                    $"Precio total: {this.PrecioTotal}\n\nListado de Elementos: ");
                if(this.Elementos.Count > 0)
                {
                    foreach(T item in this.Elementos)
                    {
                        str.AppendLine(item.ToString());
                    }
                }
                else
                {
                    str.AppendLine("Sin elementos al momento..");
                }
            }
            return str.ToString();
        }

    }
}
