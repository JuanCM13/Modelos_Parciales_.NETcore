using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///El manejador de eventos (Caja_EventoPrecio) invocará al método (de clase) 
    ///ImprimirFactura(Caja<T>) (se alojará en la clase Facturadora<T>), que retorna un booleano 
    ///indicando si se pudo escribir o no.
    ///la clase Facturadora<T> sólo podrá 'facturar' Zapatos, Fósforos o Remedios.
    public class Facturadora<T> where T : Producto
    {
        public static bool ImprimirFactura(Caja<T> caja)
        {
            ///El archivo se guardará con el nombre 'facturas.log' en la carpeta 'Mis documentos' del cliente.
            bool ret = false;
            String semiRuta;
            String fullRuta;

            //se imprima en un archivo de texto: 
            ///la fecha (con hora, minutos y segundos) y el total de la caja (en un nuevo renglón). 
            ///Se deben acumular los mensajes. 

            if(!(caja is null))
            {
                semiRuta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                fullRuta = Path.Combine(semiRuta, "facturas.log");

                try
                {
                    using (StreamWriter stw = new StreamWriter(fullRuta, append: true))
                    {
                        stw.Write(DateTime.Now + "\n");
                        stw.WriteLine(caja.PrecioTotal.ToString());
                        ret = true;
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception($"Falla al facturar, metodo ImprimirFacturara, clase Facturadora\nError: {ex.Message}", ex);
                }                
            }
            return ret;
        }
    }
}
