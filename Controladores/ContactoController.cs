using AgendaWebApp.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace AgendaWebApp.Controladores
{
    public class ContactoController
    {
        private string connectionString;

        public ContactoController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        // CREATE
        public void AgregarContacto(ContactoModel contacto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CrearContacto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", contacto.Nombre);
                cmd.Parameters.AddWithValue("@apellido", contacto.Apellido);
                cmd.Parameters.AddWithValue("@correo", contacto.Correo);
                cmd.Parameters.AddWithValue("@telefono", contacto.Telefono);
                cmd.Parameters.AddWithValue("@direccion", contacto.Direccion);
                cmd.Parameters.AddWithValue("@creado_por", contacto.CreadoPor);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // READ
        public List<ContactoModel> ListarContactos()
        {
            List<ContactoModel> lista = new List<ContactoModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_LeerContacto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ContactoModel contacto = new ContactoModel()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nombre = reader["nombre"].ToString(),
                        Apellido = reader["apellido"].ToString(),
                        Correo = reader["correo"].ToString(),
                        Telefono = reader["telefono"].ToString(),
                        Direccion = reader["direccion"].ToString(),
                        CreadoPor = reader["creado_por"].ToString(),
                        FechaCreacion = Convert.ToDateTime(reader["fecha_creacion"]),
                        ModificadoPor = reader["modificado_por"]?.ToString(),
                        FechaModificacion = reader["fecha_modificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["fecha_modificacion"])
                    };

                    lista.Add(contacto);
                }
            }

            return lista;
        }

        // UPDATE
        public void ActualizarContacto(ContactoModel contacto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarContacto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", contacto.Id);
                cmd.Parameters.AddWithValue("@nombre", contacto.Nombre);
                cmd.Parameters.AddWithValue("@apellido", contacto.Apellido);
                cmd.Parameters.AddWithValue("@correo", contacto.Correo);
                cmd.Parameters.AddWithValue("@telefono", contacto.Telefono);
                cmd.Parameters.AddWithValue("@direccion", contacto.Direccion);
                cmd.Parameters.AddWithValue("@modificado_por", contacto.ModificadoPor);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void EliminarContacto(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarContacto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}