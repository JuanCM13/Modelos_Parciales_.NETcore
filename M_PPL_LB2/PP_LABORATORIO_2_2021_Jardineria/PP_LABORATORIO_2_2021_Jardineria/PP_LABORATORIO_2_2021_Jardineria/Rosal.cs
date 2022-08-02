using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_LABORATORIO_2_2021_Jardineria
{
    public enum Color { Roja , Blanca , Amarilla , Rosa , Azul }
    public class Rosal : Planta
    {
        private Color florColor;

        public Rosal(String nombre , Int32 tam)
            : this(nombre , tam , Color.Blanca)
        { }

        public Rosal(String nombre, Int32 tam, Color col)
            : base(nombre,tam)
        {
            this.florColor = col;
        }

        public override bool TieneFlores { get => true; }

        public override bool TieneFruto { get => false; }

        public override string ResumenDeDatos()
        {
            return base.ResumenDeDatos() + $"Color de flores: {Enum.GetName(typeof(Color),this.florColor)}\n";
        }
    }
}
