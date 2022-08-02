using System;

namespace PP_LABORATORIO_2_2020
{
    public abstract class Mascota
    {
        private String nombre;
        private String raza;

        public Mascota(String nombre , String raza)
        {
            this.raza = raza;
            this.nombre = nombre;
        }

        public String Raza { get => this.raza; } 

        public String Nombre { get => this.nombre; }

        protected abstract String Ficha();

        protected virtual String DatosCompletos()
        {
            return this.Nombre + " - " + this.Raza;
        }

        public static bool operator ==(Mascota m1 , Mascota m2)
        {
            if(!(m1 is null) && !(m2 is null))
            {
                return m1.Nombre == m2.Nombre && m1.Raza == m2.Raza;
            }
            return false;
        }

        public static bool operator !=(Mascota m1, Mascota m2)
        {
            return !(m1 == m2);
        }
    }
}
