using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesFinal
{
//    Extenderá el tipo Random y le agregará el método de extensión TirarUnaMoneda
//    que retornará de forma aleatoria alguno de los valores del enumerado LadosMoneda.

    public static class ExtensionRandom
    {
        public static Int32 TirarUnaMoneda(this Random r)
        {
            Int32 cant = Enum.GetValues(typeof(LadosMoneda)).Length;

            return r.Next(1, cant + 1);
        }
    }
}
