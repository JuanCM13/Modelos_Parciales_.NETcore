using System;
using System.Text;

namespace Entidades.Botellas
{
    public abstract class Botella
    {
        protected Int32 capacidad;
        protected Int32 contenido;
        protected String marca;
        protected Double precio;

        public Botella(String marca , Double precio)
            : this(marca , precio , 1000)
        {}

        public Botella(String marca, Double precio , Int32 capacidad)
        {
            this.capacidad = capacidad;
            this.contenido = this.capacidad;
            this.marca = marca;
            this.precio = precio;
        }

        public Double PorcentajeContenido
        {
            get 
            {
                return Math.Round( (Double)((this.contenido * 100) / this.capacidad) , 2); 
            }
        }
        
        public abstract Double Ganancia { get; }

        public abstract void ServirMedida();

        private static String ObtenerDatos(Botella b)
        {
            StringBuilder str = new StringBuilder().AppendLine("Error, la botella fue nula");
            if(!(b is null))
            {
                str.Append($"Tipo botella: {b.GetType().Name}\nMarca: {b.marca}\nPrecio: {b.precio}\nCapacidad: {b.capacidad}\nContenido: {b.contenido}");
            }
            return str.ToString();
        }

        public override string ToString()
        {
            return Botella.ObtenerDatos(this);
        }

        public static bool operator ==(Botella b1 , Botella b2)
        {
            if(!(b1 is null) && !(b2 is null))
            {
                return b1.marca == b2.marca && b1.capacidad == b2.capacidad;
            }
            return false;
        }

        public static bool operator !=(Botella b1, Botella b2)
        {
            return !(b1 == b2);
        }

        public static explicit operator String(Botella b)
        {
            if(!(b is null))
            {
                return b.marca;
            }
            return default;
        }

        public static Botella operator --(Botella b)
        {
            if(!(b is null))
            {
                b.ServirMedida();
            }
            return b;
        }
    }
}
