using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///Crear el manejador necesario para que, una vez capturado el evento, se imprima en un archivo de texto: 
    ///la fecha (con hora, minutos y segundos) y el total de la caja (en un nuevo renglón). 
    ///Se deben acumular los mensajes. 
    ///El archivo se guardará con el nombre 'facturas.log' en la carpeta 'Mis documentos' del cliente.
    ///El manejador de eventos (Lata_EventoPrecio) invocará al método (de clase) 
    ///ImprimirFactura(Lata<T>) (se alojará en la clase Facturadora<T>), que retorna un booleano 
    ///indicando si se pudo escribir o no.
    ///la clase Facturadora<T> sólo podrá 'facturar' tomates, pinturas o cervezas.
    public class Facturadora<T> where T :  Articulo
    {
        public static bool ImprimirFactura(Lata<T> lat)
        {
            bool ret = false;
            String semiRuta;
            String nombreArch;

            if(!(lat is null))
            {
                try
                {
                    semiRuta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    nombreArch = "facturas.log";

                    using (StreamWriter stW = new(Path.Combine(semiRuta, nombreArch), append: true))
                    {
                        stW.WriteLine(DateTime.Now);
                        stW.WriteLine($"Total Caja: {lat.PrecioTotal}");
                        ret = true;
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception($"Error, metodo ImprimirFactura, clase Facturadora\nErrorType: {ex.Message}", ex);
                }               
            }
            else
            {
                throw new Exception($"La lata recibida por param es null");
            }

            return ret;
        }
    }
}
