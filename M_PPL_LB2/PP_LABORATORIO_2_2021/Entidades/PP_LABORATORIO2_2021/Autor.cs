using System;

namespace PP_LABORATORIO2_2021
{
    public class Autor
    {
        private String apellido;
        private String nombre;

        public Autor(String nom , String ape)
        {
            this.apellido = ape;
            this.nombre = nom;
        }

        public static implicit operator String(Autor a)
        {
            if(!(a is null))
            {
                return a.nombre + " , " + a.apellido;
            }
            return default;
        }

        public static bool operator ==(Autor a1 , Autor a2)
        {
            if(!(a1 is null) && !(a2 is null))
            {
                return a1.apellido == a2.apellido && a1.nombre == a2.nombre;
            }
            return false;
        }

        public static bool operator !=(Autor a1, Autor a2)
        {
            return !(a1 == a2);
        }
    }
}
