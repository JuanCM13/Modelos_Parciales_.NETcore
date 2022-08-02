using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesFinal
{
    public static class PersonajeDAO
    {
        /*Será estática.
        Su método ObtenerPersonajePorID consulta la base de datos buscando en la tabla PERSONAJES por el id recibido como argumento, 
        y retorna una instancia de Personaje con los datos recuperados.
        Si el registro tiene el valor 1 en su columna CLASE, se deberá instanciar y retornar un Guerrero.
        Si el registro tiene el valor 2 en su columna CLASE, se deberá instanciar y retornar un Hechicero.
        Si no encuentra nada, retorna null.*/
        public static Personaje ObtenerPersonajePorId(Decimal id)
        {
            Personaje ret = null;        
            Int32 idRec;
            String nombRec;
            short nivelRec;
            short clase;
            String titRec;

            String conexion = @"Server=localhost;Database=COMBATE_DB;Trusted_Connection=True;";
            SqlConnection sqlC = new(conexion);
            SqlCommand sqlCom = new();
            sqlCom.Connection = sqlC;
            sqlCom.CommandType = System.Data.CommandType.Text;
            sqlCom.Parameters.Clear();
            SqlDataReader sqlR;

            String consulta = "SELECT * FROM dbo.PERSONAJES WHERE id = @IdPersonaje";
            sqlCom.Parameters.AddWithValue("@idPersonaje", id);
            sqlCom.CommandText = consulta;

            try
            {
                sqlC.Open();

                using (sqlR = sqlCom.ExecuteReader())
                {
                    while(sqlR.Read())
                    {
                        idRec = Int32.Parse(sqlR["id"].ToString());
                        nombRec = sqlR["nombre"].ToString();
                        nivelRec = short.Parse(sqlR["nivel"].ToString());
                        clase = short.Parse(sqlR["clase"].ToString());
                        titRec = sqlR["titulo"].ToString();

                        switch (clase)
                        {
                            case 1:
                                ret = new Guerrero(idRec, nombRec , nivelRec);
                                break;
                            case 2:
                                ret = new Hechicero(idRec, nombRec , nivelRec);                                
                                break;
                        }
                        ret.Titulo = titRec;                    
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Error metodo {System.Reflection.MethodBase.GetCurrentMethod().Name} " +
                    $"clase: {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType}\nErrorType: {ex.Message}",ex);
            }
            finally
            {
                if(sqlC.State == System.Data.ConnectionState.Open)
                {
                    sqlC.Close();
                }
            }
            return ret;
        }
    }
}
