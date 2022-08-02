using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Botellas
{
    public enum TipoCerveza { Rubia , Negra , Light , Lager }
    public class Cerveza : Botella
    {
        public Int32 medida;
        public TipoCerveza tipo;

        public Cerveza(String marca , Double precio , Int32 capacidad , TipoCerveza tipo)
            : this(marca , precio , capacidad , tipo , (capacidad / 3))
        {}

        public Cerveza(String marca, Double precio, Int32 capacidad, TipoCerveza tipo , Int32 medida)
            : base(marca , precio , capacidad)
        {
            this.tipo = tipo;
            this.medida = medida;
        }

        public override double Ganancia { get => (this.precio + ((this.precio * 50)/100)); }

        public static bool operator ==(Cerveza c1 , Cerveza c2)
        {
            if(!(c1 is null) && !(c2 is null))
            {
                return c1.tipo == c2.tipo && c1 == ((Botella)c2);
            }
            return false;
        }

        public static bool operator !=(Cerveza c1, Cerveza c2)
        {
            return !(c1 == c2);
        }

        public override void ServirMedida()
        {
            this.contenido -= this.medida;
            if(this.contenido < this.medida)
            {
                this.contenido = 0;
            }
        }

        public override bool Equals(object obj)
        {
            if(obj is Cerveza)
            {
                return this == ((Cerveza)obj);
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString() + $"Tipo Cerveza: {Enum.GetName(typeof(TipoCerveza),this.tipo)}\n";
        }
    }
}
