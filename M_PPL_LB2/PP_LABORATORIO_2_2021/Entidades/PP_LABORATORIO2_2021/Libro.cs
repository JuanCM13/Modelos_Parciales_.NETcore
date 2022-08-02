using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_LABORATORIO2_2021
{
    public abstract class Libro
    {
        protected Autor autor;
        protected Int32 cantidadDePaginas;
        protected static Random generadorDePaginas;
        protected Single precio;
        protected String titulo;

        static Libro()
        {
            Libro.generadorDePaginas = new();
        }

        public Libro(Single precio , String titulo , Autor autor)          
        {
            this.precio = precio;
            this.titulo = titulo;
            this.autor = autor;
        }

        public Libro(String titulo , String apellido , String nombre , Single precio)
            : this(precio , titulo , new Autor(nombre , apellido))
        {}

        public Int32 CantidadDePaginas
        {
            get 
            {
                if(this.cantidadDePaginas == 0)
                {
                    this.cantidadDePaginas = Libro.generadorDePaginas.Next(10 , 571);
                }
                return this.cantidadDePaginas;
            }
        }

        private static String Mostrar(Libro l)
        {
            StringBuilder str = new StringBuilder().AppendLine($"Negro me pasaste el libro sin instanciar...");

            if(!(l is null))
            {
                str.Clear();
                str.AppendLine($"Tipo Libro: {l.GetType().Name}\nTitulo: {l.titulo}\nPrecio: " +
                    $"{l.precio}\nCantidad de paginas: {l.CantidadDePaginas}\nDatos Autor: {(String)l.autor}");
            }
            return str.ToString();
        }

        public static bool operator ==(Libro l1 , Libro l2)
        {
            if(!(l1 is null) && !(l2 is null))
            {
                return l1.titulo == l2.titulo && l1.autor == l2.autor;
            }
            return false;
        }

        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }

        public static explicit operator String(Libro l1)
        {
            return Libro.Mostrar(l1);
        }
    }
}
