using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntidadesSP
{
    ///Tomate->hereda de Articulo 
    ///atributo público: tipo : string
    ///ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
    public class Tomate : Articulo , ISerializa , IDeserializa<Tomate>
    {
        public String tipo;

        public Tomate() { }

        public Tomate(String marc, String tip, Int32 cod , Double prec)
            : base(marc,cod,prec)
        {
            this.tipo = tip;
        }

        public override string ToString()
        {
            return "Tomate: " + base.ToString() + $" -- Tipo: {this.tipo}\n";
        }

        ///En la clase Tomate, implementar:
        ///implícitamente: PathXml, Xml() y Json(out T)

        public String PathXml
        {
            ///El archivo .xml guardarlo en el escritorio del cliente, con el nombre formado con: apellido.nombre.tomate.xml
            ///Ejemplo: Alumno Juan Pérez -> perez.juan.tomate.xml
            get 
            {
                String ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                return Path.Combine(ruta, "mendez.juanCruz.tomate.xml");
            }
        }

        public bool Xml()
        {
            bool ret = false;

            try
            {
                using (StreamWriter stW = new StreamWriter(this.PathXml , append : true))
                {
                    XmlSerializer xmS = new XmlSerializer(typeof(Tomate));
                    xmS.Serialize(stW , this);
                    ret = true;
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Error, metodo XML clase Tomate\nErrorType: {ex.Message}",ex);
            }
            return ret;
        }

        public bool Json(out Tomate elemento)
        {
            Tomate auxT = default;
            bool ret = false;

            try
            {
                using (StreamReader stR = new StreamReader(((ISerializa)this).PathJson) )
                {
                    auxT = (Tomate)JsonSerializer.Deserialize(stR.ReadToEnd() , typeof(Tomate), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error, metodo Json(out Tomate) clase Tomate\nErrorType: {ex.Message}", ex);
            }

            elemento = auxT;
            return ret;
        }

        ///explícitamente: PathJson, Xml(out T) y Json()

        String ISerializa.PathJson
        {
            get 
            {
                ///El archivo .json guardarlo en la carpeta 'Mis documentos' del cliente, con el nombre formado con: apellido.nombre.pintura.json
                ///Ejemplo: Alumno Juan Pérez -> perez.juan.pintura.json
                String ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return Path.Combine(ruta, "mendez.juanCruz.pintura.json");
            }
        }

        bool IDeserializa<Tomate>.Xml(out Tomate elemento)
        {
            Tomate auxT = default;
            bool ret = false;

            try
            {
                using (StreamReader stR = new StreamReader(this.PathXml))
                {
                    XmlSerializer xmS = new XmlSerializer(typeof(Tomate));
                    auxT = (Tomate)xmS.Deserialize(stR);
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error, metodo XML(out Tomate) clase Tomate\nErrorType: {ex.Message}", ex);
            }

            elemento = auxT;
            return ret;
        }

        bool ISerializa.Json()
        {
            bool ret = false;

            try
            {
                String aux = JsonSerializer.Serialize(this, typeof(Tomate));
                File.WriteAllText(((ISerializa)this).PathJson, aux);
                ret = true;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error, metodo Json() clase Tomate\nErrorType: {ex.Message}", ex);

            }
            return ret;
        }
    }
}
