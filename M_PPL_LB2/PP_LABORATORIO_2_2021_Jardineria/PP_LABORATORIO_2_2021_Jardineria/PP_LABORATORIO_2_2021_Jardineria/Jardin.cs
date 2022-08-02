using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_LABORATORIO_2_2021_Jardineria
{
    public enum Tipo { Terrozo , Arenozo }
    public class Jardin 
    {
        private Int32 espacioTotal;
        private List<Planta> plantas;
        private static Tipo suelo;

        static Jardin()
        {
            Jardin.suelo = Tipo.Terrozo;
        }

        private Jardin()
        {
            this.plantas = new();
        }

        public Jardin(Int32 espa)
            : this()
        {
            this.espacioTotal = espa;
        }

        public Tipo TipoSuelo { set => Jardin.suelo = value; }

        public static bool operator +(Jardin j , Planta p)
        {
            if(!(p is null) && !(j is null))
            {
                if(j.EspacioOcupado(p) <= j.espacioTotal)
                {
                    j.plantas.Add(p);
                    return true;
                }
            }
            return false;
        }

        private Int32 EspacioOcupado(Planta p)
        {        
            if(!(p is null))
            {
                return this.EspacioOcupado() + p.Tamanio;
            }
            return -1; //error, vino null la planta
        }

        private Int32 EspacioOcupado()
        {
            Int32 ret = 0;
            foreach(Planta item in this.plantas)
            {
                ret += item.Tamanio;
            }
            return ret;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder().AppendLine($"Composicion del Jardin: {Enum.GetName(typeof(Tipo),Jardin.suelo)}\n" +
                $"Espacio ocupado: {this.EspacioOcupado()} de {this.espacioTotal}\nLista de Plantas: \n");

            if(this.plantas.Count > 0)
            {
                foreach(Planta item in this.plantas)
                {
                    str.AppendLine(item.ResumenDeDatos());
                }
            }
            else
            {
                str.AppendLine($"Sin plantas al momento..");
            }
            return str.ToString();
        }
    }
}
