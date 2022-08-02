using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
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
    ///

    public class Lata<T> where T : Articulo
    {
        protected Int32 capacidad;
        protected List<T> elementos;
        public event Action<Object, EventArgs> EventoPrecio;

        public Lata()
        {
            elementos = new();
        }

        public Lata(Int32 can)
            : this()
        {
            this.capacidad = can;
        }

        public List<T> Elementos { get { return this.elementos; } }
        
        public Double PrecioTotal
        {
            get 
            {
                Double ret = 0;
                
                foreach(T item in this.Elementos)
                {
                    ret += item.Precio;
                }
                return ret;
            }
        }

        ///Sobrecarga de operadores:
        ///(+) Será el encargado de agregar elementos a la lata, 
        ///siempre y cuando no supere la capacidad máxima de la misma.
        public static Lata<T> operator +(Lata<T> lat , T item)
        {
            if(!(lat is null) && !(item is null))
            {
                ///lanzará un LataLlenaException (diseñarla), cuyo mensaje explicará lo sucedido.
                if (lat.Elementos.Count < lat.capacidad)
                {
                    lat.Elementos.Add(item);
                }
                else
                {
                    throw new LataLlenaException($"La lata esta llena.. Limite: {lat.capacidad}");
                }

                ///Si el precio total de la caja supera los 2000 pesos, se disparará el evento EventoPrecio. 
                if(lat.PrecioTotal > 2000)
                {
                    lat.EventoPrecio.Invoke(lat, new EventArgs());
                }
            }
            return lat;
        }

        ///ToString: Mostrará en formato de tipo string: 
        ///el tipo de lata, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
        ///de todos los elementos contenidos en la misma. Reutilizar código.
        public override string ToString()
        {
            Object obj = this.Elementos.FirstOrDefault();

            StringBuilder str = new StringBuilder().AppendLine($"Tipo Lata: {obj.GetType().Name}\nCantidad Elementos: {this.Elementos.Count}\nCapacidad: {this.capacidad}\n" +
                $"Precio Total: {this.PrecioTotal}\n\nCantidad Elementos: ");
            if (this.Elementos.Count > 0)
            {
                foreach(T item in this.Elementos)
                {
                    str.AppendLine(item.ToString());
                }
            }
            else
            {
                str.AppendLine($"Sin elementos al momento..");
            }
            return str.ToString();
        }
    }
}
