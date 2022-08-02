using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntidadesSP
{
    ///Zapato->hereda de producto 
    ///ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
    public class Zapato : Producto , ISerializa , IDeserializa
    {
        public Zapato() { }

        public Zapato(String mar, String tip, Int32 cod, Double prec)
            : base(mar,tip,cod,prec)
        {}

        public override string ToString()
        {
            return "Zapato: " + base.ToString() + "\n";
        }

        public String Path
        {
            get 
            {
                ///El archivo .xml guardarlo en el escritorio del cliente, con el nombre formado con su apellido.nombre.zapato.xml
                ///Ejemplo: Alumno Juan Pérez -> perez.juan.zapato.xml
                String semiRuta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                return System.IO.Path.Combine(semiRuta, "Mendez.JuanCruz.zapato.xml");
            }
        }

        ///Implementar (implícitamente) ISerializa zapato
        public bool Xml()
        {
            bool ret = false;

            try
            {
                using (StreamWriter stw = new StreamWriter(this.Path))
                {
                    XmlSerializer xmlS = new XmlSerializer(typeof(Zapato));
                    xmlS.Serialize(stw, this);
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al serializar zapato, metodo Xml() , clase Zapato\nError: {ex.Message}",ex);
            }
            return ret;
        }

        ///Implementar (explícitamente) IDeserializa en zapato

        bool IDeserializa.Xml(out Zapato zapato)
        {
            bool ret = false;
            Zapato auxZ = default; 

            try
            {
                using (StreamReader str = new StreamReader(this.Path))
                {
                    XmlSerializer xmlS = new XmlSerializer(typeof(Zapato));
                    auxZ = (Zapato)xmlS.Deserialize(str);
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al deserializar zapato, metodo IDeserialize.Xml() , clase Zapato\nError: {ex.Message}", ex);
            }

            zapato = auxZ;
            return ret;
        }

    }
}
