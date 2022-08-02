using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreLibraries
{
    public class Parlamento<T> 
        where T : IParlamentario
    {
        public delegate void InformarCambioDeEstado(T banca);

        private List<T> bancas;
        private bool estadoSesion;
        private T presidente;
        public static event FinalizarRegistro FinVotacion;
        public static event FinalizarRegistro ParlamentariosRegistrados;
        public static event InformarCambioDeEstado OcupaBanca;
        public static event InformarCambioDeEstado VotoEmitido;

        public Parlamento()
        {}

        public Parlamento(T presidente)
        {
            this.Bancas = new();
            this.Presidente = presidente;
        }

        public T Presidente { get => presidente; set => presidente = value; }

        public bool EstadioSesion
        {
            set
            {
                this.estadoSesion = value;
                /*Asignará estadoSesion según el valor recibido.
                ii. Dentro de un hilo secundario, recorrerá la lista de bancas.
                1. Le asignará a cada banca AperturaSesion informando el estadoSesion.
                2. Informará mediante el evento OcupaBanca si la banca fue ocupada.
                3. Hará un sleep de 50ms*/
                Task.Run(() =>
                            {
                                foreach(T item in this.Bancas)
                                {
                                    item.AperturaSesion = this.estadoSesion;
                                    Parlamento<T>.OcupaBanca.Invoke(item);
                                    Thread.Sleep(50);
                                }
                            });

                /*Al finalizar, informará que se completó el registro de bancas mediante el evento
                ParlamentariosRegistrados.*/
                Parlamento<T>.ParlamentariosRegistrados();
            }
        }

        public List<T> Bancas { get => bancas; set => bancas = value; }

        public Int32 VotosAbstenciones { get => this.ContarVotos(EVoto.Abstencion); }

        public Int32 VotosNegativos { get => this.ContarVotos(EVoto.Negativo); }

        public Int32 VotosAfirmativos { get => this.ContarVotos(EVoto.Positivo); }

        private Int32 ContarVotos(EVoto vot)
        {
            Int32 acum = 0;
            foreach(T item in this.Bancas)
            {
                if(item.Voto == vot)
                {
                    acum++;
                }
            }
            return acum;
        }

        public void CancelarVotacion() { }

        public void DesempatePresidente() 
        {
            /*
             * . DesempatePresidente:
                i. Si la votación no está empatada, lanzará la excepción NoNecesitaDesempateException.
                ii. Caso contrario, le pedirá Emitir Voto a la entidad Presidente del Parlamento e informará
                dicho voto mediante el evento VotoEmitido
             */
            if(this.VotosAfirmativos - this.VotosNegativos != 0)
            {
                throw new NoNecesitaDesempateException("No hace falta desempatar, tenemos ganador..");
            }
            else
            {
                this.presidente.EmitirVoto();
                Parlamento<T>.VotoEmitido.Invoke(presidente);
            }
        }

        public void IniciarVotacion() 
        {
            Random rnd = new Random();
            /*i. Dentro de un hilo secundario, recorrerá la lista de bancas.
            1. Si la banca está Presente, emitirá su voto y se informará mediante el evento
            VotoEmitido. Luego hará un sleep de entre 400ms y 1 segundo.
            ii. Si la votación culmina empatada, se pedirá el DesempatePresidente.
            iii. Luego se invocará el evento FinVotacion y se guardará el resultado de dicha votación
            mediante el Guardar(T) de JsonManager.*/
            Task.Run(() => 
                            { 
                                foreach(T item in this.Bancas)
                                {
                                    if(item.Presentismo)
                                    {
                                        item.EmitirVoto();
                                        Parlamento<T>.VotoEmitido.Invoke(item);
                                        Thread.Sleep(rnd.Next(400,1001));
                                    }
                                }
                            }).Wait();

            if(this.VotosAfirmativos - this.VotosNegativos == 0)
            {
                this.DesempatePresidente();
            }            
            Parlamento<T>.FinVotacion();
            Files.JsonManager<Parlamento<T>>.Guardar(this);
        }


    }
}
