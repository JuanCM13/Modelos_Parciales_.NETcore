using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesFinal
{
    public interface IJugador
    {
        short Nivel { get; }

        Int32 PuntosDeVida { get; }

        Int32 Atacar();

        void RecibirAtaque(Int32 puntosAtaque);
    }
}
