using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_LABORATORIO_2_2021_Jardineria
{
    public class Arbusto : Planta
    {
        public Arbusto(String nombre , Int32 tam)
            : base(nombre , tam)
        {}

        public override bool TieneFlores { get => false; }

        public override bool TieneFruto { get => false; }
    }
}
