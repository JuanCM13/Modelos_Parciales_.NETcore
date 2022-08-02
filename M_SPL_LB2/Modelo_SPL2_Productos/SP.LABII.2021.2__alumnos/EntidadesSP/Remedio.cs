using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///Remedio-> hereda de producto
    ///ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
    public class Remedio : Producto
    {
        public Remedio() { }

        public Remedio(String mar, String tip, Int32 cod, Double prec)
            : base(mar, tip, cod, prec)
        { }

        public override string ToString()
        {
            return "Remedio: " + base.ToString() + "\n";
        }
    }
}
