using System;
using System.Text;

namespace EntidadesSP
{
    ///Crear, en un proyecto de tipo class library (EntidadesSP), las siguientes clases:
    ///Articulo:
    ///atributos privados: marca : string, codigo : int, precio : double 
    ///propiedes públicas de lectura y escritura para todos sus atributos.
    ///contructor con 3 parámetros.
    ///Sobrescritura del método ToString, mostrando todos sus atributos.
    public class Articulo
    {
        private String marca;
        private Double precio;
        private Int32 codigo;

        public Articulo() { }

        public Articulo(String marc, Int32 codigo, Double prec)
        {
            Codigo = codigo;
            Marca = marc;
            Precio = prec;
        }
        
        public Int32 Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        public Double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public String Marca
        {
            get { return this.marca; }
            set { String marca = value; }
        }

        public override string ToString()
        {
            return new StringBuilder().Append($"Marca: {this.Marca} -- Precio: {this.Precio} -- Codigo: {this.Codigo}").ToString();
        }
    }
}
