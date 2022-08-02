using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    public class LataLlenaException : Exception
    {
        public LataLlenaException()
            :this("Lata llena..")
        { }

        public LataLlenaException(String mens)
            : this(mens,null)
        { }

        public LataLlenaException(String mens , Exception inner)
            : base(mens, inner)
        { }
    }
}
