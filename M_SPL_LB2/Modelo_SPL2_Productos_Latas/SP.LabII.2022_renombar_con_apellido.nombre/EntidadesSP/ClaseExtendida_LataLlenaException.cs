using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    public static class ClaseExtendida_LataLlenaException
    {
        ///Agregar, para la clase LataLlenaException, un método de extensión (InformarNovedad():string)
        ///que retorne el mensaje de error
        public static String InformarNovedad(this LataLlenaException l)
        {
            return l.Message;
        }
    }
}
