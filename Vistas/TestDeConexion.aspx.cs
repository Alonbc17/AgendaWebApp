using System;
using System.Data.SqlClient;
using TuProyecto.Controladores;

namespace TuProyecto.Vistas
{
    public partial class TestDeConexion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProbar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conexion = cn.AbrirConexion();

                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    lblResultado.Text = "Conexión exitosa ✔";
                }

                cn.CerrarConexion(conexion);
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Error: " + ex.Message;
            }
        }
    }
}