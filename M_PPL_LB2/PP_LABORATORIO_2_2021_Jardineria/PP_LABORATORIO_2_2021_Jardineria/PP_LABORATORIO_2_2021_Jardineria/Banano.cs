using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_LABORATORIO_2_2021_Jardineria
{
    public class Banano : Planta
    {
        private String codigo;

        public Banano(String nombre, Int32 tam , String codigo)
            : base(nombre,tam)
        {
            this.codigo = codigo;
        }

        public override bool TieneFlores { get => true; }

        public override bool TieneFruto { get => true; }

        public override string ResumenDeDatos()
        {
            return base.ResumenDeDatos() + $"Codigo Internacional: {this.codigo}\n";
        }
    }
}
