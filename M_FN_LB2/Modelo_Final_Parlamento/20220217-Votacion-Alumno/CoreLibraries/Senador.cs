using System;
using System.Drawing;

namespace CoreLibraries
{
    public class Senador : IParlamentario 
    {
        private object controlVisual;
        private String banca;
        private bool presentismo;
        private EVoto voto;
        private static Random rnd;

        static Senador()
        {
            rnd = new Random();
        }

        public Senador() { }

        public Senador(String banca , Object contVisual) 
        {
            Banca = banca;
            ControlVisual = contVisual;
            Voto = EVoto.Indefinido;

        }

        [System.Text.Json.Serialization.JsonIgnore]


        public object ControlVisual { get => controlVisual; set => controlVisual = value; }

        public String Banca
        {
            get { return this.banca; }
            set { this.banca = value; }
        }

        public bool Presentismo{ get => presentismo; set => presentismo = value; }

        public EVoto Voto { get => voto; set => voto = value; }

        public Color ColorDeBanca
        {
            /*i. Si está presente, evaluará su voto
            ii. Caso contrario, el color retornado será Black.
            */
            get
            {
                if (this.Presentismo)
                {
                    switch (this.Voto)
                    {
                        case EVoto.Abstencion:
                            return Color.FromArgb(0,200,255);
                        case EVoto.Negativo:
                            return Color.DarkRed;
                        case EVoto.Positivo:
                            return Color.DarkGreen;
                        default:
                            return Color.DarkBlue;
                    }
                }
                else
                    return Color.Black;
            }
        }

        public bool AperturaSesion
        {
            set
            {
                if (value)
                {
                    if (this.banca == "P")
                    {
                        this.Presentismo = value;
                    }
                    else
                    {
                        // TODO:  Asignar presentismo
                        this.presentismo = Senador.rnd.Next(1, 3) == 1 ? true : false; 
                    }
                }
                else
                {
                    this.Presentismo = false;
                }
            }
        }

        public void EmitirVoto()
        {
            /*EmitirVoto asignará de forma aleatoria uno de los valores: Abstencion, Positivo, Negativo; no
            pudiendo asignar nunca Indefinido*/
            this.Voto = (EVoto)Senador.rnd.Next(2, ((Enum.GetValues(typeof(EVoto)).Length)+1));
            //this.Voto = (EVoto)Senador.rnd.Next(Int32.Parse((Enum.GetValues(typeof(EVoto)).GetValue(1)).ToString()),(Enum.GetValues(typeof(EVoto)).Length)+1);
        }
    }
}
