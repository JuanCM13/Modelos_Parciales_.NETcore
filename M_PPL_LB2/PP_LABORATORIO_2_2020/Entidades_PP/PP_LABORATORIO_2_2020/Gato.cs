using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_LABORATORIO_2_2020
{
    public class Gato : Mascota
    {
        public Gato(String nombre , String raza)
            : base(nombre , raza)
        { }

        protected override String Ficha()
        {
            return "Gato: " + base.DatosCompletos() + "\n";
        }

        public override string ToString()
        {
            return this.Ficha();
        }

        public static bool operator ==(Gato g1 , Gato g2)
        {
            if(!(g1 is null) && !(g2 is null))
            {
                return g1 == ((Mascota)g2);
            }
            return false;
        }

        public static bool operator !=(Gato g1, Gato g2)
        {
            return !(g1 == g2);
        }

        public override bool Equals(object obj)
        {
            if(obj is Gato)
            {
                return this == ((Gato)obj);
            }
            return false;
        }
    }
}
