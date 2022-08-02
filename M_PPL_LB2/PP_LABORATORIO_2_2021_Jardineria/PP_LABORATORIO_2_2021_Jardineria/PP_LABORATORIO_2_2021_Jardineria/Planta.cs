using System;
using System.Text;

namespace PP_LABORATORIO_2_2021_Jardineria
{
    public abstract class Planta
    {
        private String nombre;
        private Int32 tamanio;

        public Int32 Tamanio { get => this.tamanio; }

        public abstract bool TieneFlores { get; }

        public abstract bool TieneFruto { get; }

        public Planta(String nombre , Int32 tam)
        {
            this.nombre = nombre;
            this.tamanio = tam;
        }

        public virtual String ResumenDeDatos()
        {
            String frutos = this.TieneFruto ? "Tiene frutos" : "No tiene frutos";
            String flores = this.TieneFlores ? "Tiene flores" : "No tiene flores";

            return new StringBuilder().AppendLine($"Tipo Planta: {this.GetType().Name}\nNombre: {this.nombre}\n" +
                $"Tamaño: {this.Tamanio}\n{frutos}\n{flores}").ToString();
        }
    }
}
