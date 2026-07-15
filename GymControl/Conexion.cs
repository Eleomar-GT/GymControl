using System;
using System.Collections.Generic;
using System.Data.SqlClient; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace conexionBD.Clases
{
    internal class Conexion
    {
        // Se crea objeto de la clase SqlConnection
        SqlConnection conex = new SqlConnection();

        // Datos de la conexión
        static string servidor = @".\SQLEXPRESS";
        static string bd = "clientes_GC";

        // Usuario y contraseña de SQL Server
        static string usuario = "root1";
        static string pass = "root1";

        // Cadena de conexión corregida
        string cadenaConexion = "Data Source=" + servidor + ";Initial Catalog=" + bd + ";Integrated Security=True;TrustServerCertificate=True;";

        // Se crea método establece Conexion
        public SqlConnection estableceConexion()
        {
           try
           {
                 //se asigna la cadena de conexión al objeto SqlConnection
                 conex.ConnectionString = cadenaConexion;
                 conex.Open();
                
           }
            catch (Exception ex)
           {
                MessageBox.Show("No hay conexión a la BD: " + ex.Message); // .Message es más limpio que .ToString() para el usuario
           }
            return conex;
        }

        // Se crea método cerrarConexion
        public void cerrarConexion()
        {
            // Es buena práctica verificar si no es nula y si está abierta antes de cerrar
            if (conex != null && conex.State == System.Data.ConnectionState.Open)
            {
                conex.Close();
            }
        }
    }
}