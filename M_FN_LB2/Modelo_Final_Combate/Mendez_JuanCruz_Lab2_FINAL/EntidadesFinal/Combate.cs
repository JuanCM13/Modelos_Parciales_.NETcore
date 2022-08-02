using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

/*ME QUEDE EN EL METODO COMBATIR EN LA PARTE QUE SERIALIZA LA INSTANCIA DE INICIARCOMBATE*/
namespace EntidadesFinal
{
    public sealed class Combate
    {
        private IJugador atacante;
        private IJugador atacado;
        private static Random random;
        public static event Action<IJugador, IJugador> RondaIniciada;
        public static event Action<IJugador> CombateFinalizado;

        static Combate()
        { Combate.random = new(); }

        public Combate(IJugador j1, IJugador j2)
        {
            this.atacante = this.SeleccionarPrimerAtacante(j1, j2);
            if(this.atacante == j1)
            {
                this.atacado = j2;
            }
            else
            {
                if(this.atacante == j2)
                {
                    this.atacado = j1;
                }
                else
                {
                    throw new BusinessException("Rompimos todo al asignar primer atacante y atacadoo");
                }
            }
            
        }

        private IJugador SeleccionarJugadorAleatoriamente(IJugador j1, IJugador j2)
        {
            IJugador auxRet = default;
            if (!(j1 is null) && !(j2 is null))
            {
                if (Combate.random.TirarUnaMoneda() == 1)
                {
                    auxRet = j1;
                }
                else
                {
                    auxRet = j2;
                }
            }
            return auxRet;
        }

        private IJugador SeleccionarPrimerAtacante(IJugador j1, IJugador j2)
        {
            IJugador ret = default;
            if (!(j1 is null) && !(j2 is null))
            {
                if(j1.Nivel < j2.Nivel)
                {
                    ret = j1;
                }
                else
                {
                    if(j1.Nivel > j2.Nivel)
                    {
                        ret = j2;
                    }
                    else
                    {
                        ret = this.SeleccionarJugadorAleatoriamente(j1,j2);
                    }
                }
                /*
                if (j1.Nivel < j2.Nivel || (j1.Nivel == j2.Nivel && Combate.random.TirarUnaMoneda() == 1))
                {
                    ret = j1;
                }
                else
                {
                    if (j1.Nivel > j2.Nivel || (j1.Nivel == j2.Nivel && Combate.random.TirarUnaMoneda() == 2))
                    {
                        ret = j2;
                    }
                }*/
            }
            return ret;
        }

        private void IniciarRonda()
        {
            /*Lanza el evento RondaIniciada pasandole como primer argumento al jugador atacante y como segundo argumento al jugador atacado. Sólo lanza el evento si el mismo tiene subscriptores.
            Genera un ataque del jugador atacante y lo impacta en el jugador atacado.*/
            if(!(Combate.RondaIniciada is null))
            {
                Combate.RondaIniciada.Invoke(this.atacante, this.atacado);
                this.atacado.RecibirAtaque(this.atacante.Atacar());
            }            
        }

        private IJugador EvaluarGanador()
        {
            /*
             * El método EvaluarGanador retorna al jugador atacante si el jugador atacado tiene cero puntos de vida.
             * De lo contrario, si el atacado todavía tiene vida, intercambia los roles 
             * (el jugador atacante pasará a ser el atacado, y el atacado pasará a ser el atacante) y retorna null.
             */
            IJugador ret = null;
            if(this.atacado.PuntosDeVida == 0)
            {
                ret = this.atacante;
            }
            else
            {
                IJugador auxJ = this.atacante;
                this.atacante = this.atacado;
                this.atacado = auxJ;
            }
            return ret;
        }

        private void Combatir()
        {
            /*
            * Llama a IniciarRonda y luego a EvaluarGanador, repite este proceso hasta que se encuentre un ganador, 
            * es decir que EvaluarGanador no retorne null.
            Una vez que haya un ganador lanza el evento CombateFinalizado pasándole como argumento al jugador ganador, 
            siempre y cuando el evento tenga suscriptores.*/
            IJugador ganador = default;
            while(true)
            {
                this.IniciarRonda();
                if(!(this.EvaluarGanador() is null))
                {
                    ganador = this.EvaluarGanador();
                    break;
                }
            }
            if(!(Combate.CombateFinalizado is null))
            {
                Combate.CombateFinalizado.Invoke(ganador);
                /*Cuando el combate finaliza genera una instancia de ResultadoCombate y la serializa a formato XML o JSON 
                    (a elección del alumno). Se debe instanciar ResultadoCombate con los siguientes datos:
                    Nombre del ganador (ToString)
                    Nombre del perdedor (ToString)
                    Fecha y hora actual
                     */
                try
                {
                    using (StreamWriter stW = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MendezJuanCruz.Combate.xml")))
                    {
                        XmlSerializer xmS = new(typeof(ResultadoCombate));
                        xmS.Serialize(stW, new ResultadoCombate(DateTime.Now, this.atacante.ToString(), this.atacado.ToString()));
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Error, falla al serializar ResultadoCombate, metodo Combatir(), clase Combate\nError tipo: {e.Message}", e);
                }
            }
        }

        public Task IniciarCombate()
        {
            return Task.Run(() => this.Combatir());
        }
    }
}
