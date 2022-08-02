using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///Crear, en EntidadesSP, la clase ADO.
    ///Dicha clase se deberá comunicar con la base de datos, tendrá:
    ///Métodos de clase:
    ///ObtenerTodos() : List<Producto>
    ///ObtenerTodos(string) : List<Producto> -> se obtienen por marca 
    ///de acuerdo al parámetro recibido
    ///Métodos de instancia:
    ///Agregar(Producto) : bool
    ///Modificar(Producto) : bool -> se modifica a partir del código
    ///Eliminar(Producto) : bool -> se elimina a partir del código
    public class ADO
    {

        private static String conexion;
        private static SqlConnection connection;
        private static SqlCommand comando;
        private static SqlDataReader reader;
        public static event Action<Object, EventArgs> MarcaExistente;

        static ADO()
        {
            ADO.conexion = @"Server=localhost;Database=almacen_db;Trusted_Connection=True;";
            ADO.connection = new SqlConnection(ADO.conexion);
            ADO.comando = new SqlCommand();
            ADO.comando.CommandType = System.Data.CommandType.Text;
            ADO.comando.Connection = ADO.connection;
        }
    
        public static List<Producto> ObtenerTodos()
        {
            List<Producto> ret = new();
            String consulta;
            String marca;
            String tipo;
            Int32 codigo;
            Double precio;


            try
            {
                consulta = "SELECT * FROM dbo.productos";

                ADO.comando.CommandText = consulta;
                ADO.connection.Open();

                using(ADO.reader = ADO.comando.ExecuteReader())
                {
                    while(ADO.reader.Read())
                    {
                        marca = ADO.reader["marca"].ToString();
                        tipo = ADO.reader["tipo"].ToString();
                        codigo = (Int32)ADO.reader["codigo"];
                        precio = (Double)ADO.reader["precio"];
                         
                        ret.Add(new Producto(marca,tipo,codigo,precio));
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Error en el metodo ObtenerTodos(), clase ADO\nErrorType: {ex.Message}", ex);
            }
            finally
            {
                if(ADO.connection.State == System.Data.ConnectionState.Open)
                {
                    ADO.connection.Close();
                }
            }
            return ret;
        }

        public static List<Producto> ObtenerTodos(String filtro)
        {
            List<Producto> ret = new();
            String consulta;
            String marca;
            String tipo;
            Int32 codigo;
            Double precio;

            try
            {
                ADO.comando.Parameters.Clear();

                consulta = "SELECT * FROM dbo.productos WHERE marca = @marc";
                ADO.comando.Parameters.AddWithValue("@marc", filtro);
                ADO.comando.CommandText = consulta;
                ADO.connection.Open();

                using (ADO.reader = ADO.comando.ExecuteReader())
                {
                    while (ADO.reader.Read())
                    {
                        marca = ADO.reader["marca"].ToString();
                        tipo = ADO.reader["tipo"].ToString();
                        codigo = (Int32)ADO.reader["codigo"];
                        precio = (Double)ADO.reader["precio"];

                        ret.Add(new Producto(marca, tipo, codigo, precio));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el metodo ObtenerTodos(String marca), clase ADO\nErrorType: {ex.Message}", ex);
            }
            finally
            {
                if (ADO.connection.State == System.Data.ConnectionState.Open)
                {
                    ADO.connection.Close();
                }
            }
            return ret;
        }

        ///Métodos de instancia:
        ///Agregar(Producto) : bool
        public bool Agregar(Producto p)
        {
            String consulta;
            bool ret = false;
            if (!(p is null))
            {
                try
                {

                    if (ADO.ObtenerTodos(p.Marca).Count == 0)
                    {
                        ADO.comando.Parameters.Clear();
                        consulta = "INSERT INTO dbo.productos (marca , tipo , codigo , precio) VALUES (@marc , @tip , @cod , @prec)";
                        ADO.comando.Parameters.AddWithValue("@marc", p.Marca);
                        ADO.comando.Parameters.AddWithValue("@tip", p.Tipo);
                        ADO.comando.Parameters.AddWithValue("@cod", p.Codigo);
                        ADO.comando.Parameters.AddWithValue("@prec", p.Precio);

                        ADO.comando.CommandText = consulta;
                        ADO.connection.Open();

                        if (ADO.comando.ExecuteNonQuery() > 0)
                        {
                            ret = true;
                        }
                    }
                    else
                    {
                        ADO.MarcaExistente.Invoke(p, new EventArgs());
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error en el metodo Agregar(), clase ADO\nErrorType: {ex.Message}", ex);
                }
                finally
                {
                    if (ADO.connection.State == System.Data.ConnectionState.Open)
                    {
                        ADO.connection.Close();
                    }
                }
            }
            return ret;
        }
        
        ///Modificar(Producto) : bool -> se modifica a partir del código
        public bool Modificar(Producto p)
        {
            String consulta;
            bool ret = false;
            if (!(p is null))
            {
                try
                {
                    ADO.comando.Parameters.Clear();
                    consulta = "UPDATE dbo.productos SET marca = @marc , tipo = @tip , precio = @prec WHERE codigo = @cod";
                    ADO.comando.Parameters.AddWithValue("@marc", p.Marca);
                    ADO.comando.Parameters.AddWithValue("@tip", p.Tipo);
                    ADO.comando.Parameters.AddWithValue("@cod", p.Codigo);
                    ADO.comando.Parameters.AddWithValue("@prec", p.Precio);

                    ADO.comando.CommandText = consulta;
                    ADO.connection.Open();

                    if (ADO.comando.ExecuteNonQuery() > 0)
                    {
                        ret = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error en el metodo Modificar(), clase ADO\nErrorType: {ex.Message}", ex);
                }
                finally
                {
                    if (ADO.connection.State == System.Data.ConnectionState.Open)
                    {
                        ADO.connection.Close();
                    }
                }
            }
            return ret;
        }

        ///Eliminar(Producto) : bool -> se elimina a partir del código
        public bool Eliminar(Producto p)
        {
            String consulta;
            bool ret = false;
            if (!(p is null))
            {
                try
                {
                    ADO.comando.Parameters.Clear();
                    consulta = "DELETE FROM dbo.productos WHERE codigo = @cod";
                    ADO.comando.Parameters.AddWithValue("@cod", p.Codigo);

                    ADO.comando.CommandText = consulta;
                    ADO.connection.Open();

                    if (ADO.comando.ExecuteNonQuery() > 0)
                    {
                        ret = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error en el metodo Eliminar(), clase ADO\nErrorType: {ex.Message}", ex);
                }
                finally
                {
                    if (ADO.connection.State == System.Data.ConnectionState.Open)
                    {
                        ADO.connection.Close();
                    }
                }
            }
            return ret;
        }
    }
}
