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
    ///Pintura-> hereda de Articulo
    ///atributo protegido: color : string
    ///propiedad pública de lectura y escritura
    ///ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
    public class Pintura : Articulo, ISerializa, IDeserializa<Pintura>
    {
        protected String color;

        public Pintura() { }

        public Pintura(String marc, String color, Int32 cod, Double prec)
            : base(marc, cod, prec)
        {
            this.color = color;
        }

        public String Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public override string ToString()
        {
            return "Pintura: " + base.ToString() + $" -- Color: {this.Color}\n";
        }

        ///En la clase Pintura, implementar:
        ///implícitamente: PathJson, Xml(out T) y Json()
        public String PathJson
        {
            get
            {
                String ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return Path.Combine(ruta, "mendez.juanCruz.pintura.json");
            }
        }

        public bool Xml(out Pintura item)
        {
            Pintura auxT = default;
            bool ret = false;

            try
            {
                using (StreamReader stR = new StreamReader(((ISerializa)this).PathXml))
                {
                    XmlSerializer xmS = new XmlSerializer(typeof(Pintura));
                    auxT = (Pintura)xmS.Deserialize(stR);
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error, metodo XML(out Tomate) clase Pintura\nErrorType: {ex.Message}", ex);
            }

            item = auxT;
            return ret;
        }

        public bool Json()
        {
            bool ret = false;

            try
            {
                String aux = JsonSerializer.Serialize(this, typeof(Pintura));
                File.WriteAllText(this.PathJson, aux);
                ret = true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error, metodo Json() clase Pintura\nErrorType: {ex.Message}", ex);

            }
            return ret;
        }


        ///explícitamente: PathXml, Xml() y Json(out T)
        String ISerializa.PathXml
        {
            get
            {
                String ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                return Path.Combine(ruta, "mendez.juanCruz.pintura.xml");
            }
        }

        bool ISerializa.Xml()
        {
            bool ret = false;

            try
            {
                using (StreamWriter stW = new StreamWriter(((ISerializa)this).PathXml, append: true))
                {
                    XmlSerializer xmS = new XmlSerializer(typeof(Pintura));
                    xmS.Serialize(stW, this);
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error, metodo XML clase Pintura\nErrorType: {ex.Message}", ex);
            }
            return ret;
        }

        bool IDeserializa<Pintura>.Json(out Pintura item)
        {
            Pintura auxT = default;
            bool ret = false;

            try
            {
                using (StreamReader stR = new StreamReader(this.PathJson))
                {
                    auxT = (Pintura)JsonSerializer.Deserialize(stR.ReadToEnd(), typeof(Pintura), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error, metodo Json(out Pintura) clase Pintura\nErrorType: {ex.Message}", ex);
            }

            item = auxT;
            return ret;
        }
    }
}
