using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesFinal
{
    public class Hechicero : Personaje
    {
        public Hechicero(Decimal id, String nombre , short nivel)
            : base(id, nombre , nivel)
        { }

        protected override void AplicarBeneficiosDeClase()
        {
            /*Implementa el método AplicarBeneficiosDeClase 
             * aplicando una bonificación para el personaje de un 10 % de puntos de poder adicionales. Descartar los decimales.*/
            base.puntosDePoder += (base.puntosDePoder * 10) / 100;
        }
    }
}
