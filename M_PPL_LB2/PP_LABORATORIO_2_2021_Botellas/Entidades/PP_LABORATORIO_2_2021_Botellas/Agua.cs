using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Botellas
{
    public enum TipoAgua { Mineral , ConGas , SinGas , DeCanilla }
    public class Agua : Botella
    {
        public TipoAgua tipo;

        public Agua(String marca, Double precio, Int32 capacidad, TipoAgua tipo)
            : base(marca , precio , capacidad)
        {
            this.tipo = tipo;
        }

        public Agua(String marca, Double precio, TipoAgua tipo)
            : this(marca , precio , 500 , tipo)
        {}

        public override double Ganancia { get => (this.precio + ((this.precio * 25)/100)); }

        public static bool operator ==(Agua a1 , Agua a2)
        {
            if(!(a1 is null) && !(a2 is null))
            {
                return a1.tipo == a2.tipo && a1 == ((Botella)a2);
            }
            return false;
        }

        public static bool operator !=(Agua a1, Agua a2)
        {
            return !(a1 == a2);
        }

        public override void ServirMedida()
        {
            this.contenido = 0;
        }

        public override bool Equals(object obj)
        {
            if(obj is Agua)
            {
                return this == ((Agua)obj);
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nTipo Agua: {Enum.GetName(typeof(TipoAgua), this.tipo)}\n";
        }
    }
}
