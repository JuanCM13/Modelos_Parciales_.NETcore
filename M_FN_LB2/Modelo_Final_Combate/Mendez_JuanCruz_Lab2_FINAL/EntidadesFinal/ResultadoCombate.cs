using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesFinal
{
    public class ResultadoCombate
    {
        private DateTime fechaCombate;
        private String nombreGanador;
        private String nombrePerdedor;

        public ResultadoCombate() { }

        public ResultadoCombate(DateTime fechaC , String nombreG , String nombreP)
        {
            this.FechaCombate = fechaC;
            this.nombreGanador = nombreG;
            this.nombrePerdedor = nombreP;
        }

        public DateTime FechaCombate
        {
            get { return this.fechaCombate; }
            set { this.fechaCombate = value; }
        }

        public String NombreGanador
        {
            get { return this.nombreGanador; }
            set { this.nombreGanador = value; }
        }

        public String NombrePerdedor
        {
            get { return this.nombrePerdedor; }
            set { this.nombrePerdedor = value; }
        }
    }
}
