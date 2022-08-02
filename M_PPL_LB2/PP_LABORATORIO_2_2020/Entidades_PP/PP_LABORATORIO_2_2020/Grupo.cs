using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_LABORATORIO_2_2020
{
    public enum EtipoManada { Unica , Mixta }
    public class Grupo
    {
        private String nombre;
        private List<Mascota> mascotas;
        private static EtipoManada tipo;

        static Grupo()
        {
            Grupo.tipo = EtipoManada.Unica;
        }

        private Grupo()
        {
            this.mascotas = new();
        }

        public Grupo(String nom)
            : this()
        {
            nombre = nom;
        }

        public Grupo(String nom , EtipoManada tipo)
            : this(nom)
        {
            this.Tipo = tipo;
        }

        public EtipoManada Tipo { set => Grupo.tipo = value; }

        public static bool operator ==(Grupo g , Mascota m)
        {
            if(!(g is null) && !(m is null))
            {
                foreach(Mascota item in g.mascotas)
                {
                    if(m.Equals(item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Grupo g, Mascota m)
        {
            return !(g == m);
        }

        public static Grupo operator +(Grupo g, Mascota m)
        {
            if (!(g is null) && !(m is null))
            {
                if(g != m)
                {
                    g.mascotas.Add(m);
                }
                else
                {
                    Console.WriteLine($"Error, La mascota {m} ya se encuentra en el listado del grupo!");
                }
            }
            else
            {
                Console.WriteLine("Error uno de los objetos fue nulo");
            }
            return g;
        }

        public static Grupo operator -(Grupo g, Mascota m)
        {
            Int32 index;

            if(!(g is null) && !(m is null))
            {
                if(g == m)
                {
                    index = 0;
                    foreach(Mascota item in g.mascotas)
                    {
                        if(m.Equals(item))
                        {
                            break;
                        }
                        index++;
                    }
                    g.mascotas.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine($"Error, la mascota: {m} no se encuentra en el listado del grupo..");
                }
            }
            else
            {
                Console.WriteLine("Error uno de los objetos fue nulo");
            }
            return g;
        }

        /*
            Grupo: Río – tipo: Mixta
            Integrantes (6):
            perro - Moro - Pitbull, edad 0
            perro - Julio - Cruza, edad 13
            perro - Ramón - Salchicha, alfa de la manada, edad 2
            gato - José - Angora
            gato - Mauri - Cruza
            gato - Fer – Siamés
        */
        public static implicit operator String(Grupo g)
        {
            StringBuilder str = new StringBuilder().AppendLine("Error, el grupo vino nullo..");

            if(!(g is null))
            {
                str.Clear();
                str.AppendLine($"Grupo: {g.nombre} -- Tipo: {Enum.GetName(typeof(EtipoManada),Grupo.tipo)}\nIntegrantes ({g.mascotas.Count}):");
                if(g.mascotas.Count > 0)
                {
                    foreach(Mascota item in g.mascotas)
                    {
                        str.AppendLine(item.ToString());
                    }
                }
                else
                {
                    str.AppendLine("*** Sin mascotas al momento... ***");
                }
            }
            return str.ToString();
        }
    }
}
