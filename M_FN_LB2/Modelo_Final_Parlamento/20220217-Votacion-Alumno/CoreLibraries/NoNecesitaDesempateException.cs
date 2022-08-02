using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibraries
{
    public class NoNecesitaDesempateException : Exception
    {
        public NoNecesitaDesempateException()
            : this("No hace falta desempatar")
        { }

        public NoNecesitaDesempateException(String msje)
            : this(msje,null)
        {}

        public NoNecesitaDesempateException(String msje, Exception inner)
            : base(msje,inner)
        { }
    }
}
