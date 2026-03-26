using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TuProyecto.Controladores
{
    public class Conexion
    {
        private string cadenaConexion;

        public Conexion()
        {
            // Lee la cadena desde Web.config
            cadenaConexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            return conexion;
        }

        public SqlConnection AbrirConexion()
        {
            SqlConnection conexion = ObtenerConexion();
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la conexión: " + ex.Message);
            }

            return conexion;
        }

        public void CerrarConexion(SqlConnection conexion)
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexión: " + ex.Message);
            }
        }
    }
}