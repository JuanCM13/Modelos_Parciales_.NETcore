using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_LABORATORIO2_2021
{
    public class Manual : Libro
    {
        public ETipo tipo;

        public Manual(String titulo , String apellido , String nombre , Single precio , ETipo tipo)
            : base(titulo , apellido , nombre , precio)
        {
            this.tipo = tipo;
        }

        public static bool operator ==(Manual m1 , Manual m2)
        {
            if(!(m1 is null) && !(m2 is null))
            {
                return m1.tipo == m2.tipo && m1 == ((Libro)m2);
            }
            return false;
        }

        public static bool operator !=(Manual m1, Manual m2)
        {
            return !(m1 == m2);
        }

        public static explicit operator Single(Manual m)
        {
            if(!(m is null))
            {
                return m.precio;
            }
            return -1;
        }

        public override bool Equals(object obj)
        {
            if(obj is Manual)
            {
                return this == ((Manual)obj);
            }
            return false;
        }

        public override string ToString()
        {
            return (String)((Libro)this) + $"Tipo Manual: {Enum.GetName(this.tipo)} \n";
        }
    }
}
