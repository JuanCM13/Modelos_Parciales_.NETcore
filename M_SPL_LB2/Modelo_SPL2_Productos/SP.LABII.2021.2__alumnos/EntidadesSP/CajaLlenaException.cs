using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    public class CajaLlenaException : Exception
    {
        public CajaLlenaException()
            : this("La caja ya esta llena..")
        { }

        public CajaLlenaException(String mens)
            : this(mens,null)
        { }

        public CajaLlenaException(String mens , Exception inner)
            : base(mens, inner)
        { }
    }
}
