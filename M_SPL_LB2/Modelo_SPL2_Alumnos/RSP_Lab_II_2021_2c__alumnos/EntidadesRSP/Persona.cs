using System;
using System.Text;
using System.Xml.Serialization;

namespace EntidadesRSP
{
    ///Persona
    ///Atributos (todos privados)
    ///dni : int
    ///apellido : string
    ///nombre : string
    ///Propiedades públicas de lectura y escritura para todos sus atributos.
    ///Constructor que reciba parámetros para cada atributo
    ///Polimorfismo sobre ToString
    ///    
    [XmlInclude(typeof(Alumno))]
    public class Persona
    {
        private Int32 dni;
        private String apellido;
        private String nombre;

        public Persona() { }

        public Persona(Int32 dni, String nomb, String apell)
        {
            this.Nombre = nomb;
            this.Apellido = apell;
            this.Dni = dni;
        }
        
        public Int32 Dni
        {
            get { return this.dni; }
            set { this.dni = value; }
        }

        public String Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        public String Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public override string ToString()
        {
            return new StringBuilder().Append($"Nombre: {this.Nombre} -- Apellido: {this.Apellido} -- DNI: " +
                $"{this.Dni}").ToString();
        }
    }
}
