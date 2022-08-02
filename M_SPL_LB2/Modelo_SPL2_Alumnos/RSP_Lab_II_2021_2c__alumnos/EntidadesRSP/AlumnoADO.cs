using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRSP
{
    ///AlumnoADO (hereda de Alumno)
    ///Atributos (estáticos)
    ///conexion : string
    ///connection : SqlConnection
    ///command : SqlCommand
    ///Constructor de clase que inicialice todos sus atributos
    ///Constructor que recibe un objeto de tipo Alumno cómo parámetro
    ///Métodos de instancia (públicos):
    ///ObtenerTodos() : List<Alumno> 
    ///Agregar() : bool
    ///Modificar() : bool -> se modifica a partir del dni
    ///Eliminar() : bool -> se elimina a partir del dni
    public class AlumnoADO : Alumno
    {
        private static String conexion;
        private static SqlConnection connection;
        private static SqlCommand command;
       
        public AlumnoADO(Alumno al)
            :base(al.Nota,al.Dni,al.Nombre,al.Apellido)
        {}

        static AlumnoADO()
        {
            AlumnoADO.conexion = @"Server=localhost;Database= utn_fra_alumnos;Trusted_Connection=True;";
            AlumnoADO.connection = new SqlConnection(conexion);
            AlumnoADO.command = new SqlCommand();
            AlumnoADO.command.CommandType = System.Data.CommandType.Text;
            AlumnoADO.command.Connection = AlumnoADO.connection;
        }

        public List<Alumno> ObtenerTodos()
        {
            SqlDataReader reader;
            List<Alumno> retorno = new();
            String consulta;
            Int32 dni;
            String nombre;
            String apellido;
            Double nota;

            try
            {
                consulta = "SELECT * FROM dbo.alumnos";
                AlumnoADO.command.CommandText = consulta;

                AlumnoADO.connection.Open();
                using (reader = AlumnoADO.command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dni = (Int32)reader["dni"];
                        nombre = reader["nombre"].ToString();
                        apellido = reader["apellido"].ToString();
                        nota = (Double)reader["nota"];

                        retorno.Add(new Alumno(nota, dni, nombre, apellido));
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Error en metodo ObtenerTodos, clase AlumnoADO\nERROR TYPE: {ex.Message}", ex);
            }
            finally
            {
                if(AlumnoADO.connection.State == System.Data.ConnectionState.Open)
                {
                    AlumnoADO.connection.Close();
                }
            }
            return retorno;
        }

        public bool Agregar()
        {
            String consulta;
            bool ret = true;
            
            try
            {
                AlumnoADO.command.Parameters.Clear();
                consulta = "INSERT INTO dbo.alumnos(dni,apellido,nombre,nota) VALUES (@dn,@ape,@nom,@not)";
                AlumnoADO.command.Parameters.AddWithValue("@dn", this.Dni);
                AlumnoADO.command.Parameters.AddWithValue("@ape", this.Apellido);
                AlumnoADO.command.Parameters.AddWithValue("@nom", this.Nombre);
                AlumnoADO.command.Parameters.AddWithValue("@not", this.Nota);

                AlumnoADO.command.CommandText = consulta;
                AlumnoADO.connection.Open();

                if(AlumnoADO.command.ExecuteNonQuery() == 0)
                {
                    ret = false;
                }            
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en metodo Agregar, clase AlumnoADO\nERROR TYPE: {ex.Message}", ex);
            }
            finally
            {
                if (AlumnoADO.connection.State == System.Data.ConnectionState.Open)
                {
                    AlumnoADO.connection.Close();
                }
            }
            return ret;
        }

        public bool Modificar()
        {
            String consulta;
            bool ret = true;

            try
            {
                AlumnoADO.command.Parameters.Clear();
                consulta = "UPDATE dbo.alumnos SET apellido = @ape , nombre = @nom , nota = @not WHERE dni = @dn";
                AlumnoADO.command.Parameters.AddWithValue("@dn", this.Dni);
                AlumnoADO.command.Parameters.AddWithValue("@ape", this.Apellido);
                AlumnoADO.command.Parameters.AddWithValue("@nom", this.Nombre);
                AlumnoADO.command.Parameters.AddWithValue("@not", this.Nota);

                AlumnoADO.command.CommandText = consulta;
                AlumnoADO.connection.Open();

                if(AlumnoADO.command.ExecuteNonQuery() == 0)
                {
                    ret = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en metodo Modificar, clase AlumnoADO\nERROR TYPE: {ex.Message}", ex);
            }
            finally
            {
                if (AlumnoADO.connection.State == System.Data.ConnectionState.Open)
                {
                    AlumnoADO.connection.Close();
                }
            }
            return ret;
        }

        public bool Eliminar()
        {
            String consulta;
            bool ret = true;

            try
            {
                AlumnoADO.command.Parameters.Clear();
                consulta = "DELETE dbo.alumnos WHERE dni = @dn"; //${this.Dni}
                AlumnoADO.command.Parameters.AddWithValue("@dn", this.Dni); //te ahorras esto, pero aveces falla, usar como arriba

                AlumnoADO.command.CommandText = consulta;
                AlumnoADO.connection.Open();

                if (AlumnoADO.command.ExecuteNonQuery() == 0)
                {
                    ret = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en metodo Eliminar, clase AlumnoADO\nERROR TYPE: {ex.Message}", ex);
            }
            finally
            {
                if (AlumnoADO.connection.State == System.Data.ConnectionState.Open)
                {
                    AlumnoADO.connection.Close();
                }
            }
            return ret;
        }
    }
}
