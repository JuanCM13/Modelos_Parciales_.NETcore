using System;
using System.Text;
using System.Collections.Generic;

namespace EntidadesSP
{
    ///Crear, en un proyecto de tipo class library (EntidadesSP), las siguientes clases:
    ///Producto:
    ///atributos protegidos: marca:string, tipo:string, codigo:int, precio:double 
    ///propiedes públicas de lectura y escritura para todos sus atributos.
    ///contructor con 4 parámetros.
    ///Sobrescritura del método ToString, mostrando todos sus atributos.
    public class Producto
    {
        protected String marca;
        protected String tipo;
        protected Int32 codigo;
        protected Double precio;

        public Producto() { }

        public Producto(String mar,String tip,Int32 cod,Double prec)
        {
            this.Marca = mar;
            this.Tipo = tip;
            this.Codigo = cod;
            this.Precio = prec;
        }

        public String Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public Int32 Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public Double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public override string ToString()
        {
            return new StringBuilder().Append($"Marca: {this.Marca} -- Precio: {this.Precio} -- Tipo: {this.Tipo} -- " +
                $"Codigo: {this.Codigo}").ToString();
        }
    }
}
