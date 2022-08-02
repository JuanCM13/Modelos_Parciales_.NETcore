using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///Cerveza-> hereda de Articulo
    public class Cerveza : Articulo
    {
        public Cerveza() { }

        public Cerveza(String marc, Int32 cod, Double prec)
            : base(marc,cod,prec)
        { }
    }
}
