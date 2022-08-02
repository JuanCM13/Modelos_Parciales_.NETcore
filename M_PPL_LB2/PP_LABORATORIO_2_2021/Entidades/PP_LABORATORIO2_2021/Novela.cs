using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_LABORATORIO2_2021
{
    public class Novela : Libro
    {
        public EGenero genero;

        public Novela(String titulo , Single precio , Autor autor , EGenero genero)
            : base(precio , titulo , autor)
        {
            this.genero = genero;
        }

        public static bool operator ==(Novela n1 , Novela n2)
        {
            if(!(n1 is null) && !(n2 is null))
            {
                return n1.genero == n2.genero && n1 == ((Libro)n2);
            }
            return false;
        }

        public static bool operator !=(Novela n1, Novela n2)
        {
            return !(n1 == n2);
        }

        public static implicit operator Single(Novela n)
        {
            if (!(n is null))
            {
                return n.precio;
            }
            return -1;
        }

        public override bool Equals(object obj)
        {
            if(obj is Novela)
            {
                return this == ((Novela)obj);
            }
            return false;
        }

        public override string ToString()
        {
            return (String)((Libro)this) + $"Tipo Novela: {Enum.GetName(this.genero)} \n";
        }
    }
}
