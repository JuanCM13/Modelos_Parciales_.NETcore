using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_LABORATORIO2_2021
{
    public class Biblioteca
    {
        private Int32 capacidad;
        private List<Libro> libros;

        private Biblioteca()
        {
            libros = new();
        }

        private Biblioteca(Int32 cap)
            : this()
        {
            capacidad = cap;
        }

        public Double PrecioDeNovelas { get => this.ObtenerPrecio(ELibro.PrecioDeNovelas); }

        public Double PrecioDeManuales { get => this.ObtenerPrecio(ELibro.PrecioDeManuales); }

        public Double PrecioTotal { get => this.ObtenerPrecio(ELibro.PrecioTotal); }

        public static implicit operator Biblioteca(Int32 cap)
        {
            Int32 capacidad = cap;

            if(cap < 0)
            {
                capacidad = 0;
            }
            return new Biblioteca(capacidad);
        }

        public static bool operator ==(Biblioteca b , Libro l)
        {
            if(!(b is null) && !(l is null))
            {
                foreach(Libro item in b.libros)
                {
                    if(l.Equals(item))
                    {
                        return true;                     
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Biblioteca b, Libro l)
        {
            return !(b == l);
        }

        public static Biblioteca operator +(Biblioteca b , Libro l)
        {
            if(!(b is null) && !(l is null))
            {
                if (b != l)
                {
                    if (b.libros.Count < b.capacidad)
                    {
                        b.libros.Add(l);
                    }
                    else
                    {
                        Console.WriteLine($"Ya se alcanzo el maximo de espacio de la biblioteca: ({b.capacidad}) libros..");
                    }
                }
                else
                {
                    Console.WriteLine("Error, el libro ya se encuentra en la lista");
                }
            }
            else
            {
                Console.WriteLine("Error, fijate que algo vino nulo");
            }
            return b;
        }

        private Double ObtenerPrecio(ELibro lib)
        {
            Double ret = 0;
            foreach(Libro item in this.libros)
            {
                if(item is Novela && (lib == ELibro.PrecioDeNovelas || lib == ELibro.PrecioTotal))
                {
                    ret += (Novela)item;
                }
                else
                {
                    if(item is Manual && (lib == ELibro.PrecioDeManuales || lib == ELibro.PrecioTotal))
                    {
                        ret += (Single)((Manual)item);
                    }
                }
            }
            return ret;
        }

        public static String Mostrar(Biblioteca b)
        {
            StringBuilder str = new StringBuilder().AppendLine($"Negro me pasaste la biblioteca sin instanciar...");
            
            if(!(b is null))
            {
                str.Clear();

                str.AppendLine($"Biblioteca:\nCapaciadad: {b.capacidad} -- ocupado: {b.libros.Count}\n" +
                    $"Precio Novelas: {b.PrecioDeNovelas}\nPrecio Manuales: {b.PrecioDeManuales}\nPrecio total: {b.PrecioTotal}\n" +
                    $"Informacion Libros: \n");
                
                if(b.libros.Count > 0)
                {
                    foreach (Libro item in b.libros)
                    {
                        str.AppendLine(item.ToString());
                    }
                }
                else
                {
                    str.AppendLine($"Sin libros al momento..");
                }
            }
            return str.ToString();
        }
    }
}
