using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

namespace Files
{
    public static class JsonManager<T>
    {
        private static String file;

        static JsonManager()
        {
            file = "votacion.json";
        }

        /*Guardar(T elemento) guardará el elemento recibido como parámetro en un archivo de texto:
        a. Su contenido será el "elemento" convertido a JSON.
        b. Dicho archivo será guardado en donde indique el atributo file.
        c. De haber un error, se lanzará FilesException.*/
        public static void Guardar(T elemento)
        {
            try
            {
                JsonManager<T>.Guardar(JsonManager<T>.file, elemento);
            }
            catch(Exception) //asi me guarda tambien la info de que paso por aca, si lo catcheo con ex y relanzo ex, se reinicia el stacktrace y
            {               //tira excepcion sin manejar..
                throw;
            }
        }

        public static void Guardar(String file, T elemento)
        {
            if(!(file is null) && !(elemento is null))
            {
                try
                {
                    String data = JsonSerializer.Serialize(elemento, typeof(T));
                    File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),file) , data);
                }
                catch(Exception ex)
                {
                    throw new Exception($"Error metodo: {System.Reflection.MethodBase.GetCurrentMethod().Name} " +
                        $"-- de la Clase: {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name}\nError tipo: {ex.Message}", ex);
                }
            }
        }

    }
}
