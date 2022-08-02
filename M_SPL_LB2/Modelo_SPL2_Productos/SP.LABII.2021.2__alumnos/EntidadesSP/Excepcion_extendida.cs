using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///Agregar, para la clase CajaLlenaException, un método de extensión (InformarNovedad():string)
    ///que retorne el mensaje de error
    public static class Excepcion_extendida
    {
        public static String InformarNovedad(this CajaLlenaException c)
        {
            return c.Message;
        }
    }
}
