using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void DelegadoAlumno(Object sender, EventArgs args);
namespace EntidadesRSP
{
    ///Alumno (deriva de Persona)
    ///Atributo
    ///nota : double
    ///Propiedad pública de lectura y escritura para su atributo.
    ///Constructor que reciba parámetro para cada atributo
    ///Polimorfismo sobre ToString
    ///Eventos (diseñados según convenciones vistas)
    ///Aprobar
    ///NoAprobar
    ///Promocionar
    ///Método de instancia (público)
    ///Clasificar() : void
    ///Si el atributo nota es menor a 4, lanzará el evento NoAprobar.
    ///Si el atributo nota es menor a 6 (y mayor o igual a 4), lanzará el evento Aprobar.
    ///Si el atributo nota es mayor o igual a 6, lanzará el evento Promocionar.
    public class Alumno : Persona
    {
        private Double nota;
        public static event DelegadoAlumno Aprobar;
        public static event DelegadoAlumno NoAprobar;
        public static event DelegadoAlumno Promocionar;

        public Alumno() :base(){ }

        public Alumno(Double nota, Int32 dni, String nombre, String apellido)
            : base(dni,nombre,apellido)
        {
            this.Nota = nota;
        }
            
        public Double Nota
        {
            get { return this.nota; }
            set { this.nota = value; }
        }

        public override string ToString()
        {
            return new StringBuilder().AppendLine($"{base.ToString()} -- Nota: {this.Nota}").ToString();
        }

        ///Si el atributo nota es menor a 4, lanzará el evento NoAprobar.
        ///Si el atributo nota es menor a 6 (y mayor o igual a 4), lanzará el evento Aprobar.
        ///Si el atributo nota es mayor o igual a 6, lanzará el evento Promocionar.
        public void Clasificar()
        {
            if(this.Nota < 4)
            {
                Alumno.NoAprobar.Invoke(this, new EventArgs());
            }
            else
            {
                if(this.Nota < 6)
                {
                    Alumno.Aprobar.Invoke(this, new EventArgs());
                }
                else
                {
                    Alumno.Promocionar.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
