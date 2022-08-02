using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesFinal
{
    public class Logger
    {
        private String ruta;

        public Logger(String ruta) { }

        public void GuardarLog(String texto)
        {
            /*Tiene un método GuardarLog que guarda el texto recibido como 
             * argumento en el archivo del log. No sobrescribir el contenido del archivo, anexar.*/
            if(this.ruta is not null && !String.IsNullOrWhiteSpace(texto))
            {
                try
                {
                    using (StreamWriter stW = new StreamWriter(Path.Combine(this.ruta,"juancruzMendez.rchivoLog.log"), append: true))
                    {
                        stW.WriteLine(texto);
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception($"Error al guardar log, metodo GuardarLog(), clase Logger\nError tipo: {ex.Message}", ex);
                }
            }
        }

    }
}
