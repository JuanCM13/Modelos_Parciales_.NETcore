using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_LABORATORIO_2_2020
{
    public class Perro : Mascota
    {
        private Int32 edad;
        private bool esAlfa;

        public Perro(String nombre , String raza)
            : this(nombre , raza , 0 , false)
        {}

        public Perro(String nombre, String raza , Int32 edad , bool esAlfa)
            : base(nombre , raza)
        {
            this.edad = edad;
            this.esAlfa = esAlfa;
        }

        protected override string Ficha()
        {
            StringBuilder str = new StringBuilder().Append($"Perro -- {base.DatosCompletos()} -- ");

            if(this.esAlfa)
            {
                str.Append($"Es alfa de la manada -- ");
            }

            str.AppendLine($"Edad: {this.edad}");
            return str.ToString();
        }

        public static bool operator ==(Perro p1 , Perro p2)
        {
            if(!(p1 is null) && !(p2 is null))
            {
                return p1.edad == p2.edad && p1 == ((Mascota)p2);
            }
            return false;
        }

        public static bool operator !=(Perro p1, Perro p2)
        {
            return !(p1 == p2);
        }

        public static explicit operator Int32(Perro p)
        {
            if(!(p is null))
            {
                return p.edad;
            }
            return -1;
        }

        public override bool Equals(object obj)
        {
            if(obj is Perro)
            {
                return this == ((Perro)obj);
            }
            return false;
        }

        public override string ToString()
        {
            return this.Ficha();
        }
    }
}
