using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibraries
{
    public interface IParlamentario
    {
        bool AperturaSesion { set; }

        bool Presentismo { get; set; }

        EVoto Voto { get; set; }

        void EmitirVoto();

    }
}
