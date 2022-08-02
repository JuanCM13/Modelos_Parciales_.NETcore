using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Botellas;

namespace Entidades.Establecimiento
{
    public class Bar
    {
        private List<Botella> botellas;
        private Int32 capacidadMaximaBotellas;
        private String nombre;
        private Double recaudacion;
        
        public Bar()
        {
            this.botellas = new();
            this.capacidadMaximaBotellas = 5;
            this.nombre = "Sin nombre";
        }

        public Bar(Int32 capacidad)
            : this()
        {
            this.capacidadMaximaBotellas = capacidad;
        }

        public Bar(String nombre , Int32 capacidad)
            : this(capacidad)
        {
            this.nombre = nombre;
        }

        public List<Botella> Botellas { get => this.botellas; }

        public String MostrarBar
        {
            get
            {
                return Bar.Mostrar(this);
            }
        }

        public static explicit operator Double(Bar b)
        {
            Double ret = -1;
            if(!(b is null))
            {
                ret = 0;
                foreach(Botella item in b.Botellas)
                {
                    ret += item.Ganancia;
                }
            }
            return ret;
        }

        public static bool operator ==(Bar b , Botella bot)
        {
            if(!(b is null) && !(bot is null))
            {
                foreach(Botella item in b.Botellas)
                {
                    if(bot.Equals(item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Bar b, Botella bot)
        {
            return !(b == bot);
        }

        public static Bar operator +(Bar b , Botella bot)
        {
            if(!(b is null) && b.Botellas.Count < b.capacidadMaximaBotellas && b != bot)
            {
                b.Botellas.Add(bot);
            }
            return b;
        }

        public static Bar operator +(Bar b , Double rec)
        {
            if(!(b is null))
            {
                b.recaudacion += rec;
            }
            return b;
        }

        public static Bar operator -(Bar b , Botella bot)
        {
            if(b == bot)
            {
                bot.ServirMedida();
                b += bot.Ganancia;
                if(bot.PorcentajeContenido == 0)
                {
                    b.Botellas.Remove(bot);
                }
            }
            return b;
        }

        private static String Mostrar(Bar b)
        {
            StringBuilder str = new StringBuilder().AppendLine("Error, el bar no fue instanciado..");
            if(!(b is null))
            {
                str.Clear();
                str.AppendLine($"Nombre Bar: {b.nombre}\nCapacidad Maxima Botellas: {b.capacidadMaximaBotellas}\nBotellas al momento: {b.Botellas.Count}\n" +
                    $"Recaudacion del bar: {(Double)b}\nDetalle de botellas: ");
                if(b.Botellas.Count > 0)
                {
                    foreach(Botella item in b.Botellas)
                    {
                        str.AppendLine(item.ToString());
                    }
                }
                else
                {
                    str.AppendLine($"Sin botellas al momento..");
                }
            }
            return str.ToString();
        }
    }
}
