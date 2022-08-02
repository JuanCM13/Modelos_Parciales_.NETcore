using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///Fosforo-> hereda de producto 
    ///ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
    public class Fosforo : Producto
    {
        public Fosforo() { }

        public Fosforo(String mar, String tip, Int32 cod, Double prec)
            : base(mar, tip, cod, prec)
        { }

        public override string ToString()
        {
            return "Fosforo: " + base.ToString() + "\n";
        }
    }
}
